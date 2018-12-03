using UnityEngine;

namespace DebugScripts {
    public class DebugWorldButtons : MonoBehaviour {

        public void Clicked() {
            print("Clicked");
        }

        public void HoverEnter() {
            print("Hover Enter");
        }

        public void HoverExit() {
            print("Hover Exit");
        }
    }
}