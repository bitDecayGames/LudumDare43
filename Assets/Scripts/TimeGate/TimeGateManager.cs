using System.Collections.Generic;
using UnityEngine;

public class TimeGateManager : MonoBehaviour
{
	private HashSet<TimeGate> _timeGates;
	
	private static TimeGateManager instance;
	public static TimeGateManager Instance
	{
		get
		{
			if (instance == null)
			{
				GameObject gameObject = new GameObject();
				instance = gameObject.AddComponent<TimeGateManager>();
				gameObject.name = "TimeGateManager";
			}

			return instance;
		}
	}

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		_timeGates = new HashSet<TimeGate>();
		DontDestroyOnLoad(gameObject);
	}

	/// <summary>
	/// Creates a new TimeGate and returns it to the caller. TimeGates begine keeping track of time as soon as they are
	/// created. When IsItTime() is called, it will check if the time provided to its constructor has passed.
	/// If the intervalTimeMs has not passed, it will return false. If so, it will return true and then reset itself.
	/// <para />
	/// Global TimeGates track time constantly.
	/// </summary>
	/// <returns></returns>
	public TimeGate GetNewTimeGate(float intervalTimeMs)
	{
		TimeGate timeGate = new TimeGate(intervalTimeMs);
		_timeGates.Add(timeGate);
		return timeGate;
	}
	

	private void Update()
	{
		foreach (TimeGate timeGate in _timeGates)
		{
			timeGate.Update();
		}
	}
}
