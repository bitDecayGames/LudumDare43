using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    public Transform playerHands;
    private int facing;

    private void FixedUpdate()
    {
        var move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        move.Normalize();
        move.Scale(new Vector2(speed, speed));

        GetComponent<Rigidbody2D>().velocity = move;
		
        if (move.x < 0)
        {
            facing = 180;
        }
        else if (move.x > 0)
        {
            facing = 0;
        }

        if (move.y > 0)
        {
            facing = 90;
        } else if (move.y < 0)
        {
            facing = 270;
        }

        var hitbox = GetComponent<CircleCollider2D>();
        var handPos = Vector2FromAngle(facing); 
		
        handPos.Scale(new Vector2(hitbox.radius, hitbox.radius));
        handPos += hitbox.offset;
			
        playerHands.GetComponent<Transform>().localPosition = new Vector3(handPos.x, handPos.y, 0); 
		
        if (Input.GetKeyDown("space"))
        {
            playerHands.GetComponent<Grabber>().Activate(gameObject);
        }
    }
	
    public Vector2 Vector2FromAngle(float a)
    {
        a *= Mathf.Deg2Rad;
        var vec = new Vector2(Mathf.Cos(a), Mathf.Sin(a));
        vec.Normalize();
        return vec;
    }
}
