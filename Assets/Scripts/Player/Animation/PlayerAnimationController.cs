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