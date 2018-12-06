using UnityEngine;
using UnityEngine.Serialization;

public partial class WomanAnimationController : MonoBehaviour
{
    public Animator Animator;
    private Rigidbody2D rigidbody;

    public bool LastDirectionWasLeft;
    
    private void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleFreeMovement();
    }
    
    private bool IsMovingLeft()
    {
        return rigidbody.velocity.x < -.01f;
    }
    
    private bool IsMovingRight()
    {
        return rigidbody.velocity.x > .01f;
    }
}