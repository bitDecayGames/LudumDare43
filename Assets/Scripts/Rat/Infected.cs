using UnityEngine;

public class Infected : MonoBehaviour
{
    private void Start()
    {
        gameObject.AddComponent<GlowShader>();
    }
}