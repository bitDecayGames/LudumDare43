using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    public Transform playerHands;
    private int facing;

    private bool attached;
    private int anchoredDirection;
    private bool anchorAligned;

    private Rigidbody2D body;
    public Animator animator;
    private string lastAnimation;
    
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
        var effectiveFacing = facing;
        
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

        var neededAnimation = "";
        // set facing
        if (effectiveVelocity.x < 0)
        {
            facing = 180;
            if (attached)
            {
                if (facing == anchoredDirection)
                {
                    neededAnimation = "moving_horizontal_push";
                    sprite.flipX = true;
                }
                else
                {
                    neededAnimation = "moving_horizontal_pull";
                    sprite.flipX = false;
                }
            }
            else
            {
                neededAnimation = "moving_horizontal_empty";
                sprite.flipX = true;
            }
        }
        else if (effectiveVelocity.x > 0)
        {
            facing = 0;

            if (attached)
            {
                if (facing == anchoredDirection)
                {
                    neededAnimation = "moving_horizontal_push";
                    sprite.flipX = false;
                }
                else
                {
                    neededAnimation = "moving_horizontal_pull";
                    sprite.flipX = true;
                }
            }
            else
            {
                neededAnimation = "moving_horizontal_empty";
                sprite.flipX = false;
            }
        }

        if (effectiveVelocity.y > 0)
        {
            facing = 90;
            
            if (attached)
            {
                if (facing == anchoredDirection)
                {
                    neededAnimation = "moving_vertical_push";
                    sprite.flipY = true;
                }
                else
                {
                    neededAnimation = "moving_vertical_pull";
                    sprite.flipY = true;
                }
            }
            else
            {
                neededAnimation = "moving_vertical_empty";
                sprite.flipY = false;
            }
        } else if (effectiveVelocity.y < 0)
        {
            facing = 270;
            
            if (attached)
            {
                if (facing == anchoredDirection)
                {
                    neededAnimation = "moving_vertical_push";
                    sprite.flipY = true;
                }
                else
                {
                    neededAnimation = "moving_vertical_pull";
                    sprite.flipY = false;
                }
            }
            else
            {
                neededAnimation = "moving_vertical_empty";
                sprite.flipY = true;
            }
        }
        
        if (effectiveVelocity.x == 0 && effectiveVelocity.y == 0)
        {
            var dirstring = "vertical";
            if (effectiveFacing % 180 == 0)
            {
                dirstring = "horizontal";
            }
            if (attached)
            {
                neededAnimation = "standing_" + dirstring + "_attached";
            }
            else
            {
                neededAnimation = "standing_" + dirstring + "_empty";
            }
        }

        if (lastAnimation != neededAnimation)
        {
            print("Changing animation to " + neededAnimation);
            print("facing: " + facing);
            
        }
        lastAnimation = neededAnimation;
        animator.Play(neededAnimation);
        body.velocity = targetVelocity;

        var handPos = Vector2FromAngle(facing); 
		
        handPos.Scale(new Vector2(hitbox.radius, hitbox.radius));
        handPos += hitbox.offset;
			
        playerHands.GetComponent<Transform>().localPosition = new Vector3(handPos.x, handPos.y, 0); 
		
        if (Input.GetKeyDown("space"))
        {
            attached = playerHands.GetComponent<Grabber>().Activate(gameObject);
            if (attached)
            {
                anchoredDirection = facing;
            }
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
