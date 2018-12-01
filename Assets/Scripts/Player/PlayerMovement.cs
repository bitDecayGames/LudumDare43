using UnityEngine;

namespace Player {
	public class PlayerMovement : MonoBehaviour
	{
		public float speed = 5;

		private void FixedUpdate()
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
		}
	}
}
