using UnityEngine;

namespace Utils {
    public class FlyInOverTime : MonoBehaviour {
        public float timeToFlyIn = 1f;

        private float time;

        private Vector3 source;
        private Vector3 target;

        void Start() {
            target = transform.localPosition;
            source = new Vector3(0, -1000, 0);
            transform.localPosition = source;
        }

        void Update() {
            if (time < timeToFlyIn) {
                time += Time.deltaTime;
                var ratio = Mathf.Clamp(time / timeToFlyIn, 0f, 1f);
                transform.localPosition = (target - source) * ratio + source;
            }
        }
    }
}