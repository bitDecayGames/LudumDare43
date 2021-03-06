using Boo.Lang.Runtime;
using Level;
using Particles;
using Scoring;
using UnityEngine;
using Utils;
using TrashZone;

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

        private bool spinAndShrink = false;
        private float spinAndShrinkDuration = 1;
        
        private GameObject trashZone;

        private LevelBehaviour level;

        void Start() {
            level = FindObjectOfType<LevelBehaviour>();
            if (level != null) {
                level.Score(this);
            }
        }

        void Update() {
            if (spinAndShrink) {
                SpinAndShrink();
                spinAndShrinkDuration -= Time.deltaTime;
                if (spinAndShrinkDuration <= 0) {
                    SplashAndDie();
                }
            }

            if (GetComponentInChildren<Infected>() != null)
            {
                score = -10;
                transform.GetComponentInChildren<MoneyIndicator>().SetText("$" + ScoringBehaviour.IntToCurrency(score));
                transform.GetComponentInChildren<MoneyIndicator>().Text.color = Color.red;
            }
        }

        public void SetValueTip(MoneyIndicator prefab)
        {
            var money = Instantiate(prefab, transform.GetChild(0));
            if (isBonus) money.SetText("BONUS");
            else money.SetText("$" + ScoringBehaviour.IntToCurrency(score));
            money.transform.localPosition = new Vector3(0, 0, 0);
        }

        public void KillPlayerIfColliding() {
            // the cargo is in a dangerous state, kill the player if it is currently touching them
            var meColliders = GetComponentsInChildren<Collider2D>();
            if (meColliders == null) throw new RuntimeException("Tanner does this");

            foreach (Collider2D meCollider in meColliders) {
                var player = GameObject.FindWithTag("Player");
                if (player != null && meCollider.OverlapPoint(player.transform.position)) {
                    FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.VoiceGrunt);
                    EmitBloodSpatter(player.transform.position);
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
                            var childPos =transform.GetChild(0).transform.position;
                            EmitBrokenCargo(childPos);
                            EmitBadMoney(childPos);
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

            var pos = transform.GetChild(0).transform.position;
            EmitPoofs(pos);
            EmitGoodMoney(pos);
        }

        public void DestroyInWater() {
            trashZone = FindObjectOfType<TrashZoneBehaviour>().gameObject;
            spinAndShrink = true;
            
            level.RemoveScore(this);
        }

        public void DestroyOnBoat() {
            level.RemoveScore(this);
            Destroy(gameObject);
        }

        private void SpinAndShrink() {
            transform.RotateAround(GetComponentInChildren<GetMeToCenter>().transform.position, new Vector3(0,0,1), 1f);
            var childTransform = transform.GetChild(0).transform;
            childTransform.localScale = childTransform.localScale * 0.99f;
            var trashZoneDelta = trashZone.transform.position - childTransform.position;
            childTransform.position += trashZoneDelta * .03f;
        }

        private void SplashAndDie() {
            var splash = Camera.main.GetComponent<LevelStartScript>().SplashAnimation;
            var splashAnimationGameObj = Instantiate(splash);
            splashAnimationGameObj.transform.position = transform.GetChild(0).transform.position;
            Destroy(gameObject);
        }

        private void EmitBloodSpatter(Vector3 position) {
            var emitterObj = GameObject.FindWithTag("BloodEmitter");
            if (emitterObj != null) {
                var emitter = emitterObj.GetComponent<MyParticleEmitter>();
                if (emitter != null) {
                    emitter.EmitParticles(position, ParticleConstants.NUMBER_OF_BLOOD_PARTICLES);
                }
            }
        }

        private void EmitBrokenCargo(Vector3 position) {
            var emitterObj = GameObject.FindWithTag("WoodEmitter");
            if (emitterObj != null) {
                var emitter = emitterObj.GetComponent<MyParticleEmitter>();
                if (emitter != null) {
                    emitter.EmitParticles(position, ParticleConstants.NUMBER_OF_WOOD_PARTICLES);
                }
            }
        }

        private void EmitPoofs(Vector3 position) {
            var emitterObj = GameObject.FindWithTag("PoofEmitter");
            if (emitterObj != null) {
                var emitter = emitterObj.GetComponent<MyParticleEmitter>();
                if (emitter != null) {
                    emitter.EmitParticles(position, ParticleConstants.NUMBER_OF_POOF_PARTICLES);
                }
            }
        }

        private MoneyParticle EmitMoney(Vector3 position) {
            var moneyEmitterObj = GameObject.FindWithTag("MoneyEmitter");
            if (moneyEmitterObj != null) {
                var moneyEmitter = moneyEmitterObj.GetComponent<MyParticleEmitter>();
                if (moneyEmitter != null) {
                    return ((MoneyParticle) moneyEmitter.EmitParticle(position)).SetText("$" + ScoringBehaviour.IntToCurrency(Mathf.Abs(score)));
                }
            }

            return null;
        }

        public void EmitGoodMoney(Vector3 position) {
            var mon = EmitMoney(position);
            if (mon != null) mon.Green();
        }

        public void EmitBadMoney(Vector3 position) {
            var mon = EmitMoney(position);
            if (mon != null) {
                // this check for when you destroy an infected object, it should be green
                if (score > 0) mon.Red();
                else mon.Green();
            }
        }
    }
}