using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Transitions {
    public class NextLevel : MonoBehaviour {

        public string NextLevelName;

        public void GoToNextLevel() {
            if (!string.IsNullOrEmpty(NextLevelName)) SceneManager.LoadScene(NextLevelName);
            else throw new Exception("Next level name must be set in order to go to next level (Probably on the MainCamera)");
        }

    }
}