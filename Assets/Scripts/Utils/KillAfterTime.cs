using UnityEngine;

namespace Utils {
    public class KillAfterTime : MonoBehaviour {
        public float timeTilDeath = 1f;

        void Update() {
            timeTilDeath -= Time.deltaTime;
            if (timeTilDeath < 0) {
                Destroy(gameObject);
            }
        }
    }
}