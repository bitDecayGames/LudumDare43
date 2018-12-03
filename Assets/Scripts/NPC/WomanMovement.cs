using System;
using Cargo;
using FMOD.Studio;
using UnityEngine;

public class WomanMovement : MonoBehaviour
{
    private float acceleration = .005f;
    private float maxSpeed = .6f;

    public WomanFacingComponent Facing;
    public GameObject womanZone;

    private Rigidbody2D body;
    private string lastAnimation;
    
    private CircleCollider2D hitbox;

    private Vector2 targetVelocity;
    private Vector2 destination;
    private Vector2 distanceToDestination;
    private bool arived = false;
    private int maxWait = 5;
    private int minWait = 1;
    private float currentWait = 0;
    
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<CircleCollider2D>();
        PickDestination();
        MoveToDestination();
    }

    private void FixedUpdate()
    {
        if (!arived) {
            MoveToDestination();
            var absDistance = GetAbsoluteDistance();
            if (absDistance < 0.01f){
                arived = true;
                body.velocity = Vector2.zero;
                currentWait = UnityEngine.Random.Range(minWait, maxWait);
            }
        } else if (currentWait > 0) {
            currentWait -= Time.deltaTime;
        } else {
            PickDestination();
            arived = false;
        }
    }

    private void MoveToDestination(){
        var delta = destination - new Vector2(transform.position.x, transform.position.y);
        distanceToDestination = delta;
        delta.Normalize();
        body.velocity += delta * acceleration;
        if(body.velocity.magnitude > maxSpeed){
            body.velocity = body.velocity.normalized*maxSpeed;
        }
    }

    private void PickDestination(){
        var zoneBox = womanZone.GetComponent<BoxCollider2D>();
        var zBoxSizeHalf = zoneBox.size / 2;
        var zoneTransform = womanZone.transform;
        var randomX = UnityEngine.Random.Range(zoneTransform.position.x - zBoxSizeHalf.x, zoneTransform.position.x + zBoxSizeHalf.x);
        var randomY = UnityEngine.Random.Range(zoneTransform.position.y - zBoxSizeHalf.y, zoneTransform.position.y + zBoxSizeHalf.y);
        destination = new Vector2(randomX, randomY);
    }

    private float GetAbsoluteDistance(){
        return distanceToDestination.magnitude;
    }
}
