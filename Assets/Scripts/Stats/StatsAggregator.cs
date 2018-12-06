using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UserStats;

[Serializable]
public class StatsAggregator : MonoBehaviour
{
    private RestApiAccessor _rest;
    private Transform _playerOrCamera;
    
    private HashSet<string> KeySet = new HashSet<string>();

	
    void Start() {
        _rest = gameObject.AddComponent<RestApiAccessor>();
        var player = GameObject.FindWithTag("Player");
        if (player == null) {
            var cam = Camera.main;
            if (cam == null) throw new Exception("Couldn't find player OR camera for stat tracking");
            _playerOrCamera = cam.transform;
        } else _playerOrCamera = player.transform;

        Save();
    }

    private void OnDestroy() {
         Save();
    }

    private void OnApplicationQuit() {
        Save();
    }

    private void OnApplicationFocus(bool hasFocus) {
        Save();
    }

    private void Update() {
        ScoreStats.TimePlayedTracker += Time.deltaTime;
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
	
    private void Save() {
        if (gameObject != null && gameObject.activeSelf && gameObject.activeInHierarchy) {
            ScoreStats.TimePlayed += ScoreStats.TimePlayedTracker;
            ScoreStats.TimePlayedTracker = 0;
            StatsObject statsObject = new StatsObject {
                GameCompleted = ScoreStats.GameCompleted,
                Id = ScoreStats.SessionID,
                KeysPressed = KeySet.ToArray(),
                LevelWhenQuit = SceneManager.GetActiveScene().name,
                LevelsCleared = ScoreStats.GetLevelScores()
                    .ConvertAll(score => {
                        var tannersScore = new LevelSummaryObject();
                        tannersScore.StarCount = score.stars;
                        tannersScore.BonusAquired = score.bonus;
                        tannersScore.LevelName = score.name;
                        return tannersScore;
                    })
                    .ToArray(),
                LocationOnQuit = _playerOrCamera != null ? _playerOrCamera.position : new Vector3(0, 0, 0),
                Platform = Application.platform.ToString(),
                TimePlayedSeconds = ScoreStats.TimePlayed
            };
            _rest.SendStats(statsObject);
        }
    }
}