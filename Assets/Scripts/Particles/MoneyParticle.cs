using TMPro;
using UnityEngine;

namespace Particles {
    public class MoneyParticle : MyParticle {
        public TextMeshPro Text;

        public MoneyParticle SetText(string text) {
            Text.text = text;
            return this;
        }

        public MoneyParticle Green() {
            Text.color = new Color(0.2f, .8f, 0.2f);
            return this;
        }

        public MoneyParticle Red() {
            Text.color = new Color(.8f, .2f, .2f);
            return this;
        }
        
        public override void Emitted(Vector3 velocity, float life) {
            base.Emitted(velocity, life);
            if (this.velocity.normalized.y < 0.5f) this.velocity.y = 0.5f * this.velocity.magnitude;
            if (this.velocity.y < 0) this.velocity.y *= -1;
        }

        void Update() {
            UpdateVelocityPosition();
        }
    }
}