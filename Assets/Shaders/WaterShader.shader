Shader "MyShaders/WaterShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Speed("Speed of the waves", float) = 1
		_Amount("The number of waves", float) = 1
		_Hight("Wave Hight", float) = 2
		_Transparancy("How transparent will the water be", Range(0, 1)) = 1
		_TextureMoveSpeed("How fast the texture will move", float) = 0.2
    }
    SubShader
    {
        Tags {"Queue" = "Transparent" "RenderType"="Transparent" }

        LOD 100

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float _Speed;
			float _Amount;
			float _Hight;
			float _Transparancy;
			float _TextureMoveSpeed;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv += sin(_Time.yz) * _TextureMoveSpeed;
				float3 _WorldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
				o.vertex.y += sin(_Time.w * _Speed + (_WorldPos.x * _WorldPos.z * _Amount)) * _Hight;
				//o.vertex.y += sin(_Time.w * _Speed + (o.vertex.x * o.vertex.z * _Amount)) * _Hight;

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
				col.a = _Transparancy;
                return col;
            }
            ENDCG
        }
    }
}
