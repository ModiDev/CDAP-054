// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

///--------------------------------------------------------------------------------------
// File: Unlit-Opacity-Depth.shader
//
// Developed by Reallusion Developer team.
//
// Copyright © 2014 Reallusion Inc. All rights reserved.
//--------------------------------------------------------------------------------------
Shader "RL/Unlit-Opacity-Depth" 
{
    Properties
    {
        _Color ("Main Color", Color) = (1, 1, 1, 1)
    	_MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
    	_AlphaMap ("Alpha Map", 2D) = "white" {}
    }
    SubShader 
    {
	    Tags { "Queue"="Transparent+1" "IgnoreProjector"="True" "RenderType"="TransparentCutout" }
	    Lighting Off
    	ZWrite Off
    	Blend SrcAlpha OneMinusSrcAlpha
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
    	        half4 col = _Color * tex2D(_MainTex, i.texcoord);
    	        col.a = tex2D(_AlphaMap, i.texcoord).r *  _Color.a;
    	        if (col.a==0)
    	   	    {
    	   	       clip(-1);
    	   	    }
    	        return col;
    	    }
    	   ENDCG
        }
   }
}

