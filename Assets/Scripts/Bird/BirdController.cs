using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BirdController : MonoBehaviour
{
    private Animator _animator;

    private static float TakeOffSpeed = .25f;
    private static float FlySpeed = .50f;
    
    private static int ChooseAnimationTimeGateDelayMs = 10000;
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
        _animator.Play(_animationStates.Idle.ToString());
        _chooseAnimationTimeGate = TimeGateManager.Instance.GetNewTimeGate(ChooseAnimationTimeGateDelayMs);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _splashHasHappened = true;
        }

        if (HasSplashHappened() && !_escaping)
        {
            _escaping = true;
            _animator.Play(_animationStates.Takeoff.ToString());
            _directionToFly = Random.Range(0, 361);
            _currentSpeed = TakeOffSpeed;
            if (_directionToFly > 90 && _directionToFly < 180)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
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
            transform.Translate(Vector2FromAngle(_directionToFly) * _currentSpeed * Time.deltaTime);
        }
    }

    public void GoFullSpeed()
    {
        _currentSpeed = FlySpeed;
    }
    
    private bool HasSplashHappened()
    {
        return _splashHasHappened;
    }

    public Vector2 Vector2FromAngle(float a)
    {
        a *= Mathf.Deg2Rad;
        var vec = new Vector2(Mathf.Cos(a), Mathf.Sin(a));
        vec.Normalize();
        return vec;
    }
}