using Particles;
using UnityEngine;

namespace DebugScripts {
    public class DebugMyParticleEmitter : MonoBehaviour {
        public Camera MyCamera;
        public MyParticleEmitter BloodEmitter;
        public MyParticleEmitter WoodEmitter;
        public MyParticleEmitter PoofEmitter;

        void Update() {
            var mousePos = MyCamera.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetKeyDown(KeyCode.Keypad1)) {
                BloodEmitter.EmitParticles(mousePos, 3);
            } else if (Input.GetKeyDown(KeyCode.Keypad2)) {
                WoodEmitter.EmitParticles(mousePos, 5);
            } else if (Input.GetKeyDown(KeyCode.Keypad3)) {
                PoofEmitter.EmitParticles(mousePos, 7);
            }
        }
    }
}