using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Cargo;
using DropZone;
using FMOD.Studio;
using Scoring;
using Transitions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UserStats;
using Utils;

namespace Level {
    public class LevelBehaviour : MonoBehaviour {
        private ScoringBehaviour ScoreUI;
        private Text CurrentScore;

        private bool cargoHasBeenAdded;
        private bool isFinished;
        private bool currentlyDropping;

        private LevelRating rating;

        private Queue<CargoBehaviour> cargoQueue = new Queue<CargoBehaviour>();

        private List<DropZoneBehaviour> dropZones = new List<DropZoneBehaviour>();
        private int currentDropZone;

        private List<CargoBehaviour> scores = new List<CargoBehaviour>();

        private string finishReasonText = "Finished!";
        private string bonusText = "Finished!";

        void Start() {
            // if this is the cause of an error, it means you are missing the Score prefab in your scene (remember to put it under a Canvas object)
            ScoreUI = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<ScoringBehaviour>();
            ScoreUI.gameObject.SetActive(false);
            // if this is the cause of an error, it means you are missing the CurrentScore prefab in your scene (remember to put it under a Canvas object)
            CurrentScore = GameObject.FindGameObjectWithTag("CurrentScore").GetComponent<Text>();
            
//            FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.AmbientFogHorn);
        }

        public LevelBehaviour SetRating(LevelRating rating) {
            this.rating = rating;
            return this;
        }

        public LevelBehaviour AddToCargoQueue(CargoBehaviour cargo) {
            cargoHasBeenAdded = true;
            cargoQueue.Enqueue(cargo);
            return this;
        }

        public LevelBehaviour AddDropZone(DropZoneBehaviour dropZone) {
            dropZones.Add(dropZone);
            return this;
        }

        public void Score(CargoBehaviour cargo)
        {
            scores.Add(cargo);
            CurrentScore.text = "$" + ScoringBehaviour.IntToCurrency(CalculateMyScore().score);
        }
        
        public void RemoveScore(CargoBehaviour cargo) {
            scores.Remove(cargo);
            CurrentScore.text = "$" + ScoringBehaviour.IntToCurrency(CalculateMyScore().score);
        }

        public void SetFinishReasonText(string text) {
            if (!string.IsNullOrEmpty(text)) finishReasonText = text;
        }

        public void SetBonusText(string text) {
            if (!string.IsNullOrEmpty(text)) bonusText = text;
        }

        public void Finished() {
            isFinished = true;
            GameObject.Find("Player").GetComponent<PlayerMovement>().disable = true;
            CurrentScore.gameObject.AddComponent<FadeOutOverTime>().timeToFadeOut = 1f;
            FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.AmbientFogHorn);
            StartCoroutine(WaitThenShowScore());
        }

        private IEnumerator WaitThenShowScore() {
            yield return new WaitForSeconds(0.1f);
            var currentScore = CalculateMyScore();
            scores.Clear();
            var starRating = rating.StarRating(currentScore.score);
            ScoreStats.AddLevelScore(SceneManager.GetActiveScene().name, (int) starRating, currentScore.score, currentScore.hasBonus);
            ScoreUI.SetScore(finishReasonText, starRating, currentScore.score, currentScore.hasBonus, bonusText, () => {
                ScoreUI.Fader.Fade(2, () => { 
                    // go to the level select
                    SceneManager.LoadScene("WorldMap");
                });
            }, () => {
                ScoreUI.Fader.Fade(2, () => {
                    // restart this level
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                });
            }, () => {
                ScoreUI.Fader.Fade(2, () => {
                    // go to the next scene
                    var nextLevel = FindObjectOfType<NextLevel>();
                    if (nextLevel == null) throw new Exception("Could not find NextLevel component, need to add to MainCamera");
                    if (string.IsNullOrEmpty(nextLevel.NextLevelName)) SceneManager.LoadScene("CreditsScene");
                    else nextLevel.GoToNextLevel();
                });
            });
        }

        void Update() {
            if (!isFinished && cargoHasBeenAdded) {
                if (!currentlyDropping) {
                    DropNextPiece();                    
                }
            }
        }

        private void DropNextPiece()
        {
            if (cargoQueue.Count > 0) {
                var dropZone = GetNextDropZone();
                if (dropZone.IsCraneReady) {
                    currentlyDropping = true;
                    var cargo = cargoQueue.Dequeue();
                    if (cargo.GetComponent<RatMarker>() != null)
                    {
                        Instantiate(Camera.main.GetComponent<LevelStartScript>().RatPrefab);
                        currentlyDropping = false;
                        return;
                    }
                    if (dropZone != null) {
                        dropZone.SetCargo(cargo, cargo.delay, c => { currentlyDropping = false; });
                    }
                }
            } else {
                SetFinishReasonText("Shipment Complete!");
                Finished(); // finished dropping cargo, level over :D
            }
        }

        private DropZoneBehaviour GetNextDropZone() {
            if (dropZones.Count > 0) {
                var dropZone = dropZones[currentDropZone];

                if (!dropZone.IsCraneReady) {
                    currentDropZone++;
                    if (currentDropZone >= dropZones.Count) currentDropZone = 0;
                }

                return dropZone;
            }

            return null;
        }

        private MyScore CalculateMyScore() {
            var currentScore = new MyScore();
            scores.ForEach(s => {
                if (s != null) {
                    currentScore.score += s.score;
                    if (s.isBonus) {
                        currentScore.hasBonus = true;
                        SetBonusText(s.bonusDescription);
                    }
                }
            });
            return currentScore;
        }

        private struct MyScore {
            public int score;
            public bool hasBonus;

            public MyScore(int score, bool hasBonus) {
                this.score = score;
                this.hasBonus = hasBonus;
            }
        }
    }
}