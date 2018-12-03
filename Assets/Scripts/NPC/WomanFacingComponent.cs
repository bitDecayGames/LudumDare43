using UnityEngine;

public class WomanFacingComponent : MonoBehaviour
{
    public Vector2 DirectionVector;
    private Rigidbody2D rigidbody;

    public void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

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
    
    private void Update()
    {
        
        // if (Input.GetAxisRaw("Horizontal") < -.1f)
        if (rigidbody.velocity.x < 0)
        {
            DirectionVector = Vector2.left;
        }
        
        // if (Input.GetAxisRaw("Horizontal") > .1f)
        if (rigidbody.velocity.x >= 0)
        {
            DirectionVector = Vector2.right;
        }
        
        // if (Input.GetAxisRaw("Vertical") > .1f)
        if (rigidbody.velocity.y >= 0)
        {
            DirectionVector = Vector2.up;
        }
        
        // if (Input.GetAxisRaw("Vertical") < -.1f)
        if (rigidbody.velocity.y < 0)
        {
            DirectionVector = Vector2.down;
        }
    }
}