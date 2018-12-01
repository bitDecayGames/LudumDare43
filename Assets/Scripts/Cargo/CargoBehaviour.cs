using Level;
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

        public int score = 1;
        public bool isBonus;
        public float delay;

        void Start() {
            var level = FindObjectOfType<LevelBehaviour>();
            if (level != null) {
                level.Score(this);
            }
        }

        public void KillPlayerIfColliding() {
            // TODO: MW the cargo is in a dangerous state, kill the player if it is currently touching them
        }

        public void KillSelfIfCollidingWithAnotherCargo() {
            // TODO: MW the cargo has smashed into another cargo, kill this cargo and call LevelBehaviour.Finished()
        }
    }
}