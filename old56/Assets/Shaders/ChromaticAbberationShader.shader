Shader "Custom/ChromaticAberrationShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _AberrationAmount ("Aberration Amount", Float) = 0.01
    }
    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 200

        ZWrite Off
        Cull Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _AberrationAmount;

            v2f vert(appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv);
                // Calculate the chromatic aberration
                float2 redUV = i.uv + float2(_AberrationAmount, 0);
                float2 greenUV = i.uv;
                float2 blueUV = i.uv - float2(_AberrationAmount, 0);
                // Sample the texture at the different UVs
                fixed4 redCol = tex2D(_MainTex, redUV);
                fixed4 greenCol = tex2D(_MainTex, greenUV);
                fixed4 blueCol = tex2D(_MainTex, blueUV);
                // Combine the colors
                col.rgb = float3(redCol.r, greenCol.g, blueCol.b);
                // Preserve the alpha channel
                col.a = tex2D(_MainTex, i.uv).a;
                return col;
            }
            ENDCG
        }
    }
}