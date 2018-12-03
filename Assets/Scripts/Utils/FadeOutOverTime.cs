using UnityEngine;
using UnityEngine.UI;

namespace Utils {
    public class FadeOutOverTime : AbstractFadeOutOverTime {
        private MaskableGraphic img;

        void Start() {
            img = GetComponent<MaskableGraphic>();
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