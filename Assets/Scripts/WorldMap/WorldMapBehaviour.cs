using Scoring;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UserStats;
using Utils;

namespace WorldMap {
    public class WorldMapBehaviour : MonoBehaviour {

        public Text TotalStarText;
        public Text TotalScoreText;

        public int TotalPossibleStars;

        private FadeToBlack Fader;

        void Start() {
            Fader = FindObjectOfType<FadeToBlack>();
            TotalStarText.text = ScoreStats.GetTotalStars() + "/" + TotalPossibleStars;
            TotalScoreText.text = ScoringBehaviour.IntToCurrency(ScoreStats.GetTotalScore());
        }
        
        public void Back() {
            if (Fader != null) Fader.Fade(2f, () => {
                SceneManager.LoadScene("TitleScreen");
            });
            else SceneManager.LoadScene("TitleScreen");
        }
    }
}