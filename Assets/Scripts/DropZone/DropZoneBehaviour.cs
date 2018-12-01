using System;
using System.Collections;
using Cargo;
using ScriptableObjects;
using UnityEngine;

namespace DropZone {
	public class DropZoneBehaviour : MonoBehaviour {

		public SpriteRenderer ZoneOutline;
		private Material zoneMat;
		public SpriteRenderer Shadow;
		public CargoFactory Factory;

		private CargoBehaviour cargo;
		private Action<CargoBehaviour> onDrop;
		private float timeTilDrop;
		private float time;

		private float dashOffset;

		void Start() {
			// TODO: MW this is debug code
			SetCargo(Factory.ByName("LCargo"), 3f, inst => {
				Debug.Log("Dropped cargo1");
				
				SetCargo(Factory.ByName("TCargo"), 4f, inst2 => {
					Debug.Log("Dropped cargo 2");
				});
			});

			zoneMat = ZoneOutline.material;
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
		}
		
		public void SetCargo(CargoBehaviour cargo, float timeTilDrop, Action<CargoBehaviour> onDrop) {
			this.cargo = cargo;
			this.timeTilDrop = timeTilDrop;
			this.onDrop = onDrop;
			time = 0;
			Shadow.sprite = cargo.spriteRenderer.sprite;
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
	}
}
