using System;
using System.Collections;
using Boo.Lang.Runtime;
using Cargo;
using ScriptableObjects;
using SuperTiled2Unity;
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
				DestroySuperObject(cargo);
			}
		}

		private void DestroySuperObject(Transform cargo) {
			var superObj = cargo.gameObject.GetComponentInAncestor<SuperObject>();
			if (superObj == null) throw new RuntimeException("Couldn't find super object to destroy");
			Destroy(superObj.gameObject);
		}
	}
}
