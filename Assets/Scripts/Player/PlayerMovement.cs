using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    public Transform playerHands;
    public FacingComponent Facing;

    private bool attached;
    private int anchoredDirection;
    private bool anchorAligned;

    private Rigidbody2D body;
    private string lastAnimation;
    
    private CircleCollider2D hitbox;
    public SpriteRenderer sprite;

    private Vector2 targetVelocity;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        var handPos = Facing.DirectionVector;
		
        handPos.Scale(new Vector2(hitbox.radius, hitbox.radius));
        handPos += hitbox.offset;

        var PlayerHandsTransform = playerHands.GetComponent<Transform>();
        
        PlayerHandsTransform.localPosition = new Vector3(handPos.x, handPos.y, 0);
        PlayerHandsTransform.eulerAngles = new Vector3(PlayerHandsTransform.rotation.x,
            PlayerHandsTransform.rotation.y,
            Facing.GetFacingRotationDegrees());
        
        if (Input.GetKeyDown("space"))
        {
            attached = playerHands.GetComponent<Grabber>().Activate(gameObject);
        }
    }

    private void FixedUpdate()
    {
        var move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (move.magnitude < 0.1f)
        {
            targetVelocity = Vector2.zero;
        }
        else
        {
            move.Normalize();
            move.Scale(new Vector2(speed, speed));
            targetVelocity = move;
        }
        body.velocity = targetVelocity;
    }
	
    public Vector2 Vector2FromAngle(float a)
    {
        a *= Mathf.Deg2Rad;
        var vec = new Vector2(Mathf.Cos(a), Mathf.Sin(a));
        vec.Normalize();
        return vec;
    }

    public bool IsHoldingAnObject()
    {
//        return Input.GetKey(KeyCode.LeftShift);
        return attached;
    }
    
    void OnDestroy() {
        // TODO: MW the player has been squished, it should spawn a player animation for squishyness
    }
}
