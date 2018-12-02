using System;
using System.Collections;
using Cargo;
using ScriptableObjects;
using UnityEngine;
using Utils;

namespace DropZone {
	public class DropZoneBehaviour : MonoBehaviour {

		public SpriteRenderer ZoneOutline;
		private Material zoneMat;
		public SpriteRenderer Shadow;
		private Material shadowMat;

		private CargoBehaviour cargo;
		private Action<CargoBehaviour> onDrop;
		private float timeTilDrop;
		private float time;

		private float dashOffset;

		private const float blurrynessTarget = 0.01f;
		private const float blurrynessStart = 0.03f;
		private float blurryness = 0;
		private const float transparentnessTarget = .5f;
		private const float transparentnessStart = 0f;
		private float transparentness = 0;

		void Start() {
			zoneMat = ZoneOutline.material;
			shadowMat = Shadow.material;
		}
		
		void Update() {
			if (time < timeTilDrop) {
				time += Time.deltaTime;
				if (time >= timeTilDrop) {
					DropCargo();
				}
			}

			dashOffset += Time.deltaTime * 2;
			SetOutlineOffset();

			if (blurryness > blurrynessTarget) {
				blurryness *= 0.97f;
				SetShadowBlurryness();
			}

			if (transparentness < transparentnessTarget) {
				transparentness += 0.01f;
				SetShadowTransparentness();
			}
		}
		
		public void SetCargo(CargoBehaviour cargo, float timeTilDrop, Action<CargoBehaviour> onDrop) {
			this.cargo = cargo;
			if (timeTilDrop <= 0) this.timeTilDrop = 1f; // minumum drop tile is 1 second
			else this.timeTilDrop = timeTilDrop;
			this.onDrop = onDrop;
			time = 0;
			Shadow.gameObject.SetActive(true);
			Shadow.sprite = cargo.spriteRenderer.sprite;
			Shadow.transform.localScale = cargo.transform.localScale;
			blurryness = blurrynessStart;
			SetShadowBlurryness();
			transparentness = transparentnessStart;
			SetShadowTransparentness();
		}

		public void DropCargo() {
			if (cargo != null) {
				Shadow.gameObject.SetActive(false);
				var cargoInst = Instantiate(cargo);
				cargoInst.transform.position = Shadow.transform.position;
				cargoInst.KillPlayerIfColliding();
				StartCoroutine(WaitThenCheckForCollisions(cargoInst));
				cargo = null;
				time = 0;
				timeTilDrop = 0;
			}
		}

		private IEnumerator WaitThenCheckForCollisions(CargoBehaviour cargoInst) {
			yield return new WaitForSeconds(0.0f);
			cargoInst.KillSelfIfCollidingWithAnotherCargo();
			if (onDrop != null) {
				var tmp = onDrop;
				onDrop = null;
				tmp(cargoInst);
			}
		}

		private void SetOutlineOffset() {
			if (zoneMat != null) {
				zoneMat.SetFloat("_DashOffset", dashOffset);
			}
		}

		private void SetShadowBlurryness() {
			if (shadowMat != null) {
				shadowMat.SetFloat("_Blurryness", blurryness);
			}
		}

		private void SetShadowTransparentness() {
			if (shadowMat != null) {
				shadowMat.SetFloat("_Transparentness", transparentness);
			}
		}
	}
}
