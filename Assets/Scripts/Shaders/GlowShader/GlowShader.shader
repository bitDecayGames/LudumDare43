Shader "Custom/GlowShader"
{
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
		Blend One OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _ PIXELSNAP_ON
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
				float2 texcoord  : TEXCOORD0;
			};
			
			fixed4 _Color;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif

				return OUT;
			}

			sampler2D _MainTex;
			sampler2D _AlphaTex;
			float _AlphaSplitEnabled;

			fixed4 SampleSpriteTexture (float2 uv)
			{
				fixed4 color = tex2D (_MainTex, uv);

                #if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
				if (_AlphaSplitEnabled)
					color.a = tex2D (_AlphaTex, uv).r;
                #endif //UNITY_TEXTURE_ALPHASPLIT_ALLOWED

				return color;
			}
			
			float GetValueBetweenOriginalAndZero(float originalRbgValue, float timeValue)
			{
			    // Sin function returns value between -1 and 1
			    // divide this by 2 to return between -.5 and .5
			    // add .5 to make the effective range between 0 and 1
			    float percentageOfColorToSubtract = (sin(timeValue)/2 + .5f) * .6f;
			    

			    return originalRbgValue - percentageOfColorToSubtract*originalRbgValue;
			}
			
			float GetValueBetweenOriginalAndPointFive(float originalRbgValue, float timeValue)
			{
			    // Sin function returns value between -1 and 1
			    // divide this by 2 to return between -.5 and .5
			    // add .5 to make the effective range between 0 and 1
			    float percentageOfColorMovement = (sin(timeValue)/2 + .5f) * .6f;
			    
			    // Calculate the amount of RGB color required to make the provided value 1
			    float rangeOfColorToMove = .5f-originalRbgValue;

			    return originalRbgValue + rangeOfColorToMove*percentageOfColorMovement;
			}

			fixed4 frag(v2f IN) : SV_Target
			{
			    // purple rgb: 128,0,128
			
				fixed4 c = SampleSpriteTexture (IN.texcoord) * IN.color;
				
				c.r = GetValueBetweenOriginalAndPointFive(c.r, _Time[2]);
				c.g = GetValueBetweenOriginalAndZero(c.g, _Time[2]);
				c.b = GetValueBetweenOriginalAndPointFive(c.b, _Time[2]);
				
				// This needs to be at the very end to properly manage the alpha
				c.rgb *= c.a;
				
				return c;
			}
		ENDCG
		}
	}
}