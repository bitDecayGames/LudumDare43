using System.Collections;
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
            FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.MenuSelect2);
            if (Fader != null) Fader.Fade(2f, () => {
                SceneManager.LoadScene("TitleSceneCopy");
            });
            else SceneManager.LoadScene("TitleSceneCopy");
        }

        public void Clear() {
            ScoreStats.ClearStats();
            StartCoroutine(WaitThenRefreshScene());
        }

        private IEnumerator WaitThenRefreshScene() {
            yield return new WaitForSeconds(0.25f);
            if (Fader != null) Fader.Fade(1f, () => {
                SceneManager.LoadScene("WorldMap");
            });
            else SceneManager.LoadScene("WorldMap");
        }
    }
}