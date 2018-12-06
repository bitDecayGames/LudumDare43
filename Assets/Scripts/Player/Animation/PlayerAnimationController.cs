using UnityEngine;
using UnityEngine.Serialization;

public partial class PlayerAnimationController : MonoBehaviour
{
    public GameObject PerspectivePoint;
    public PlayerMovement PlayerMovementController;
    public Animator Animator;
    public FacingComponent Facing;

    private void Update()
    {
        if (PlayerMovementController.disable)
        {
            if (Facing.IsFacingLeft())
            {
                if (IsAboveCenterPointOnMap())
                {
                    _animationToPlay = "still_left_upper";
                }
                else
                {
                    _animationToPlay = "still_left_lower";
                }
            } 
            else if (Facing.IsFacingRight())
            {
                if (IsAboveCenterPointOnMap())
                {
                    _animationToPlay = "still_right_upper";
                }
                else
                {
                    _animationToPlay = "still_right_lower";
                }
            }
            else if (Facing.IsFacingUp())
            {
                if (IsToTheRightOfCenterPointOnMap())
                {
                    _animationToPlay = "still_up_righter";
                }
                else
                {
                    _animationToPlay = "still_up_lefter";
                }
            }
            else if (Facing.IsFacingDown())
            {
                if (IsToTheRightOfCenterPointOnMap())
                {
                    _animationToPlay = "still_down_righter";
                }
                else
                {
                    _animationToPlay = "still_down_lefter";
                }
            }

            Animator.Play(_animationToPlay);
            
            return;
        }
        
        if (PlayerMovementController.IsHoldingAnObject())
        {
            HandleHoldAnimation();
        }
        else
        {
            HandleFreeMovement();
        }
    }
    
    private bool IsMovingLeft()
    {
        return Input.GetAxisRaw("Horizontal") < -.1f;
    }
    
    private bool IsMovingRight()
    {
        return Input.GetAxisRaw("Horizontal") > .1f;
    }
    
    private bool IsMovingUp()
    {
        return Input.GetAxisRaw("Vertical") > .1f;
    }
    
    private bool IsMovingDown()
    {
        return Input.GetAxisRaw("Vertical") < -.1f;
    }

    private bool IsAboveCenterPointOnMap()
    {
        return transform.position.y > PerspectivePoint.transform.position.y;
    }

    private bool IsToTheRightOfCenterPointOnMap()
    {
        return transform.position.x > PerspectivePoint.transform.position.x;
    }
}