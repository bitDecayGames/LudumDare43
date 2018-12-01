using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    public Transform playerHands;
    private int facing;
    private int anchoredDirection;
    private bool anchorAligned;

    private Rigidbody2D body;
    public Animator animator;
    private CircleCollider2D hitbox;
    public SpriteRenderer sprite;

    private Vector2 targetVelocity;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<CircleCollider2D>();
    }

    private void FixedUpdate()
    {
        var effectiveVelocity = new Vector2();

        
        var move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (move.magnitude < 0.1f)
        {
            effectiveVelocity = body.velocity;
            targetVelocity = Vector2.zero;
        }
        else
        {
            move.Normalize();
            move.Scale(new Vector2(speed, speed));
            targetVelocity = move;
            effectiveVelocity = move;
        }
        
        // set facing
        if (effectiveVelocity.x < 0)
        {
            facing = 180;

            // only flip if we are actually facing left
            sprite.flipX = anchoredDirection == facing;
        }
        else if (effectiveVelocity.x > 0)
        {
            facing = 0;
            //sprite.flipX = anchoredDirection == facing;
        }

        if (effectiveVelocity.y > 0)
        {
            facing = 90;
        } else if (effectiveVelocity.y < 0)
        {
            facing = 270;
        }

        body.velocity = targetVelocity;
        animator.SetFloat("speed", Mathf.Abs(targetVelocity.magnitude));

        var handPos = Vector2FromAngle(facing); 
		
        handPos.Scale(new Vector2(hitbox.radius, hitbox.radius));
        handPos += hitbox.offset;
			
        playerHands.GetComponent<Transform>().localPosition = new Vector3(handPos.x, handPos.y, 0); 
		
        if (Input.GetKeyDown("space"))
        {
            var attached = playerHands.GetComponent<Grabber>().Activate(gameObject);
            animator.SetBool("attached", attached);
            if (attached)
            {
                print("Setting anchor facing to: " + facing);
                anchoredDirection = facing;
            }
        }
        
        animator.SetBool("anchorFacing", anchoredDirection == facing);
    }
	
    public Vector2 Vector2FromAngle(float a)
    {
        a *= Mathf.Deg2Rad;
        var vec = new Vector2(Mathf.Cos(a), Mathf.Sin(a));
        vec.Normalize();
        return vec;
    }
}
