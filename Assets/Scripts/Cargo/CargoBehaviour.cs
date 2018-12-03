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
        public string name;
        public string description;
        public string bonusDescription;

        public string material;

        void Start() {
            var level = FindObjectOfType<LevelBehaviour>();
            if (level != null) {
                level.Score(this);
            }
        }

        public void KillPlayerIfColliding() {
            // the cargo is in a dangerous state, kill the player if it is currently touching them
            var meColliders = GetComponentsInChildren<Collider2D>();
            if (meColliders == null) throw new RuntimeException("Tanner does this");

            foreach (Collider2D meCollider in meColliders) {
                var player = GameObject.FindWithTag("Player");
                if (player != null && meCollider.OverlapPoint(player.transform.position)) {
                    FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.VoiceGrunt);
                    Destroy(player.gameObject);
                    var level = FindObjectOfType<LevelBehaviour>();
                    if (level != null) {
                        level.SetFinishReasonText("You Got Squished!");
                        level.Finished();
                    }
                }
            }
        }

        public void KillSelfIfCollidingWithAnotherCargo() {
            // check if the cargo has smashed into another cargo, kill this cargo and call LevelBehaviour.Finished()
            var meColliders = GetComponentsInChildren<Collider2D>();
            if (meColliders == null) throw new RuntimeException("Tanner does this");
            var contactFilter = new ContactFilter2D();
            contactFilter.SetLayerMask(LayerMask.GetMask("Cargo"));
            
            foreach (Collider2D meCollider in meColliders) {
                var results = new Collider2D[2];
                var count = meCollider.OverlapCollider(contactFilter, results);
                if (count > 0) {
                    foreach (Collider2D otherCollider in results) {
                        if (otherCollider != null && otherCollider.gameObject != gameObject && otherCollider.CompareTag("Cargo")) {
                            DestroyOnBoat();
                            var level = FindObjectOfType<LevelBehaviour>();
                            if (level != null) {
                                level.SetFinishReasonText("You Broke The Crane!");
                                level.Finished();
                                return;
                            }
                        }
                    }
                }
            }
        }

        public void DestroyInWater() {
            // TODO: MW spawn the splash animator
            var spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            Destroy(spriteRenderer);
            
            // Destroy(gameObject);
        }

        public void DestroyOnBoat() {
            // TODO: MW spawn dry destruction animator
            Destroy(gameObject);
        }
    }
}