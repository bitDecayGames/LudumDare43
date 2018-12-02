using UnityEngine;
using Utils;

namespace DropZone {
    public class Crane : MonoBehaviour {
        public SpriteRenderer Arm;
        private RotateOverTime ArmRotator;
        private DropZoneBehaviour dropZone;
        private bool isLeft;

        public void InitializeCrane(DropZoneBehaviour dropZone)
        {
            Arm = GetComponentInChildren<SpriteRenderer>();
            ArmRotator = Arm.gameObject.GetComponent<RotateOverTime>();

            GoGetNextPiece(8);
            
            this.dropZone = dropZone;
            var localPos = new Vector3(0, 0, 0);
            localPos.y = .75f;
            localPos.x = -Arm.sprite
                .bounds
                .size
                .x; // TODO: it should be - for the left, and + for the right
            isLeft = localPos.x < 0;

            transform.localPosition = localPos;
        }

        public void GoGetNextPiece(float time) {
            var thirds = time * 0.5f;
            ArmRotator.SetTargetRotation(90, thirds, () => {
                ArmRotator.SetTargetRotation(isLeft ? 0 : 180, thirds, null);
            });
        }
    }
}