using UnityEngine;

namespace Particles {
    public class RotatingMyParticle : MyParticle {
        
        protected void UpdateRotation() {
            var euler = transform.rotation.eulerAngles;
            euler.z += velocity.x * -1000 + velocity.y * 1000;
            transform.rotation = Quaternion.Euler(euler.x, euler.y, euler.z);
        }

        void Update() {
            UpdateVelocityPosition();
            UpdateRotation();
        }
    }
}