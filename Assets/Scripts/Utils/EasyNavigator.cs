using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils {
    public class EasyNavigator : MonoBehaviour {

        private FadeToBlack Fader;

        void Start() {
            Fader = FindObjectOfType<FadeToBlack>();
        }
        
        public void Go(string sceneName) {
            if (Fader != null) Fader.Fade(2, () => SceneManager.LoadScene(sceneName));
            else SceneManager.LoadScene(sceneName);
        }
    }
}