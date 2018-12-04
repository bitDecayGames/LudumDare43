using UnityEngine;

namespace Utils {
    public class WaitThenEnableComponent : MonoBehaviour {
        public MonoBehaviour OtherComponent;
        public float TimeToWait = 1f;
        private bool ready;

        void Start() {
            ready = true;
            OtherComponent.enabled = false;
        }
        
        void Update() {
            if (ready) {
                TimeToWait -= Time.deltaTime;
                if (TimeToWait < 0) {
                    ready = false;
                    OtherComponent.enabled = true;
                }
            }
        }
    }
}