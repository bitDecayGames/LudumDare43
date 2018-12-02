using TMPro;
using UnityEngine;

namespace Scoring {
    public class MoneyIndicator : MonoBehaviour {
        public TextMeshPro Text;

        public void SetText(string value) {
            Text.text = value;
        }
    }
}