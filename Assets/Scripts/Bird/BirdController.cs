using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BirdController : MonoBehaviour
{
    private Animator _animator;

    private LevelStartScript _levelStartScript;
    
    private static float TakeOffSpeed = .25f;
    private static float FlySpeed = .50f;
    
    private static int ChooseAnimationTimeGateDelayMs = 8000;
    private TimeGate _chooseAnimationTimeGate;

    private float _currentSpeed;
    private bool _splashHasHappened;
    private int _directionToFly;
    private bool _escaping;

    private enum _animationStates
    {
        None,
        Eat,
        Fly,
        Idle,
        Takeoff
    }
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            throw new Exception("Unable to find Animator");
        }
    }

    private void Start()
    {
        var variance = Random.Range(.7f, 1f);
        _chooseAnimationTimeGate = TimeGateManager.Instance.GetNewTimeGate(ChooseAnimationTimeGateDelayMs * variance);
        var levelStartScript = Camera.main.GetComponent<LevelStartScript>();
        if (levelStartScript == null)
        {
            throw new Exception("Unable to find LevelStartScript");
        }

        _levelStartScript = levelStartScript;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _splashHasHappened = true;
        }
        
        if (!_escaping && _levelStartScript.SplashHasHappened)
        {
            _escaping = true;
            _animator.Play(_animationStates.Takeoff.ToString());
            _directionToFly = Random.Range(0, 361);
            _currentSpeed = TakeOffSpeed;
            FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.AmbientBirdFlap);
        }

        if (!_escaping)
        {
            if (_chooseAnimationTimeGate.IsItTime())
            {
                String animationToPlay = _animationStates.None.ToString();
                switch (Random.Range(0, 2))
                {
                    case 0:
                        animationToPlay = _animationStates.Idle.ToString();
                        break;
                    case 1:
                        animationToPlay = _animationStates.Eat.ToString();
                        break;
                }

                _animator.Play(animationToPlay);
            }
        }
        else
        {
            var flyVector = Vector2FromAngle(_directionToFly);
            if (flyVector.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
                
            transform.Translate(flyVector * _currentSpeed * Time.deltaTime);
        }
    }

    public void GoFullSpeed()
    {
        _currentSpeed = FlySpeed;
    }

    public Vector2 Vector2FromAngle(float a)
    {
        a *= Mathf.Deg2Rad;
        var vec = new Vector2(Mathf.Cos(a), Mathf.Sin(a));
        vec.Normalize();
        return vec;
    }
}