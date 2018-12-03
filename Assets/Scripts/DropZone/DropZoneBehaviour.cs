using System;
using System.Collections;
using Cargo;
using Scoring;
using ScriptableObjects;
using UnityEngine;
using Utils;

namespace DropZone {
	public class DropZoneBehaviour : MonoBehaviour {

		public Crane CranePrefab;
		public Crane crane;
		public SpriteRenderer ZoneOutline;
		private Material zoneMat;
		public SpriteRenderer Shadow;
		private Material shadowMat;
		public Transform ShadowRotator;
		public Transform ShadowBottomLeft;
		public MoneyIndicator MoneyIndicatorPrefab;

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

		public AccelTooltipController craneTip;
		public RotateTooltipController rotateTip;
        
		public bool IsCraneReady {
			get { return crane != null && crane.IsReady; }
		}
		
		void Start() {
			zoneMat = ZoneOutline.material;
			shadowMat = Shadow.material;
			crane = Instantiate(CranePrefab, transform);
			if (craneTip != null)
			{
				Instantiate(craneTip, crane.transform);
			}

			if (rotateTip != null)
			{
				Instantiate(rotateTip, crane.Chain.transform);
			}
			crane.InitializeCrane(this);
		}
		
		void Update() {
			if (time < timeTilDrop) {
				time += GetDeltaTime();
				if (time >= timeTilDrop) {
					DropCargo();
				}

				else if (Input.GetKeyDown(KeyCode.Q))
				{
					FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.AmbientRotatePieceCounterClockwise);
					RotateCargo(90);
				} if (Input.GetKeyDown(KeyCode.E)) {
					FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.AmbientRotatePieceClockwise);
					RotateCargo(-90);
				}
			}

			dashOffset += GetDeltaTime() * 2;
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

		public void RotateCargo(float degrees) {
			if (crane.HasPiece) {
				var rot = ShadowRotator.transform.rotation;
				ShadowRotator.transform.rotation = Quaternion.Euler(0, 0, degrees + rot.eulerAngles.z);
				cargo.transform.rotation = ShadowRotator.transform.rotation;
				crane.SetCargoSprite(cargo.spriteRenderer);
			}
		}
		
		public void SetCargo(CargoBehaviour cargo, float timeTilDrop, Action<CargoBehaviour> onDrop) {
			this.cargo = cargo;
			if (timeTilDrop <= 0) this.timeTilDrop = 1f; // minumum drop tile is 1 second
			else this.timeTilDrop = timeTilDrop;

			if (!crane.HasPiece) {
				crane.IsReady = false;
				crane.GoGetNextPiece(timeTilDrop * .3f, () => {
					crane.SetCargoSprite(cargo.spriteRenderer);
					StartCoroutine(StartShadow(timeTilDrop * .7f * .3f));
					crane.GoDropPiece(timeTilDrop * .7f, () => {
						crane.SetCargoSprite(null);
						crane.IsReady = true;
						crane.GoGetNextPiece(timeTilDrop * .3f, () => {});
					});
				});
			} else {
				crane.IsReady = false;
				crane.SetCargoSprite(cargo.spriteRenderer);
				StartCoroutine(StartShadow(timeTilDrop * .3f));
				crane.GoDropPiece(timeTilDrop, () => {
					crane.SetCargoSprite(null);
					crane.IsReady = true;
					crane.GoGetNextPiece(timeTilDrop * .3f, () => {});
				});
			}
			this.onDrop = onDrop;
			time = 0;
		}

		private IEnumerator StartShadow(float delay) {
			yield return new WaitForSeconds(delay);
			Shadow.gameObject.SetActive(true);
			Shadow.sprite = cargo.spriteRenderer.sprite;
			Shadow.transform.localScale = cargo.transform.localScale;
			ShadowRotator.transform.rotation = cargo.transform.rotation;
			ShadowBottomLeft.transform.localPosition = new Vector3(
				-cargo.spriteRenderer.sprite.bounds.extents.x,
				-cargo.spriteRenderer.sprite.bounds.extents.y,
				0);
			blurryness = blurrynessStart;
			SetShadowBlurryness();
			transparentness = transparentnessStart;
			SetShadowTransparentness();
		}

		public void DropCargo() {
			if (cargo != null) {
				Shadow.gameObject.SetActive(false);
				var cargoInst = cargo;
				cargoInst.gameObject.SetActive(true);
				foreach (CompositeCollider2D c2d in cargoInst.GetComponentsInChildren<CompositeCollider2D>())
				{
					c2d.GenerateGeometry();
				}
				cargoInst.transform.position = Shadow.transform.position;
				cargoInst.transform.rotation = Shadow.transform.rotation;
				cargo.SetValueTip(MoneyIndicatorPrefab);
				FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.ImpactWood);
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
		
		private float GetDeltaTime() {
			var deltaTime = Time.deltaTime;
			if (Input.GetKey(MustGoFaster.Key)) return deltaTime * MustGoFaster.SpeedMultiplier;
			return deltaTime;
		}
	}
}
