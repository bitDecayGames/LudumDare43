using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils {
    public class WaitThenGo : MonoBehaviour {
        public string Go;
        public float Wait;
        private FadeToBlack Fader;

        void Start() {
            Fader = FindObjectOfType<FadeToBlack>();
            if (Wait >= 0 && !string.IsNullOrEmpty(Go)) StartCoroutine(Apply());
            else throw new Exception("Go cannot be empty and Wait must be >= than 0");
        }

        private IEnumerator Apply() {
            yield return new WaitForSeconds(Wait);
            if (Fader != null) Fader.Fade(1f, () => SceneManager.LoadScene(Go));
            else SceneManager.LoadScene(Go);
        }
    }
}