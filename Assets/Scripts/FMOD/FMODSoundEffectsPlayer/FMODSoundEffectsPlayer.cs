using System;
using System.Collections.Generic;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Networking.NetworkSystem;

public class FMODSoundEffectsPlayer : MonoBehaviour
{
	// All sound effects in FMOD Studio should be located inside of a folder titled "SFX"

	public static string FMODSoundEffectManagerGameObjectName = "FMODSoundEffectManager";
	private static string SoundEffectsFolderInFMODBank = "SFX";

	private PLAYBACK_STATE PlaybackState;
	private EventInstance _eventInstance;
	private Dictionary<int, EventInstance> _sustainedEventInstances = new Dictionary<int, EventInstance>();	
	
	private bool _waitingForSoundToFinish;
	private Delegates.SignalDoneCallback _callback;

	private void Awake()
	{
		RuntimeManager.LoadBank("SFX", true);
	}

	private void Update()
	{
		if (_waitingForSoundToFinish)
		{
			PLAYBACK_STATE otherFmodMusicPlayerState = GetAndUpdatePlaybackStateOfSoundEffect();
			if (otherFmodMusicPlayerState == PLAYBACK_STATE.STOPPED)
			{
				_waitingForSoundToFinish = false;
				_callback();
			}
		}
	}

	public static FMODSoundEffectsPlayer GetLocalReferenceInScene()
	{
		GameObject fmodMusicManagerGameObject = GameObject.Find(FMODSoundEffectManagerGameObjectName);
		if (fmodMusicManagerGameObject == null)
		{
			throw new Exception("Unable to locate FMOD Sound Effects Manager GameObject");
		}
		return fmodMusicManagerGameObject.GetComponent<FMODSoundEffectsPlayer>();
	}
	
	public void PlaySoundEffect(string soundEffect)
	{
		_eventInstance = RuntimeManager.CreateInstance(BuildEventString(soundEffect));
		_eventInstance.start();
	}
	
	public void PlaySoundEffectWithCallback(string soundEffect, Delegates.SignalDoneCallback callback)
	{
		_callback = callback;
		_waitingForSoundToFinish = true;
		
		_eventInstance = RuntimeManager.CreateInstance(BuildEventString(soundEffect));
		_eventInstance.start();
	}

	public void StopSustainedSoundEffect(int soundId)
	{
		EventInstance sustainedSound = _sustainedEventInstances[soundId];
		if (sustainedSound.Equals(default(EventInstance)))
		{
			throw new Exception("Unable to find sustained sound");
		}

		RESULT result = sustainedSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		if (result != RESULT.OK)
		{
			throw new Exception("Unable to stop sustained sound " + result);
		}
	}

	public PLAYBACK_STATE GetAndUpdatePlaybackStateOfSoundEffect()
	{
		RESULT result = _eventInstance.getPlaybackState(out PlaybackState);
		if (result != RESULT.OK)
		{
			throw new Exception(string.Format("Error returned when getting playback state of FMOD EventInstance: {0}", result));
		}

		return PlaybackState;
	}
	
	private string BuildEventString(string soundEffect)
	{
		return string.Format("event:/{0}/{1}", SoundEffectsFolderInFMODBank, soundEffect);
	}
}
