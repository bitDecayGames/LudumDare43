using UnityEngine;

public class SplashController : MonoBehaviour
{
    private void Start()
    {
        Camera.main.GetComponent<LevelStartScript>().SplashHasHappened = true;
        FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.AmbientSplash);
    }
}