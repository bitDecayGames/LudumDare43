using Particles;
using UnityEngine;

namespace DebugScripts {
    public class DebugMyParticleEmitter : MonoBehaviour {
        public Camera MyCamera;
        public MyParticleEmitter BloodEmitter;
        public MyParticleEmitter WoodEmitter;
        public MyParticleEmitter PoofEmitter;
        public MyParticleEmitter MoneyEmitter;

        void Update() {
            var mousePos = MyCamera.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                BloodEmitter.EmitParticles(mousePos, 3);
            } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
                WoodEmitter.EmitParticles(mousePos, 5);
            } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                PoofEmitter.EmitParticles(mousePos, 7);
            } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
                ((MoneyParticle) MoneyEmitter.EmitParticle(mousePos)).Green().SetText("$123");
                ((MoneyParticle) MoneyEmitter.EmitParticle(mousePos)).Red().SetText("$333");
            }
        }
    }
}