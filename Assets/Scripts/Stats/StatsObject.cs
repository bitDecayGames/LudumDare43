using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatsObject
{
    public bool GameCompleted;
    public string Id;
    public string[] KeysPressed;
    public string LevelWhenQuit;
    public LevelSummaryObject[] LevelsCleared;
    public Vector2 LocationOnQuit;
    public string Platform;
    public float TimePlayedSeconds;
}