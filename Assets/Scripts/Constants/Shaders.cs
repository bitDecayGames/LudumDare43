
using System;
using UnityEngine;

public class Shaders
{
    public const String GlowShader = "Custom/GlowShader";

    public static Shader GetShader(String shaderName)
    {
        Shader shader = Shader.Find(shaderName);
        if (shader == null)
        {
            throw new Exception(String.Format("Unable to find shader {0}. Make sure you have imported it in Project Settings>Graphics>Always Included Shaders", shaderName));
        }

        return shader;
    }
}