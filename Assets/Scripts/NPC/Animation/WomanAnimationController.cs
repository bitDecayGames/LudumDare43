using UnityEngine;
using UnityEngine.Serialization;

public partial class WomanAnimationController : MonoBehaviour
{
    public GameObject PerspectivePoint;
    public Animator Animator;
    public WomanFacingComponent Facing;
    private Rigidbody2D rigidbody;

    private void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleFreeMovement();
    }
    
    private bool IsMovingLeft()
    {
        return rigidbody.velocity.x < -.1f;
    }
    
    private bool IsMovingRight()
    {
        return rigidbody.velocity.x > .1f;
    }
    
    private bool IsMovingUp()
    {
        return rigidbody.velocity.y > .1f;
    }
    
    private bool IsMovingDown()
    {
        return rigidbody.velocity.y < -.1f;
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