// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
Shader "Custom/ShadowShader" {
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }

    SubShader
    {
        Tags
        { 
            "Queue"="Transparent" 
            "IgnoreProjector"="True" 
            "RenderType"="Transparent" 
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Fog { Mode Off }
        Blend One OneMinusSrcAlpha

        Pass
        {
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile DUMMY PIXELSNAP_ON
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                half2 texcoord  : TEXCOORD0;
            };

            fixed4 _Color;
            float _DashOffset;

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.color = _Color;
                #ifdef PIXELSNAP_ON
                OUT.vertex = UnityPixelSnap (OUT.vertex);
                #endif

                return OUT;
            }

            sampler2D _MainTex;
            
            static const int samples = 5;
            static const float blurryness = .02;
            
            fixed4 blur(fixed4 orig, float2 texcoord){
            
                float a = orig.a;
                int sampleCount = 1;
                float2 coord = float2(0, 0);
                for (int x = -samples; x < samples; x++){
                    float xCoord = texcoord.x + x * blurryness;
                    if (xCoord >= 0 && xCoord <= 1){
                        coord.x = xCoord;
                        for (int y = -samples; y < samples; y++){
                            float yCoord = texcoord.y + y * blurryness;
                            if (yCoord >= 0 && yCoord <= 1) {
                                coord.y = yCoord; 
                                a += tex2D(_MainTex, coord).a;
                                sampleCount++;
                            }
                        }
                    }
                }
                orig.a = a / sampleCount * .5;
                
                return orig;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, IN.texcoord) * IN.color;
                c.r = 0;
                c.g = 0;
                c.b = 0;
                c = blur(c, IN.texcoord);
                c.rgb *= c.a;
                return c;
            }
        ENDCG
        }
    }
}




