using UnityEngine;

namespace Utils {
    [ExecuteInEditMode]
    public class AlwaysRotatedTo : MonoBehaviour {

        public float Rotation;

        void Update() {
            var eulers = transform.rotation.eulerAngles;
            eulers.z = Rotation;
            transform.rotation = Quaternion.Euler(eulers);
        }
    }
}