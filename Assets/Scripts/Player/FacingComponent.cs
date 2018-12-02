using UnityEngine;

public class FacingComponent : MonoBehaviour
{
    public PlayerMovement PlayerMovementController;
    public Vector2 Facing;

    public bool IsFacingLeft()
    {
        return Facing == Vector2.left;
    }
    
    public bool IsFacingRight()
    {
        return Facing == Vector2.right;
    }
    
    public bool IsFacingUp()
    {
        return Facing == Vector2.up;
    }
    
    public bool IsFacingDown()
    {
        return Facing == Vector2.down;
    }
    
    private void Update()
    {
        if (PlayerMovementController.IsHoldingAnObject())
        {
            return;
        }
        
        if (Input.GetAxisRaw("Horizontal") < -.1f)
        {
            Facing = Vector2.left;
        }
        
        if (Input.GetAxisRaw("Horizontal") > .1f)
        {
            Facing = Vector2.right;
        }
        
        if (Input.GetAxisRaw("Vertical") > .1f)
        {
            Facing = Vector2.up;
        }
        
        if (Input.GetAxisRaw("Vertical") < -.1f)
        {
            Facing = Vector2.down;
        }
    }
}