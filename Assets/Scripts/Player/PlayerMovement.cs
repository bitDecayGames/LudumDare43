﻿using System;
using Cargo;
using FMOD.Studio;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float pushSpeedScale = 0.5f;

    public Transform playerHands;
    public FacingComponent Facing;

    public bool disable;
    
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
        if (disable)
        {
            return;
        }
        
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
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.AmbientBirdFlap);
        }
    }

    private void FixedUpdate()
    {
        if (disable)
        {
            if (_playingSlideSound)
            {
                _slidingSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                _playingSlideSound = false;
            }

            body.velocity = Vector2.zero;
            return;
        }
        
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
                var joint = gameObject.GetComponent<FixedJoint2D>();
                if (joint == null)
                {
                    throw new Exception("Unable to find joint");
                }

                var attachedObject = joint.connectedBody.transform;
                if (joint == null)
                {
                    throw new Exception("Unable to find connected body");
                }
                
                var cargoBehaviour = attachedObject.GetComponentInParent<CargoBehaviour>();
                if (cargoBehaviour == null)
                {
                    throw new Exception("Unable to find cargoBehavior");
                }
                
                _slidingSound = FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.BuildSlideSfxStringFromMaterialType(cargoBehaviour.material));
                _playingSlideSound = true;
            }

            if (body.velocity.magnitude < .1f || !IsHoldingAnObject())
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
        _slidingSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        _playingSlideSound = false;
    }
}
