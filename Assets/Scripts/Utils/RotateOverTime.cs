using System;
using UnityEngine;

namespace Utils {
    public class RotateOverTime : MonoBehaviour {
        private float time;
        private float timeToRotate;
        private float rotation;
        private float targetRotation;
        private bool rotating;

        private Action onDone;
        
        void Update() {
            if (rotating) {
                if (time < timeToRotate) {
                    var zRot = time / timeToRotate * (targetRotation - rotation) + rotation;
                    var eulerAngles = transform.rotation.eulerAngles;
                    eulerAngles.z = zRot;
                    transform.rotation = Quaternion.Euler(eulerAngles);
                    time += GetDeltaTime();
                } else {
                    rotating = false;
                    var eulerAngles = transform.rotation.eulerAngles;
                    eulerAngles.z = targetRotation;
                    transform.rotation = Quaternion.Euler(eulerAngles);
                    if (onDone != null) onDone();
                }
            }
        }

        public void SetTargetRotation(float degrees, float timeToRotate, Action onDone) {
            rotating = true;
            targetRotation = degrees;
            rotation = transform.rotation.eulerAngles.z;
            time = 0;
            this.timeToRotate = timeToRotate;
            this.onDone = onDone;
        }

        private float GetDeltaTime() {
            var deltaTime = Time.deltaTime;
            if (Input.GetKey(MustGoFaster.Key)) return deltaTime * MustGoFaster.SpeedMultiplier;
            return deltaTime;
        }
    }
}