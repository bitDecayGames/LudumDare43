using System.Collections;
using System.Collections.Generic;
using Cargo;
using DropZone;
using Scoring;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

        void Start() {
            // if this is the cause of an error, it means you are missing the Score prefab in your scene (remember to put it under a Canvas object)
            ScoreUI = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<ScoringBehaviour>();
            ScoreUI.gameObject.SetActive(false);
            // if this is the cause of an error, it means you are missing the CurrentScore prefab in your scene (remember to put it under a Canvas object)
            CurrentScore = GameObject.FindGameObjectWithTag("CurrentScore").GetComponent<Text>();
        }

        public LevelBehaviour SetRating(LevelRating rating) {
            this.rating = rating;
            return this;
        }

        public LevelBehaviour AddToCargoQueue(CargoBehaviour cargo) {
            cargoHasBeenAdded = true;
            cargoQueue.Enqueue(cargo);
//            print("piece added to queue. New Len: " + cargoQueue.Count);
            return this;
        }

        public LevelBehaviour AddDropZone(DropZoneBehaviour dropZone) {
            dropZones.Add(dropZone);
            return this;
        }

        public void Score(CargoBehaviour cargo) {
            scores.Add(cargo);
            CurrentScore.text = "$" + ScoringBehaviour.IntToCurrency(CalculateMyScore().score);
        }

        public void Finished() {
            isFinished = true;
            CurrentScore.gameObject.AddComponent<FadeOutOverTime>().timeToFadeOut = 1f;
            StartCoroutine(WaitThenShowScore());
        }

        private IEnumerator WaitThenShowScore() {
            yield return new WaitForSeconds(0.1f);
            var currentScore = CalculateMyScore();
            scores.Clear();
            ScoreUI.SetScore(rating.StarRating(currentScore.score), currentScore.score, currentScore.hasBonus, null, () => {
                // TODO: MW this might be bad?
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }, null); // TODO: MW do something with the actions at the end there
        }

        void Update() {
            if (!isFinished && cargoHasBeenAdded) {
                if (!currentlyDropping) {
                    DropNextPiece();                    
                }
            }
        }

        private void DropNextPiece() {
            if (cargoQueue.Count > 0) {
                currentlyDropping = true;
                var cargo = cargoQueue.Dequeue();
                var dropZone = GetNextDropZone();
                if (dropZone != null) {
                    dropZone.SetCargo(cargo, cargo.delay, c => { currentlyDropping = false; });
                }
            } else {
                Finished(); // finished dropping cargo, level over :D
            }
        }

        private DropZoneBehaviour GetNextDropZone() {
            if (dropZones.Count > 0) {
                var dropZone = dropZones[currentDropZone];

                currentDropZone++;
                if (currentDropZone >= dropZones.Count) currentDropZone = 0;

                return dropZone;
            }

            return null;
        }

        private MyScore CalculateMyScore() {
            var currentScore = new MyScore();
            scores.ForEach(s => {
                if (s != null) {
                    currentScore.score += s.score;
                    if (s.isBonus) currentScore.hasBonus = true;
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