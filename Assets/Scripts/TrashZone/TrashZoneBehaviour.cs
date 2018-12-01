using System;
using System.Collections;
using Cargo;
using ScriptableObjects;
using UnityEngine;
using Utils;

namespace TrashZone {
	public class TrashZoneBehaviour : MonoBehaviour {

		public SpriteRenderer TrashZoneShader;
		private Material zoneMat;

		private BoxCollider2D myBox;

		private CargoBehaviour cargo;
		private Action<CargoBehaviour> onDrop;

		private float lineOffset;

		void Start() {
			zoneMat = TrashZoneShader.material;
			myBox = GetComponent<BoxCollider2D>();
		}
		
		void Update() {
			lineOffset += Time.deltaTime * 2;
			SetDashOffset();
		}

		private void SetDashOffset() {
			if (zoneMat != null) {
				zoneMat.SetFloat("_LineOffset", lineOffset);
			}
		}

		public void CheckAndTakeOutTrash(Transform cargo) {
			if (myBox.OverlapPoint(cargo.position)) {
				//TODO animate killing cargo
				Destroy(cargo.gameObject);
			}
		}
	}
}
