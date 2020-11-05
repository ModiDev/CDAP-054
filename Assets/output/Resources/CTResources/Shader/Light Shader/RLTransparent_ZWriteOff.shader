
Shader "RL/Transparent_ZWriteOff" {
    
    Properties 
    {
        _Color ("Main Color", Color) = (1, 1, 1, 1)
        _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
        _AlphaMap ("Alpha Map", 2D) = "white" {}
        _Cutoff ("Base Alpha cutoff", Range (0,1.0)) = 0.001
        _Offset("Offset", float ) = 0
        _OffsetMin("OffsetMin", float ) = -300
        _MaskID( "Mask ID", float ) = 3

    }
    SubShader 
    {
      Tags { "Queue" = "Transparent+1" }
      Blend SrcAlpha OneMinusSrcAlpha 
      Offset [_Offset],[_OffsetMin]
      ZWrite off
     // Ztest always 
      Cull Back   
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
	clip( texcol.a*_Color.a - _Cutoff );
	
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
	clip( texcol.a*_Color.a - _Cutoff );
	
	SHADOW_COLLECTOR_FRAGMENT(i)
}
ENDCG

	}
      Pass 
      {
          Tags { "LIGHTMODE"="Vertex"  }
          Lighting On
          SeparateSpecular On
          Material {
          Ambient [_Color]
          Diffuse [_Color]
          Emission [_Emission]
          Specular [_SpecColor]
          Shininess [_Shininess]
          }
          Blend SrcAlpha OneMinusSrcAlpha
          ColorMask RGBA
          SetTexture [_AlphaMap] {combine texture}
          SetTexture [_MainTex] {combine texture, previous}
          SetTexture [_MainTex] { combine Previous  * primary double }
      }
		//
	  CGPROGRAM
      #pragma surface surf Lambert alpha
      uniform float _Cutoff;
       float4 _Color;
       sampler2D _MainTex;
       sampler2D _AlphaMap;
      struct Input {
          float4 color : COLOR;
          float2 uv_MainTex;
      };
      void surf (Input IN, inout SurfaceOutput o) {        
          half4 c = tex2D (_MainTex, IN.uv_MainTex);
          o.Albedo = c.rgb * _Color.rgb;
          o.Alpha = tex2D (_AlphaMap, IN.uv_MainTex).a;  
          if ( _Cutoff == 0 )
    	  {
    	   	  o.Alpha = 1;
    	  }
    	  else if ( _Cutoff == 1 )
    	  {
    	   	  clip( -1 );
    	  }
    	  else
    	  {
    	   	  clip( o.Alpha - _Cutoff ); 
    	  }
          o.Alpha  *= _Color.a;
          if ( o.Alpha == 0 )
          {
              clip( -1 );
          }
      }
      ENDCG
    }
}

