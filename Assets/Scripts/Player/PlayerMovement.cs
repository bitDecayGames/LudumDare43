using System;
using FMOD.Studio;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float pushSpeedScale = 0.5f;

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

    private bool _playingSlideSound;
    private EventInstance _slidingSound;
    
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
        Vector2 movementVector = new Vector2();
        if (!IsHoldingAnObject())
        {
            movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));    
        }
        else
        {
            if (Facing.IsFacingLeft() || Facing.IsFacingRight())
            {
                movementVector.x = Input.GetAxisRaw("Horizontal");
            }
            else
            {
                movementVector.y = Input.GetAxisRaw("Vertical");
            }
        }
        
        if (movementVector.magnitude < 0.1f)
        {
            if (_playingSlideSound)
            {
                _slidingSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                _playingSlideSound = false;
            }
            
            targetVelocity = Vector2.zero;
        }
        else
        {
            if (!_playingSlideSound && IsHoldingAnObject())
            {
                _slidingSound = FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.SlideWood);
                _playingSlideSound = true;
            }

            if (body.velocity.magnitude < .1f)
            {
                _slidingSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                _playingSlideSound = false;
            }
            
            movementVector.Normalize();
            movementVector.Scale(new Vector2(speed, speed));
            if (IsHoldingAnObject())
            {
                movementVector.Scale(new Vector2(pushSpeedScale, pushSpeedScale));
            }
            targetVelocity = movementVector;
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
        return attached;
    }

    public void PlayStepSound()
    {
        FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.StepWood);
    }
    
    void OnDestroy() {
        // TODO: MW the player has been squished, it should spawn a player animation for squishyness
    }
}
