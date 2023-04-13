// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/DitheringShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_NormalTex ("Normal map", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
		_MetallicTex("Metallic Tex", 2D) = "white" {}
        _MetallicMultiplier ("Metallic", Range(0,1)) = 0.0
		_OcclusionTex("Occlusion Tex", 2D) = "white" {}
		_DitherTex("Dithering Tex", 2D) = "white" {}
		_DitherAlphaTreshold("Dithering Aplha Treshold", Range(0,1)) = 0.6
    }
    SubShader
    {
		Tags {"RenderType" = "Opaque"}
		//Blend SrcAlpha OneMinusSrcAlpha
        LOD 200

		Pass
		{
			//Cull Off
			ZWrite Off
			ZTest Always

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;
			sampler2D _DitherTex;
			float4 _DitherTex_ST;

			struct appdata 
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
			};

			struct v2f 
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
			};
	
			v2f vert(appdata v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv2 = TRANSFORM_TEX(v.uv2, _DitherTex);
				return o;
			}

			half4 _Color;
			float _DitherAlphaTreshold;

			half4 frag(v2f i) : COLOR
			{
				fixed4 c = tex2D(_MainTex, i.uv) * _Color;
				float ditherValue = tex2D(_DitherTex, i.uv2).r;
				//c = lerp(c, _Color, ditherValue);
				clip(_DitherAlphaTreshold - ditherValue); //Anything below 0 gets dicarded, not rendered
				return c;
			}
			ENDCG
		}

		//Cull Back
		//Zwrite On

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
		sampler2D _NormalTex;
		sampler2D _MetallicTex;
		sampler2D _OcclusionTex;

        struct Input
        {
            float2 uv_MainTex;
			float2 uv_NormalTex;
			float2 uv_MetallicTex;
			float2 uv_OcclusionTex;
        };

        half _Glossiness;
        half _MetallicMultiplier;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            half4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			float3 n = UnpackNormal(tex2D(_NormalTex, IN.uv_NormalTex));
			half4 m = tex2D(_MetallicTex, IN.uv_MetallicTex);
			half4 oc = tex2D(_OcclusionTex, IN.uv_OcclusionTex);

            o.Albedo = c.rgb;
			o.Normal = n;
            // Metallic and smoothness come from slider variables
            o.Metallic = m.r * _MetallicMultiplier;
            o.Smoothness = m.a * _Glossiness;
			o.Occlusion = oc.r;
			o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
