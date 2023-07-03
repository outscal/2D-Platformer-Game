Shader "Water2D"
{
	Properties
	{
		_ColorOpacity("Water Tint (RGB) & Opacity (A)", 2D) = "white" {}
		_DistortionNormalMap("Normal Map", 2D) = "bump" {}
		_DistortionStrength("Distortion strength", Float) = 1.0
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "Queue"="Transparent" }
		LOD 100

		Pass
		{
			HLSLPROGRAM
			
			#pragma vertex vert
			#pragma fragment frag
			
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

			struct Attributes
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
			};

			struct Varyings
			{
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};
			
			TEXTURE2D(_ColorOpacity);
			SAMPLER(sampler_ColorOpacity);
			TEXTURE2D(_DistortionNormalMap);
			SAMPLER(sampler_DistortionNormalMap);

			CBUFFER_START(UnityPerMaterial)
				float _DistortionStrength;
				float4 _ColorOpacity_ST;
				float4 _DistortionNormalMap_ST;
				float4 _BackgroundTexture_TexelSize;
			CBUFFER_END

			Varyings vert (Attributes v)
			{
				Varyings o;
				o.vertex = TransformObjectToHClip(v.vertex);

#if !UNITY_UV_STARTS_AT_TOP
				if(_BackgroundTexture_TexelSize.y < 0)
					o.grabPos.y = 1.0 - o.grabPos.y;
#endif
				o.uv = v.uv;
				o.uv2 = v.uv2;

				return o;
			}

			half4 frag (Varyings i) : SV_Target
			{
				float2 properuv = _DistortionNormalMap_ST.zw + (i.uv2.xy * _DistortionNormalMap_ST.xy);

				float4 distordValue1 = SAMPLE_TEXTURE2D(_DistortionNormalMap, sampler_DistortionNormalMap, properuv + _Time.y);
				float4 distordValue2 = SAMPLE_TEXTURE2D(_DistortionNormalMap, sampler_DistortionNormalMap, (1.0f - properuv) + _Time.y);
				
				float3 normal1 = UnpackNormal(distordValue1);
				float3 normal2 = UnpackNormal(distordValue2);

				float3 norm = (normal1 + normal2) * 0.5f * _DistortionStrength;

				half4 coloropa = SAMPLE_TEXTURE2D(_ColorOpacity, sampler_ColorOpacity, i.uv + norm.xy * 0.1f);

				//half4 bgcolor = tex2Dproj(_BackgroundTexture, i.grabPos + float4(norm.x*0.5f, norm.y*0.5f, 0, 0));

				//col = lerp(col, float4(1, 1, 1, 1), step(0.98f, i.uv.y));

				//bgcolor.rgb = lerp(bgcolor.rgb, coloropa.rgb, coloropa.a);
				//bgcolor.rgb *= coloropa.rgb;

				return coloropa;
				//return bgcolor;
				//return float4(i.uv2.x, i.uv2.y, 0, 1);
			}
			ENDHLSL
		}
	}
}
