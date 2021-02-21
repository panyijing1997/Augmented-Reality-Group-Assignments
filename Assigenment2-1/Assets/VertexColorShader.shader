Shader "Unlit/VertexColorShader"
{
	Properties
	{		
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"


			//datatype sent from application to vertex shader
			//vertex shader inputs
			struct appdata 
			{
				float4 vertex : POSITION;
                float4 color : COLOR;			
			};
			//datatype sent from vertex shader to fragment shader
			//vertex shader outputs
			struct v2f
			{				
				float4 vertex : SV_POSITION;
                float4 color : COLOR;
			};            
			
			//vertex shader function
			v2f vert (appdata v)
			{
				v2f o;
				//Transforms from object space to the cameras space coordinates.
				//multiply with model*view*projection matrix
				o.vertex = UnityObjectToClipPos(v.vertex);
                o.color = v.color;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target //saved into render target 
			//output color for each pixel
			{
				// sample the texture
				fixed4 col = i.color;
				// apply fog
				//return fixed4(1, 0, 0, 1);
				return col;
			}
			ENDCG
		}
	}
}