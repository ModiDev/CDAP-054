// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

///--------------------------------------------------------------------------------------
// File: Unlit-SoftEdgeOpacity-Depth.shader
//
// Developed by Reallusion Developer team.
//
// Copyright © 2014 Reallusion Inc. All rights reserved.
//--------------------------------------------------------------------------------------
Shader "RL/Unlit-SoftEdgeOpacity-Depth" 
{
    Properties 
    {
    	_Color ("Main Color", Color) = (1, 1, 1, 1)
    	_MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
    	_AlphaMap ("Alpha Map", 2D) = "white" {}
    	_Cutoff ("Base Alpha cutoff", Range (0,1.0)) = 0.001
    }

    SubShader 
    {
	    Tags { "Queue"="Overlay" "IgnoreProjector"="True" "RenderType"="TransparentCutout" }
	    Lighting Off
	    Ztest  always
	    ZWrite Off
	    // Render both front and back facing polygons.
	    Cull Back // Orignal: Off
	    // first pass:
	    //   render any pixels that are more than [_Cutoff] opaque
	    Pass 
	    {  
	    	CGPROGRAM
	    		#pragma vertex vert
	    		#pragma fragment frag
	    		
	    		#include "UnityCG.cginc"
	    
	    		struct appdata_t {
	    			float4 vertex : POSITION;
	    			float4 color : COLOR;
	    			float2 texcoord : TEXCOORD0;
	    		};
	    
	    		struct v2f {
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
	    			half4 col = _Color * tex2D(_MainTex, i.texcoord);
	    			col.a = tex2D(_AlphaMap, i.texcoord).r;
	    			clip(col.a - _Cutoff);
	    			col.a *= _Color.a;
	    			return col;
	    		}
	    	ENDCG
	    }

	    // Second pass:
	    //   render the semitransparent details.
	    Pass {
	    	Tags { "RequireOption" = "SoftVegetation" }
	    	
	    	// Dont write to the depth buffer
	    	ZWrite Off
	    	
	    	// Set up alpha blending
	    	Blend SrcAlpha OneMinusSrcAlpha
	    	
	    	CGPROGRAM
	    		#pragma vertex vert
	    		#pragma fragment frag
	    		
	    		#include "UnityCG.cginc"
	    
	    		struct appdata_t {
	    			float4 vertex : POSITION;
	    			float4 color : COLOR;
	    			float2 texcoord : TEXCOORD0;
	    		};
	    
	    		struct v2f {
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
	    			half4 col = _Color * tex2D(_MainTex, i.texcoord);
	    			col.a = tex2D(_AlphaMap, i.texcoord).r - ( 1 - _Color.a );
	    			clip(-(col.a - _Cutoff));
	    			return col;
	    		}
	    	ENDCG
	    }
    }

    SubShader
    {
	    Tags { "Queue"="Overlay" "IgnoreProjector"="True" "RenderType"="TransparentCutout" }
	    Lighting off
	    
	    // Render both front and back facing polygons.
	    Cull Off
	    
	    // first pass:
	    //   render any pixels that are more than [_Cutoff] opaque
	    Pass {  
	    	AlphaTest Greater [_Cutoff]
	    	SetTexture [_MainTex] {
	    		constantColor [_Color]
	    		combine texture * constant, texture * constant 
	    	}
	    }
	    
	    // Second pass:
	    //   render the semitransparent details.
	    Pass {
	    	Tags { "RequireOption" = "SoftVegetation" }
	    	
	    	// Dont write to the depth buffer
	    	ZWrite off
	    	
	    	// Only render pixels less or equal to the value
	    	AlphaTest LEqual [_Cutoff]
	    	
	    	// Set up alpha blending
	    	Blend SrcAlpha OneMinusSrcAlpha
	    	
	    	SetTexture [_MainTex] {
	    		constantColor [_Color]
	    		Combine texture * constant, texture * constant 
	    	}
	    }
    }
}
