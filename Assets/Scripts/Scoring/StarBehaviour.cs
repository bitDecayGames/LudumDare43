using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Scoring {
    public class StarBehaviour : MonoBehaviour {
        public RectTransform Mask;
        public Image Filled;
        public Image Empty;

        private float _fill;

        void Start() {
            SetFill(0);
        }

        /// <summary>
        /// Fills the star based on the fill amount (from 0 to 1)
        /// </summary>
        /// <param name="fill">value from 0-1, other values are clamped</param>
        public void SetFill(float fill) {
            _fill = fill;
            var fillClamp = Mathf.Clamp(fill, 0, 1);
            var anchorMax = Mask.anchorMax;
            anchorMax.x = fillClamp;
            Mask.anchorMax = anchorMax;
        }

        /// <summary>
        /// Get the fill of the star from 0 to 1, 0 being empty, 1 being full
        /// </summary>
        /// <returns></returns>
        public float GetFill() {
            return _fill;
        }

        public void SetSprite(Sprite filled, Sprite empty) {
            Filled.sprite = filled;
            Empty.sprite = empty;
        }

        public void Flash() {
            var flash = Instantiate(Filled, transform);
            var rectTransform = flash.rectTransform;
            rectTransform.pivot = new Vector2(.5f, .5f);
            rectTransform.localPosition = new Vector3();
            var expander = flash.gameObject.AddComponent<ExpandOverTime>();
            expander.expansionPerSecond = 2f;
            var kill = flash.gameObject.AddComponent<KillAfterTime>();
            kill.timeTilDeath = .5f;
            var fade = flash.gameObject.AddComponent<FadeOutOverTime>();
            fade.timeToFadeOut = .5f;
        }
    }
}