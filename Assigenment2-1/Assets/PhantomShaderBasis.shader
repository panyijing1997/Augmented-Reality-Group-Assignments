Shader "ARCourse/phantomShaderBasis"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags{ "Queue" = "Geometry-100" }
                
        Pass{
            
            //TODO: Add render state setup commands
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag


            sampler2D _MainTex;
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            struct vertex2fragment
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION; 
            };

            vertex2fragment vert(appdata v)
            {
                vertex2fragment result;
                result.vertex = UnityObjectToClipPos(v.vertex);
                result.uv = v.uv;

                return result;
            }

            float4 frag(vertex2fragment i) : SV_Target
            {
				//TODO: do something useful here and return something useful
				return float4(0,0,0,0);
            }
            
            ENDCG
                    
        }
    }
}
