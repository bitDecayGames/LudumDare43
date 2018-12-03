using UnityEngine;

namespace Utils {
    public class GetMeToCenter : MonoBehaviour {

        public void Center(SpriteRenderer sprite) {
            transform.localPosition = new Vector3(
                sprite.sprite.bounds.extents.x,
                sprite.sprite.bounds.extents.y,
                0);
        }
    }
}