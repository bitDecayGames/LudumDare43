using System;
using UnityEngine;

namespace Utils {
    public class FadeToBlack : MonoBehaviour {
        private float timeToFade;
        private float time;
        private bool started;
        private Action onDone;

        private SpriteRenderer _sprite;

        private SpriteRenderer sprite {
            get {
                if (_sprite == null) _sprite = GetComponent<SpriteRenderer>();
                return _sprite;
            }
        }

        void Start() {
            SetAlpha(0);
            transform.position = new Vector3(100000, 100000, 0);
            transform.localScale = new Vector3(1, 1, 1);
            sprite.sortingOrder = 8000;
        }
        
        void Update() {
            if (started) {
                if (time < timeToFade) {
                    time += Time.deltaTime;
                    SetAlpha(Mathf.Clamp(time / timeToFade, 0f, 1f));
                } else {
                    started = false;
                    if (onDone != null) onDone();
                }
            }
        }

        public void Fade(float timeToFade, Action onDone) {
            this.timeToFade = timeToFade;
            time = 0;
            this.onDone = onDone;
            started = true;
            var cam = FindObjectOfType<Camera>();
            var camPos = cam.transform.position;
            camPos.z = 0;
            transform.position = camPos;
            transform.localScale = new Vector3(1, 1, 0) * 10000000f + new Vector3(0, 0, 1);
        }

        private void SetAlpha(float a) {
            var c = sprite.color;
            c.a = a;
            sprite.color = c;
        }
    }
}