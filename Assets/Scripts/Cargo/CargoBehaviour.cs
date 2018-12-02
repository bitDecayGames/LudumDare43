using Boo.Lang.Runtime;
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
            // TODO: MW check if the cargo has smashed into another cargo, kill this cargo and call LevelBehaviour.Finished()
            var meCollider = GetComponent<Collider2D>();
            if (meCollider == null) throw new RuntimeException("Tanner does this");
            var contactFilter = new ContactFilter2D();
            contactFilter.SetLayerMask(LayerMask.GetMask("Cargo"));
            var results = new Collider2D[3];
            var count = meCollider.OverlapCollider(contactFilter, results);
            if (count > 0) {
                foreach (Collider2D otherCollider in results) {
                    if (otherCollider != null && otherCollider.gameObject != gameObject && otherCollider.CompareTag("Cargo")) {
                        DestroyOnBoat();
                        var level = FindObjectOfType<LevelBehaviour>();
                        if (level != null) {
                            Debug.Log("Hey! We collided with something!");
                            level.Finished();
                            return;
                        }
                    }
                }
            }
        }

        public void DestroyInWater() {
            // TODO: MW spawn the splash animator
            Destroy(gameObject);
        }

        public void DestroyOnBoat() {
            // TODO: MW spawn dry destruction animator
            Destroy(gameObject);
        }
    }
}