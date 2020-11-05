// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

///--------------------------------------------------------------------------------------
// File: StencilMask.shader
//
// Developed by Reallusion Developer team.
//
// Copyright c 2014 Reallusion Inc. All rights reserved.
//--------------------------------------------------------------------------------------
Shader "RL/Stencil/StencilMask" 
{ 
    Properties 
    {   
        _Color ("Main Color", Color) = (1, 1, 1, 1)
        _MaskID( "Mask ID", float ) = 1
         _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
         _AlphaMap ("Base (RGB) Trans (A)", 2D) = "white" {}
    }
   
	SubShader 
	{
		//Tags { "RenderType"="Opaque" "Queue"="Geometry-100"}
		Tags { "Queue"="Transparent"}
		//ColorMask 0
		lighting off
		ZWrite off
		//ZTest always
		Stencil 
		{
			Ref [_MaskID]
			Comp always
			Pass replace
		}
			Pass {
		Name "Caster"
		Tags { "LightMode" = "ShadowCaster" }
		Offset 1, 1
		
		Fog {Mode Off}
		ZWrite on ZTest always Cull Off

CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile_shadowcaster
#include "UnityCG.cginc"

struct v2f { 
	V2F_SHADOW_CASTER;
	float2  uv : TEXCOORD1;
};

uniform float4 _AlphaMap_ST;

v2f vert( appdata_base v )
{
	v2f o;
	TRANSFER_SHADOW_CASTER(o)
	o.uv = TRANSFORM_TEX(v.texcoord, _AlphaMap);
	return o;
}

uniform sampler2D _AlphaMap;
uniform fixed _Cutoff;
uniform fixed4 _Color;

float4 frag( v2f i ) : SV_Target
{
    if ( _Color.a == 0 )
    {
        clip(-1);
    }
	SHADOW_CASTER_FRAGMENT(i);
	
}
ENDCG

	}
	
	// Pass to render object as a shadow collector
	Pass {
		Name "ShadowCollector"
		Tags { "LightMode" = "ShadowCollector" }
		
		Fog {Mode Off}
		ZWrite on ZTest LEqual

CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile_shadowcollector

#define SHADOW_COLLECTOR_PASS
#include "UnityCG.cginc"

struct v2f {
	V2F_SHADOW_COLLECTOR;
	float2  uv : TEXCOORD5;
};

uniform float4 _AlphaMap_ST;

v2f vert (appdata_base v)
{
	v2f o;
	TRANSFER_SHADOW_COLLECTOR(o)
	o.uv = TRANSFORM_TEX(v.texcoord, _AlphaMap);
	return o;
}

uniform sampler2D _AlphaMap;
uniform fixed _Cutoff;
uniform fixed4 _Color;

fixed4 frag (v2f i) : SV_Target
{
 if ( _Color.a == 0 )
    {
        clip(-1);
    }
	SHADOW_COLLECTOR_FRAGMENT(i)
}
ENDCG

	}
		Pass
		{
		Blend SrcAlpha OneMinusSrcAlpha 
		    CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			sampler2D _MainTex;
            sampler2D _AlphaMap;
			struct appdata 
			{
				float4 vertex : POSITION;
			};
			
			struct v2f 
			{
				float4 pos : SV_POSITION;
			};
			
			v2f vert(appdata v) 
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			half4 frag(v2f i) : COLOR 
			{
				return half4(1,1,0,0);
			}
		ENDCG
		}
	}
	 Fallback "Diffuse"
}


/*
	Pass {
			Cull Front
			ZTest Less

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			ENDCG
		}
		
		Pass {
			Cull Back
			ZTest Greater

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			ENDCG
		}
		
		*/
