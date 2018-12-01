using UnityEngine;

namespace Utils {
    public class ExpandOverTime : MonoBehaviour {
        public float expansionPerSecond = 2f;

        void Update() {
            var localScale = transform.localScale;
            localScale *= expansionPerSecond * Time.deltaTime;
            transform.localScale = transform.localScale + localScale;
        }
    }
}