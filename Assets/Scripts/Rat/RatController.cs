using System;
using UnityEngine;

public class RatController : MonoBehaviour
{
    public static float RatSpeed = .5f;

    private Animator _animator;
    
    public GameObject TargetCargo;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();

        
        var infectedComponent = FindObjectOfType<Infectable>();

        if (infectedComponent == null)
        {
            throw new Exception("Rat could not find target cargo");
        }
        
        TargetCargo = infectedComponent.gameObject;

        var spawnPoint = GameObject.Find("RatSpawn");
        if (spawnPoint == null)
        {
            throw new Exception("Rat could not find spawn point");
        }

        transform.position = spawnPoint.transform.position;
    }

    private void Update()
    {
        if (Math.Abs(transform.position.y - TargetCargo.transform.position.y) > .1f)
        {
            transform.Translate(Vector2.up * RatSpeed * Time.deltaTime);
        }
        else
        {
            if (Vector2.Distance(transform.position, TargetCargo.transform.position) > .1f)
            {
                _animator.Play("RunRight");
                transform.position = Vector2.MoveTowards(transform.position, TargetCargo.transform.position, RatSpeed * Time.deltaTime);
            }
            else
            {
                Destroy(TargetCargo.GetComponent<Infectable>());
                TargetCargo.AddComponent<Infected>();
                Destroy(gameObject);
            }
        }
    }
}