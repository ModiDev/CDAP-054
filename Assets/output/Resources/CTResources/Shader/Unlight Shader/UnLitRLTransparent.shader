// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "RL/UnLitTransparent" 
{
	Properties {
      _Color ("Diffuse Material Color", Color) = (1,1,1,1) 
      _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	  _Cutoff ("Alpha cutoff", Range(0,1)) = 0.001
	  _AlphaMap ("Base (RGB) Trans (A)", 2D) = "white" {}
	  _Offset("Offset", float ) = 0
      _OffsetMin("OffsetMin", float ) = 0
   }  
   

   SubShader {
   Tags { "Queue" = "Transparent+1" "RenderType" = "Transparent" }
	Blend SrcAlpha OneMinusSrcAlpha 
	Cull Back 
	Offset [_Offset],[_OffsetMin]
	Ztest LEqual
	ZWrite on
	    // Pass to render object as a shadow caster
	Pass {
		Name "Caster"
		Tags { "LightMode" = "ShadowCaster" }
		Offset 1, 1
		
		Fog {Mode Off}
		ZWrite On ZTest LEqual Cull Off

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
	fixed4 texcol = tex2D( _AlphaMap, i.uv );
	clip( texcol.a - _Cutoff );
	if ( _Color.a ==  0 || _Cutoff == 1 )
	{
	    clip( -1 );
	}
	SHADOW_CASTER_FRAGMENT(i)
}
ENDCG

	}
	
	// Pass to render object as a shadow collector
	Pass {
		Name "ShadowCollector"
		Tags { "LightMode" = "ShadowCollector" }
		
		Fog {Mode Off}
		ZWrite On ZTest LEqual

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
	fixed4 texcol = tex2D( _AlphaMap, i.uv );
	clip( texcol.a - _Cutoff );
	if ( _Color.a ==  0 || _Cutoff == 1 )
	{
	    clip( -1 );
	}
	SHADOW_COLLECTOR_FRAGMENT(i)
}
ENDCG

	}
    Pass 
       {  
    	   CGPROGRAM
    	   #pragma vertex vert
    	   #pragma fragment frag
    	   
    	   #include "UnityCG.cginc"
           struct appdata_t 
           {
    	   	   float4 vertex : POSITION;
    	   	   float4 color : COLOR;
    	   	   float2 texcoord : TEXCOORD0;
    	   };
    	   
  		   struct v2f 
  		   {
    	   	   float4 vertex : POSITION;
    	   	   float4 color : COLOR;
    	   	   float2 texcoord : TEXCOORD0;
    	   };
    	   sampler2D _MainTex;
    	   sampler2D _AlphaMap;
    	   float4 _MainTex_ST;
    	   float _Cutoff;
    	   
  		   v2f vert (appdata_t v)
    	   {
    	       v2f o;
    	       o.vertex = UnityObjectToClipPos(v.vertex);
    	       o.color = v.color;
    	       o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
    	       return o;
    	   }
    	    
    	   float4 _Color;
    	   half4 frag (v2f i) : COLOR
    	   {
    	       float2 xy = i.texcoord;
    	   	   half4 col = _Color * tex2D(_MainTex, xy);
    	   	   col.a = tex2D(_AlphaMap, xy).a;
    	   	   if ( _Cutoff == 0 )
    	   	   {
    	   	       col.a = 1;
    	   	   }
    	   	   else if ( _Cutoff == 1 )
    	   	   {
    	   	       clip( -1 );
    	   	   }
    	   	   else
    	   	   {
    	   	       clip( col.a - _Cutoff );
    	   	   }
    	   	   col.a *= _Color.a;
    	   	   if ( col.a == 0 )
    	   	   {
    	   	     clip( -1 );
    	   	   }
    	   	   return col;
    	   }
    	   ENDCG
       }

   }
   Fallback "Diffuse"
}