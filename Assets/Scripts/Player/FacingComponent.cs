using UnityEngine;

public class FacingComponent : MonoBehaviour
{
    public PlayerMovement PlayerMovementController;
    public Vector2 DirectionVector;

    public bool IsFacingLeft()
    {
        return DirectionVector == Vector2.left;
    }
    
    public bool IsFacingRight()
    {
        return DirectionVector == Vector2.right;
    }
    
    public bool IsFacingUp()
    {
        return DirectionVector == Vector2.up;
    }
    
    public bool IsFacingDown()
    {
        return DirectionVector == Vector2.down;
    }
    
    public int GetFacingRotationDegrees()
    {
        if (IsFacingUp()) {
            return -90;
        }
        
        if (IsFacingLeft()) 
        {
            return 0;
        }
        
        if (IsFacingDown()) 
        {
            return -90;
        }
        
        if (IsFacingRight())
        {
            return 0;
        }
        return 0;
    }
    
    private void Update()
    {
        if (PlayerMovementController.IsHoldingAnObject())
        {
            return;
        }
        
        if (Input.GetAxisRaw("Horizontal") < -.1f)
        {
            DirectionVector = Vector2.left;
        }
        
        if (Input.GetAxisRaw("Horizontal") > .1f)
        {
            DirectionVector = Vector2.right;
        }
        
        if (Input.GetAxisRaw("Vertical") > .1f)
        {
            DirectionVector = Vector2.up;
        }
        
        if (Input.GetAxisRaw("Vertical") < -.1f)
        {
            DirectionVector = Vector2.down;
        }
    }
}