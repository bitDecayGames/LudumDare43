using System;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;

public partial class FMODMusicPlayer : MonoBehaviour
{
	public static string FMODMusicManagerGameObjectName = "FMODMusicManager";
	private static string MusicFolderInFMODBank = "Music";

	public bool PlayOnSceneStart = true;
	public SongListEnum.SongName songName;
	public PLAYBACK_STATE CurrentSongState;
	public bool TriggerSongToStart;
	public bool TriggerSongToStop;
	public ParametersListEnum.Parameters Parameter;
	public float Value;
	public bool SendParameterUpdate;
	public float CurrentVolumeReadOnly;

	private float _originalSongVolume; 
	private PLAYBACK_STATE PlaybackStateDataContainer;
	private EventInstance _eventInstance;
	private bool _destroyWhenStopped;

	public enum FMODSongState
	{
		Play = 717427940,
		Stop = 794218840,
		StopImmediate = 697355509
	}

	void Awake ()
	{
		if (AreOtherMusicPlayersAreGoing())
		{
			Destroy(gameObject);
			return;
		}
		
		_eventInstance = RuntimeManager.CreateInstance(BuildEventString(songName));
		if (PlayOnSceneStart)
		{
			RESULT result = _eventInstance.start();
			if (result != RESULT.OK)
			{
				throw new Exception(string.Format("Unable to start song: {0}", result));
			}
		}

		DontDestroyOnLoad(gameObject);
	}

	private bool AreOtherMusicPlayersAreGoing()
	{
		FMODMusicPlayer[] fmodPlayersOnScene = FindObjectsOfType<FMODMusicPlayer>();
		foreach (FMODMusicPlayer fmodMusicPlayer in fmodPlayersOnScene)
		{
			if (fmodMusicPlayer.gameObject.scene.name.Equals(Constants.Scenes.DontDestroyOnLoad))
			{
				PLAYBACK_STATE otherFmodMusicPlayerState = fmodMusicPlayer.GetAndUpdatePlaybackStateOfSong();

				if (otherFmodMusicPlayerState == PLAYBACK_STATE.STOPPING || otherFmodMusicPlayerState == PLAYBACK_STATE.STOPPED)
				{
					return false;
				}
				return true;
			}
		}
		return false;
	}
	
	private void Update()
	{
		
		CurrentSongState = GetAndUpdatePlaybackStateOfSong();
		float tmpVolume;
		RESULT result = _eventInstance.getVolume(out tmpVolume, out CurrentVolumeReadOnly);
		if (result != RESULT.OK)
		{
			Debug.Log("Unable to get volume of track: " + result);
		}

		if (TriggerSongToStart)
		{
			SetPlaybackState(FMODSongState.Play);
			TriggerSongToStart = false;
		}
		if (TriggerSongToStop)
		{
			SetPlaybackState(FMODSongState.Stop);
			TriggerSongToStop = false;
		}

		if (SendParameterUpdate)
		{
			SetParameter(Parameter, Value);
			SendParameterUpdate = false;
		}

		if (_destroyWhenStopped && CurrentSongState == PLAYBACK_STATE.STOPPED)
		{
			Destroy(gameObject);
		}
	}

	private string BuildEventString(SongListEnum.SongName songName)
	{
		return string.Format("event:/{0}/{1}", MusicFolderInFMODBank, songName.ToString());
	}
}
