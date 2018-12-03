using System;
using System.Collections;
using Scoring;
using UnityEngine;

namespace DebugScripts {
    public class DebugScoringBehaviour : MonoBehaviour {
        private ScoringBehaviour score;

        void Start() {
            StartCoroutine(WaitThenDo(1, () => {
                score = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<ScoringBehaviour>(); 
                score.SetScore("You Sucked!", 3, 1000, true, "BONUS DICK!", () => {
                    print("Level select");
                }, () => {
                    print("Restart");
                }, () => {
                    score.Fader.Fade(2, () => {
                        print("Next!");
                    });
                });
            }));
        }

        public IEnumerator WaitThenDo(float time, Action toDo) {
            yield return new WaitForSeconds(time);
            toDo();
        }
    }
}