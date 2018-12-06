using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Obsolete("Just going to use the StatsAggregator class instead of this", true)]
public class SceneStatsData : MonoBehaviour
{
    private static String SceneStatsDataGameObjectName = "SceneStatsData";

    [HideInInspector]
    public Transform Player;
    [HideInInspector]
    public String Level;

    private void Start()
    {
        gameObject.name = SceneStatsDataGameObjectName;
        Level = SceneManager.GetActiveScene().name;
        var player = GameObject.FindWithTag("Player");
        if (player != null) {
            Player = player.transform;
        } else Player = Camera.main.transform;
    }

    public static SceneStatsData GetLocalInstance()
    {
        GameObject SceneStatsDataGameObject = GameObject.Find(SceneStatsDataGameObjectName);
        if (SceneStatsDataGameObject == null)
        {
            throw new Exception("Unable to find SceneStatsData game object. Is it in your scene?");
        }

        SceneStatsData sceneStatsData = SceneStatsDataGameObject.GetComponent<SceneStatsData>();        
        if (SceneStatsDataGameObject == null)
        {
            throw new Exception("Unable to find SceneStatsData on SceneStatsDataGameObject. Did you use the prefab?");
        }

        return sceneStatsData;
    }
}