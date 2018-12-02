using UnityEngine;
using UnityEngine.UI;

namespace Utils {
    public class FadeOutOverTime : MonoBehaviour {
        public float timeToFadeOut;
        private float time;

        private MaskableGraphic img;

        void Start() {
            img = GetComponent<MaskableGraphic>();
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