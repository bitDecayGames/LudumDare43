using System;
using Scoring;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UserStats;
using Utils;

namespace WorldMap {
    public class WorldMapLocation : MonoBehaviour {
        [Header("Ignore these")]
        public WorldMapButton Button;
        public SpriteRenderer EmptyStar;
        public SpriteRenderer FullStar;
        public SpriteRenderer Star1;
        public SpriteRenderer Star2;
        public SpriteRenderer Star3;
        public TextMeshPro ScoreText;
        [Header("REQUIRED!!!")]
        public string LevelName;
        public string PreviousLevelName;

        private const float SCALED_UP = 1.3f;
        private FadeToBlack Fader;

        void Start() {
            Button.OnClick.AddListener(ClickLocation);
            Button.OnHoverEnter.AddListener(OnHoverEnter);
            Button.OnHoverExit.AddListener(OnHoverExit);
            if (string.IsNullOrEmpty(LevelName)) throw new Exception("LevelName cannot be empty or null on a WorldMapLocation");
            var scores = ScoreStats.GetLevelScores();
            var me = scores.Find(s => s.name == LevelName);
            var prev = scores.Find(s => s.name == PreviousLevelName);
            if (!string.IsNullOrEmpty(PreviousLevelName) && prev == null) {
                gameObject.SetActive(false);
            } else {
                if (me != null) {
                    SetScore(me.score);
                    SetStars(me.stars);
                } else {
                    SetScore(0);
                    SetStars(0);
                }
            }

            Fader = FindObjectOfType<FadeToBlack>();
        }

        public void ClickLocation(WorldMapButton btn) {
            if (Fader != null) Fader.Fade(2f, () => {
                SceneManager.LoadScene(LevelName);
            });
            else SceneManager.LoadScene(LevelName);
        }

        public void OnHoverEnter(WorldMapButton btn) {
            transform.localScale = new Vector3(SCALED_UP, SCALED_UP, SCALED_UP);
        }
        
        public void OnHoverExit(WorldMapButton btn) {
            transform.localScale = new Vector3(1, 1, 1);
        }

        private void SetScore(int score) {
            ScoreText.text = "$" + ScoringBehaviour.IntToCurrency(score);
        }

        private void SetStars(int stars) {
            if (stars >= 3) SetStarToFull(Star3);
            else SetStarToEmpty(Star3);
            if (stars >= 2) SetStarToFull(Star2);
            else SetStarToEmpty(Star2);
            if (stars >= 1) SetStarToFull(Star1);
            else SetStarToEmpty(Star1);
        }

        private void SetStarToEmpty(SpriteRenderer star) {
            star.sprite = EmptyStar.sprite;
        }
        
        private void SetStarToFull(SpriteRenderer star) {
            star.sprite = FullStar.sprite;
        }
    }
}