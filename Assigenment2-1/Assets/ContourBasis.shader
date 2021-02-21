Shader "ARCourse/ContourBasis"
{
	//https://docs.unity3d.com/462/Documentation/Manual/SL-BuiltinValues.html

	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			// include file that contains UnityObjectToWorldNormal helper function
			#include "UnityCG.cginc"

			struct Input
			{
				float4 vertex : POSITION;
				half3 normal : NORMAL;
			};

			struct VertexToFragment
			{
				float4 vertex : SV_POSITION;		
				half3 normal : NORMAL;
				float4 camPos : TEXCOORD0;
			};
			
			VertexToFragment vert (Input IN)
			{
				VertexToFragment OUT;
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.camPos = mul(UNITY_MATRIX_M, IN.vertex);
				OUT.normal = UnityObjectToWorldNormal(IN.normal);
				return OUT;
			}
			
			float4 frag(VertexToFragment IN) : SV_Target
			{
				//TODO: Do something here and return something useful
				return float4(0, 0, 0, 1.0);
			}
			ENDCG
		}
	}
}