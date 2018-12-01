using UnityEngine;

namespace Utils {
    public class FadeInOnTrigger : MonoBehaviour {
        public float timeToFadeIn = 1f;
        private float time;

        private SpriteRenderer _sprite;

        private SpriteRenderer sprite {
            get {
                if (_sprite == null) _sprite = GetComponent<SpriteRenderer>();
                return _sprite;
            }
        }

        void Start() {
            time = timeToFadeIn;
        }
        
        void Update() {
            if (time < timeToFadeIn) {
                time += Time.deltaTime;
                SetAlpha(Mathf.Clamp(time / timeToFadeIn, 0f, 1f));
            }
        }

        public void FadeIn() {
            Debug.Log("Start fade in");
            time = 0;
        }

        private void SetAlpha(float a) {
            var c = sprite.color;
            c.a = a;
            sprite.color = c;
        }
    }
}