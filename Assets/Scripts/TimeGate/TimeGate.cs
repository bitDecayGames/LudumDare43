using UnityEngine;

public class TimeGate
{
    private float SecondsToMilliseconds = 1000f;
    
    private float _timeSinceLastReset;
    private float _intervalTimeMs;

    public TimeGate(float intervalTimeMs)
    {
        _intervalTimeMs = intervalTimeMs;
    }
    
    public void Update()
    {
        _timeSinceLastReset += Time.deltaTime*SecondsToMilliseconds;
    }

    public bool IsItTime()
    {
        if (_timeSinceLastReset >= _intervalTimeMs)
        {
            _timeSinceLastReset = 0;
            return true;
        }
        return false;
    }

    public void ChangeIntervalTime(float intervalTimeMs)
    {
        _intervalTimeMs = intervalTimeMs;
    }
    
    public void Reset()
    {
        _timeSinceLastReset = 0;
    }
}