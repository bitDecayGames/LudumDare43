using System.Collections;
using System.Collections.Generic;
using Cargo;
using DropZone;
using Scoring;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level {
    public class LevelBehaviour : MonoBehaviour {
        public ScoringBehaviour ScoreUI;

        private bool cargoHasBeenAdded;
        private bool isFinished;
        private bool currentlyDropping;

        private LevelRating rating;

        private Queue<CargoBehaviour> cargoQueue = new Queue<CargoBehaviour>();

        private List<DropZoneBehaviour> dropZones = new List<DropZoneBehaviour>();
        private int currentDropZone;

        private List<CargoBehaviour> scores = new List<CargoBehaviour>();

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

        public void Score(CargoBehaviour cargo) {
            scores.Add(cargo);
        }

        public void Finished() {
            isFinished = true;
            StartCoroutine(WaitThenShowScore());
        }

        private IEnumerator WaitThenShowScore() {
            yield return new WaitForSeconds(0.1f);
            var currentScore = 0;
            var hasBonus = false;
            scores.ForEach(s => {
                if (s != null) {
                    currentScore += s.score;
                    if (s.isBonus) hasBonus = true;
                }
            });
            scores.Clear();
            ScoreUI.SetScore(rating.StarRating(currentScore), currentScore, hasBonus, null, () => {
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
    }
}