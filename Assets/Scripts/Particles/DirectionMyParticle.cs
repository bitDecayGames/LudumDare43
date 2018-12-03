using UnityEngine;

namespace Particles {
    public class DirectionMyParticle : MyParticle {
        public override void Emitted(Vector3 velocity, float life) {
            base.Emitted(velocity, life);
            UpdateRotation();
        }

        protected void UpdateRotation() {
            transform.rotation = Quaternion.FromToRotation(Vector3.right, velocity.normalized);
        }

        void Update() {
            UpdateVelocityPosition();
        }
    }
}