using System;
using Cargo;
using SuperTiled2Unity;
using UnityEngine;

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
            print("Check and take out trash! " + cargo.position);
            if (myBox.OverlapPoint(cargo.position)) {
                var superObj = cargo.gameObject.GetComponentInAncestor<SuperObject>();
                var cargoObj = superObj.GetComponent<CargoBehaviour>();
                cargoObj.DestroyInWater();
                cargoObj.EmitBadMoney(cargoObj.transform.GetChild(0).position);
            }
        }
    }
}