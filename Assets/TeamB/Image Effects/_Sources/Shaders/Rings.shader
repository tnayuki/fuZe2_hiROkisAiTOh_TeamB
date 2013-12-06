Shader "Hidden/Rings"
{    
    Properties
    {
		_MainTex ("Base (RGB)", 2D) = "white" {}
    	_Center ("Center", Vector) = (0, 0, 0, 0)
    	_TurningRadius ("Turning radius", float) = 1.0
    	_TurningSpeed ("Turning speed", float) = 1.0
 		_Color ("Color", Color) = (1.0, 1.0, 1.0, 1.0)
    }
    SubShader
    {
    	Tags
    	{
    		"Queue" = "Geometory"
    	}
        Pass
        {
			ZTest Always Cull Off ZWrite Off

CGPROGRAM
#pragma vertex vert_img
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest 
#include "UnityCG.cginc"

uniform sampler2D _MainTex;
uniform fixed2 _Center;
uniform float _TurningRadius;
uniform float _TurningSpeed;
uniform fixed4 _Color;

fixed4 frag (v2f_img i) : COLOR
{	
	fixed4 original = tex2D(_MainTex, i.uv);

	fixed2 p = (i.uv * 2.0 - 1.0) + _Center;
	p += fixed2(sin(_Time.y * _TurningSpeed) * _TurningRadius, cos(_Time.y * _TurningSpeed) * _TurningRadius);
		
	fixed4 c = fixed4(sin(length(p)*300.0), sin(length(p)*300.0), sin(length(p)*300.0), 1.0);
	
	if (c.x > 0 && c.y > 0 && c.z > 0) return fixed4(_Color);
	
	return original;
}
ENDCG

		}
	}
	FallBack "Diffuse"
}