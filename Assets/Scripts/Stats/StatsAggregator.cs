using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class StatsAggregator : MonoBehaviour
{
    private static StatsAggregator instance;
	
    public static StatsAggregator Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameObject = new GameObject();
                instance = gameObject.AddComponent<StatsAggregator>();
                gameObject.name = "StatsAggregator";
            }

            return instance;
        }
    }

    private SceneStatsData _sceneStatsData;
	
    public HashSet<string> KeySet = new HashSet<string>();
    public string SessionId;
    public bool GameCompleted;
    public List<LevelSummaryObject> LevelSummaryObjects = new List<LevelSummaryObject>();
	
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        gameObject.AddComponent<RestApiAccessor>();
        SessionId = Guid.NewGuid().ToString();

        var summaryObject = new LevelSummaryObject();
        summaryObject.BonusAquired = true;
        summaryObject.LevelName = "1";
        summaryObject.StarCount = 2;
        
        LevelSummaryObjects.Add(summaryObject);
        
        DontDestroyOnLoad(gameObject);
    }

    private SceneStatsData GetSceneStatsData()
    {
        if (_sceneStatsData != null)
        {
            return _sceneStatsData;
        }
        _sceneStatsData = SceneStatsData.GetLocalInstance();
        return _sceneStatsData;
    }
	
    private void Update()
    {
		
        foreach (char c in Input.inputString)
        {
            try
            {
                if (Input.GetKeyDown(c.ToString()))
                {
                    KeySet.Add(c.ToString());
                }
            } 
            // We don't care if this call fails
            catch
            {
						
            }
        }
    }
	
    private void OnApplicationQuit()
    {
        StatsObject statsObject = new StatsObject
        {
            GameCompleted = GameCompleted,
            Id = SessionId,
            KeysPressed = KeySet.ToArray(),
            LevelWhenQuit = GetSceneStatsData().Level,
            LevelsCleared = LevelSummaryObjects.ToArray(),
            LocationOnQuit = GetSceneStatsData().Player.transform.position,
            Platform = Application.platform.ToString(),
            TimePlayedSeconds = Time.time,
        };
	
        
        Debug.Log("Stats: ");
        Debug.Log(JsonUtility.ToJson(statsObject));
        GetComponent<RestApiAccessor>().SendStats(statsObject);
    }
}