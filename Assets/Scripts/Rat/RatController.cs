using System;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

public class RatController : MonoBehaviour
{
    public static float RatSpeed = .5f;

    private Animator _animator;
    
    public GameObject TargetCargo;
    
    private void Start()
    {
        FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.VoiceRatSqueak);
        
        _animator = GetComponent<Animator>();
        
        var infectableComponents = FindObjectsOfType<Infectable>();
        if (infectableComponents == null)
        {
            throw new Exception("Rat could not find target cargo");
        }
        
        var indexOfCrateToInfect = Random.Range(0, infectableComponents.Length);
        var crateToInfect = infectableComponents[indexOfCrateToInfect].gameObject;
        TargetCargo = crateToInfect.GetComponentInChildren<GetMeToCenter>().gameObject;

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
            _animator.Play("RunUp");
            transform.Translate(Vector2.up * RatSpeed * Time.deltaTime);
        }
        else
        {
            if (Vector2.Distance(transform.position, TargetCargo.transform.position) > .1f)
            {
                var movementVector = Vector2.MoveTowards(transform.position, TargetCargo.transform.position, RatSpeed * Time.deltaTime);
                transform.position = movementVector;
                
                if (transform.position.x - TargetCargo.transform.position.x > 0)
                {
                    _animator.Play("RunLeft");
                }
                else
                {
                    _animator.Play("RunRight");
                }
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