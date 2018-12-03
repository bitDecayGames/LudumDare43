using System;
using UnityEngine;

public class GlowShader : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer == null)
        {
            throw new Exception(String.Format("{0}: Unable to act on sprite: Object is missing SpriteRenderer", GetType().Name));
        }
        _spriteRenderer.material.shader = Shaders.GetShader(Shaders.GlowShader);
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {   
        Graphics.Blit(src, dest);
    }
}