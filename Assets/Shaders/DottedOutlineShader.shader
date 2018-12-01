// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'
Shader "Custom/DottedOutlineShader" {
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        _DashOffset ("_DashOffset", Float) = 0
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
            
            static const float2 startPoint = float2(-100, -200);
            static const float dashLength = 20;
            static const float lineThickness = .03;

            fixed4 frag(v2f IN) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, IN.texcoord) * IN.color;
                c.a = 0;
                if (IN.texcoord.x < lineThickness || IN.texcoord.x > 1 - lineThickness || IN.texcoord.y < lineThickness || IN.texcoord.y > 1 - lineThickness){
                    float dist = (distance(IN.texcoord, startPoint) * dashLength + _DashOffset) % 2;
                    if (dist < 1){
                        c.a = 0.5;
                    }
                }
                c.rgb *= c.a;
                return c;
            }
        ENDCG
        }
    }
}




