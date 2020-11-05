Shader "RL/Lit-Opacity-Depth" 
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
          //  SetTexture [_MainTex] { combine texture * primary double}
      }
   }
}

