// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

///--------------------------------------------------------------------------------------
// File: Unlit-Stencil-Opacity.shader
//
// Developed by Reallusion Developer team.
//
// Copyright c 2014 Reallusion Inc. All rights reserved.
//--------------------------------------------------------------------------------------
Shader "RL/Stencil/Unlit-Opacity" 
{
   Properties
   {
      _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
      _AlphaMap ("Culling Mask", 2D) = "white" {}
      _Color ("Main Color", Color) = (1, 1, 1, 1)
      _RefMaskID( "Mask ID", float ) = 3
      _Cutoff ("Base Alpha cutoff", Range (0,1.0)) = 0.001
   }
   SubShader 
   {
       Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
       Lighting Off
       ZWrite On
       Blend SrcAlpha OneMinusSrcAlpha 
       Cull Back
       //AlphaTest Greater [_Cutoff]       
       Stencil 
       {
       	   Ref [_RefMaskID]
       	   Comp NotEqual
       	   Pass Zero
       	   Fail DecrWrap
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
    	   	    half4 col = _Color * tex2D(_MainTex, i.texcoord);
    	   	   col.a = tex2D(_AlphaMap, i.texcoord).r;
    	   	   clip(col.a - _Cutoff);
    	   	   col.a *= _Color.a;
    	   	   return col;
    	   }
    	   ENDCG
       }
   } 
}
