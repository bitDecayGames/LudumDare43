using UnityEngine;

namespace Cargo {
    public class CargoBehaviour : MonoBehaviour {
        private SpriteRenderer _spriteRenderer;
        public SpriteRenderer spriteRenderer {
            get {
                if (_spriteRenderer == null) {
                    _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
                }
                return _spriteRenderer;
            }
        }

        public void KillPlayerIfColliding() {
            // TODO: MW the cargo is in a dangerous state, kill the player if it is currently touching them
        }
    }
}