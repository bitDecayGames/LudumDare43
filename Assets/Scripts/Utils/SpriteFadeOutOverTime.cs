using UnityEngine;
using UnityEngine.UI;

namespace Utils {
    public class SpriteFadeOutOverTime : AbstractFadeOutOverTime {
        private SpriteRenderer img;

        void Start() {
            img = GetComponent<SpriteRenderer>();
        }
        
        void Update() {
            _Update();
        }

        public override bool IsReady() {
            return img != null;
        }

        public override Color GetColor() {
            return img.color;
        }

        public override void SetColor(Color color) {
            img.color = color;
        }
    }
}