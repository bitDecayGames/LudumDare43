using UnityEngine;

namespace Utils {
    public class FlipYIfRotated : MonoBehaviour {

        private SpriteRenderer _renderer;
        private SpriteRenderer renderer {
            get {
                if (_renderer == null) _renderer = GetComponent<SpriteRenderer>();
                return _renderer;
            }
        }

        void Update() {
            var eulerZ = transform.rotation.eulerAngles.z;
            renderer.flipY = eulerZ > 90 && eulerZ < 270;
        }
    }
}