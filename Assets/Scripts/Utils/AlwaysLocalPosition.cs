using UnityEngine;

namespace Utils {
    [ExecuteInEditMode]
    public class AlwaysLocalPosition : MonoBehaviour {

        public Vector3 LocalPosition;

        void Update() {
            if (transform.parent != null) transform.position = transform.parent.position + LocalPosition;
        }
    }
}