using System;
using FMOD.Studio;
using UnityEngine;
using Utils;

namespace DropZone {
    public class Crane : MonoBehaviour {
        public SpriteRenderer Arm;
        private RotateOverTime ArmRotator;
        public Chain Chain;
        private DropZoneBehaviour dropZone;
        public SpriteRenderer CargoRenderer;
        public Transform CargoOrigin;
        public Transform CargoBottomLeft;
        private bool isLeft;
        private Action onDone;

        private EventInstance chainSound;
        
        private bool _hasPiece;
        public bool HasPiece {
            get { return _hasPiece; }
            private set { _hasPiece = value; }
        }
        
        private bool _isReady = true;
        public bool IsReady {
            get { return _isReady; }
            set { _isReady = value; }
        }

        public void InitializeCrane(DropZoneBehaviour dropZone) {
            Arm = GetComponentInChildren<SpriteRenderer>();
            Chain = GetComponentInChildren<Chain>();
            ArmRotator = Arm.gameObject.GetComponent<RotateOverTime>();
            CargoRenderer = GetSpriteRendererOnlyInChildren(Chain.transform);
            CargoOrigin = GetTransformFromNextChild(Chain.transform);
            CargoBottomLeft = GetTransformFromNextChild(CargoOrigin.transform);

            this.dropZone = dropZone;
            var localPos = new Vector3(0, 0, 0);
            localPos.y = .75f;
            localPos.x = -(Arm.size.x - .11f); // TODO: it should be - for the left, and + for the right
            isLeft = localPos.x < 0;
            transform.localPosition = localPos;
        }

        public void SetCargoSprite(SpriteRenderer sr) {
            if (sr == null) {
                CargoRenderer.gameObject.SetActive(false);
            } else {
                CargoRenderer.gameObject.SetActive(true);
                CargoRenderer.sprite = sr.sprite;
                CargoRenderer.transform.localScale = sr.transform.localScale;
                CargoOrigin.transform.rotation = sr.transform.rotation;
                CargoBottomLeft.transform.localPosition = new Vector3(
                    -sr.sprite.bounds.extents.x,
                    -sr.sprite.bounds.extents.y,
                    0);
            }
        }

        public void GoGetNextPiece(float time, Action onDone) {
            this.onDone = onDone;
            Chain.SetTargetLength(.25f, time * .5f, 
            () => {
                ArmRotator.SetTargetRotation(90, time *.5f, () => {
                    HasPiece = true;
                    if (onDone != null) onDone();
                });
                chainSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            },
            () => {
                chainSound = FMODSoundEffectsPlayer.GetLocalReferenceInScene()
                    .PlaySoundEffect(Sfx.AmbientChainMove2);
            });
        }

        public void GoDropPiece(float time, Action onDone) {
            this.onDone = onDone;
            ArmRotator.SetTargetRotation(isLeft ? 0 : 180, time * 0.3f, () =>
            {
                Chain.SetTargetLength(.75f, time * 0.7f,
                    () =>
                    {
                        HasPiece = false;
                        chainSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                        if (onDone != null) onDone();
                    },
                    () =>
                    {
                        chainSound = FMODSoundEffectsPlayer.GetLocalReferenceInScene()
                            .PlaySoundEffect(Sfx.AmbientChainMove2);
                    });
            });
        }

        private SpriteRenderer GetSpriteRendererOnlyInChildren(Transform parent) {
            foreach (SpriteRenderer renderer in parent.GetComponentsInChildren<SpriteRenderer>()) {
                if (renderer != null && renderer.transform != parent) {
                    return renderer;
                }
            }

            return null;
        }
        private Transform GetTransformFromNextChild(Transform parent) {
            return parent.GetChild(0);
        }
    }
}