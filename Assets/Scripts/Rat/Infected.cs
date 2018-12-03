using UnityEngine;

public class Infected : MonoBehaviour
{
    private void Start()
    {
        FMODSoundEffectsPlayer.GetLocalReferenceInScene().PlaySoundEffect(Sfx.AmbientCratePoinsoned);
        gameObject.AddComponent<GlowShader>();
    }
}