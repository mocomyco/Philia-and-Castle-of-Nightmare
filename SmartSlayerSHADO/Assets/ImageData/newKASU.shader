Shader "Custom/newKASU" {
	Properties{
		_Color("Color"       , Color) = (1, 1, 1, 1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
	_Glossiness("Smoothness"  , Range(0, 1)) = 0.5
		_Metallic("Metallic"    , Range(0, 1)) = 0.0
		_Cutoff("Cutoff"      , Range(0, 1)) = 0.5
		_OcclusionMap("OcclusionMap", 2D) = "white" {}
	_OcclusionStrength("Occlusion Strength", Float) = 1
	}

		SubShader{
		Tags{
		"Queue" = "AlphaTest"
		"RenderType" = "TransparentCutout"
	}

		LOD 200

		Cull Off

		CGPROGRAM
#pragma target 3.0
#pragma surface surf Standard fullforwardshadows alphatest:_Cutoff

		fixed4 _Color;
	sampler2D _MainTex;
	sampler2D _OcclusionMap; //Occlution
	half _Glossiness;
	half _Metallic;
	half _OcclusionStrength;//Occlution
	struct Input {
		float2 uv_MainTex;
	};

	void surf(Input IN, inout SurfaceOutputStandard o) {
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;

		o.Albedo = c.rgb;
		o.Metallic = _Metallic;
		o.Smoothness = _Glossiness;
		o.Occlusion = tex2D(_OcclusionMap, IN.uv_MainTex) * _OcclusionStrength;
		o.Alpha = c.a;
	}
	ENDCG
	}

		FallBack "Transparent/Cutout/Diffuse"
}