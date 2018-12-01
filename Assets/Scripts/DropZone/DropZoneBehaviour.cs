﻿using System;
using System.Collections;
using Cargo;
using ScriptableObjects;
using UnityEngine;

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
		}
		
		public void SetCargo(CargoBehaviour cargo, float timeTilDrop, Action<CargoBehaviour> onDrop) {
			this.cargo = cargo;
			this.timeTilDrop = timeTilDrop;
			this.onDrop = onDrop;
			time = 0;
			Shadow.gameObject.SetActive(true);
			Shadow.sprite = cargo.spriteRenderer.sprite;
			Shadow.transform.localScale = cargo.transform.localScale;
			blurryness = blurrynessStart;
		}

		public void DropCargo() {
			if (cargo != null) {
				var cargoInst = Instantiate(cargo);
				cargoInst.transform.position = Shadow.transform.position;
				StartCoroutine(WaitThenKillPlayerIfColliding(cargoInst));
				cargo = null;
				time = 0;
				timeTilDrop = 0;
			}
		}

		private IEnumerator WaitThenKillPlayerIfColliding(CargoBehaviour cargoInst) {
			yield return new WaitForSeconds(0.1f);
			cargoInst.KillPlayerIfColliding();
			Shadow.gameObject.SetActive(false);
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
	}
}
