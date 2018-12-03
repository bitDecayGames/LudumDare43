using UnityEngine;
using Utils;

namespace Particles {
    public class MyParticle : MonoBehaviour {
        public AbstractFadeOutOverTime Fader;
        public KillAfterTime Killer;
        public float Resistance = 0.97f;
        protected Vector3 velocity;
        protected bool emitted;
        
        public virtual void Emitted(Vector3 velocity, float life) {
            this.velocity = new Vector3(velocity.x, velocity.y, 0);
            emitted = true;
            Fader.timeToFadeOut = life;
            Killer.timeTilDeath = life;
        }

        void Update() {
            UpdateVelocityPosition();
        }

        protected void UpdateVelocityPosition() {
            if (emitted) {
                velocity *= Resistance;
                transform.position += velocity;
            }
        }
    }
}