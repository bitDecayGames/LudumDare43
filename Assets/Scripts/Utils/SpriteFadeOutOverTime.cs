using UnityEngine;
using UnityEngine.UI;

namespace Utils {
    public class SpriteFadeOutOverTime : MonoBehaviour {
        public float timeToFadeOut;
        private float time;

        private SpriteRenderer img;

        void Start() {
            img = GetComponent<SpriteRenderer>();
        }
        
        void Update() {
            if (img != null && time < timeToFadeOut) {
                time += Time.deltaTime;
                var c = img.color;
                c.a = Mathf.Clamp(1 - time / timeToFadeOut, 0, 1);
                img.color = c;
            }
        }
    }
}