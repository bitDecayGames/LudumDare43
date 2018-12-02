using System;
using FMOD;
using FMOD.Studio;
using UnityEngine;

public partial class FMODMusicPlayer
{
    public static FMODMusicPlayer GetDontDestroyOnLoadReference()
    {
        FMODMusicPlayer[] fmodMusicManagers = FindObjectsOfType<FMODMusicPlayer>();
        if (fmodMusicManagers.Length == 0)
        {
            throw new FmodMusicPlayerNotFoundException();
        }

        foreach (FMODMusicPlayer fmodMusicManager in fmodMusicManagers)
        {
            if (!fmodMusicManager.gameObject.scene.name.Equals(Constants.Scenes.DontDestroyOnLoad.ToString()))
            {
                continue;
            }
            return fmodMusicManager;
        }
        
        throw new Exception("Found FMOD Music Managers, but none were in DontDestroyOnLoad (only found some in local scene). " +
                            "Did you look for this reference in an Awake call?");
    }
    
    public PLAYBACK_STATE GetAndUpdatePlaybackStateOfSong()
    {
        RESULT result = _eventInstance.getPlaybackState(out PlaybackStateDataContainer);
        if (result != RESULT.OK)
        {
            throw new Exception(string.Format("Error returned when getting playback state of FMOD EventInstance: {0}", result));
        }

        return PlaybackStateDataContainer;
    }
    
    public SongListEnum.SongName GetCurrentSong()
    {
        return songName;
    }

    public EventInstance GetEventInstance()
    {
        return _eventInstance;
    }
}