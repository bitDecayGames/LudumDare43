using System;
using UnityEngine;
using Utils;

namespace DropZone {
    public class Crane : MonoBehaviour {
        public SpriteRenderer Arm;
        private RotateOverTime ArmRotator;
        public Chain Chain;
        private DropZoneBehaviour dropZone;
        public SpriteRenderer CargoRenderer;
        private bool isLeft;
        private Action onDone;

        private bool _hasPiece;
        public bool HasPiece {
            get { return _hasPiece; }
            private set { _hasPiece = value; }
        }

        public void InitializeCrane(DropZoneBehaviour dropZone) {
            Arm = GetComponentInChildren<SpriteRenderer>();
            Chain = GetComponentInChildren<Chain>();
            ArmRotator = Arm.gameObject.GetComponent<RotateOverTime>();
            CargoRenderer = GetSpriteRendererOnlyInChildren(Chain.transform);

            this.dropZone = dropZone;
            var localPos = new Vector3(0, 0, 0);
            localPos.y = .75f;
            localPos.x = -(Arm.size.x - .11f); // TODO: it should be - for the left, and + for the right
            isLeft = localPos.x < 0;

//            print("Local pos: " + localPos);
            transform.localPosition = localPos;
        }

        public void SetCargoSprite(SpriteRenderer sr) {
            if (sr == null) {
                CargoRenderer.gameObject.SetActive(false);
            } else {
                CargoRenderer.gameObject.SetActive(true);
                CargoRenderer.sprite = sr.sprite;
                CargoRenderer.transform.localScale = sr.transform.localScale;
                CargoRenderer.transform.rotation = sr.transform.rotation;
            }
        }

        public void GoGetNextPiece(float time, Action onDone) {
            this.onDone = onDone;
            Chain.SetTargetLength(.25f, time * .5f, () => {
                ArmRotator.SetTargetRotation(90, time *.5f, () => {
                    HasPiece = true;
                    if (onDone != null) onDone();
                });
            });
        }

        public void GoDropPiece(float time, Action onDone) {
            this.onDone = onDone;
            ArmRotator.SetTargetRotation(isLeft ? 0 : 180, time * 0.3f, () => {
                Chain.SetTargetLength(.75f, time * 0.7f, () => {
                    HasPiece = false;
                    if (onDone != null) onDone();
                });
            });
        }

        private SpriteRenderer GetSpriteRendererOnlyInChildren(Transform parent) {
            foreach (SpriteRenderer renderer in parent.GetComponentsInChildren<SpriteRenderer>()) {
                if (renderer != null && renderer.transform.parent == parent) {
                    return renderer;
                }
            }

            return null;
        }
    }
}