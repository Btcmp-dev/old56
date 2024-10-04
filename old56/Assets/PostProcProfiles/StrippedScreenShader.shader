Shader "Custom/StripedScreenShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _StripeAmount ("Stripe Amount", Float) = 100
    }
    SubShader {
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
            float _StripeAmount;

            v2f vert(appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv);
                // Calculate the stripe pattern
                float stripe = sin(float2(i.uv.y * _StripeAmount, 0)) * 0.5 + 0.5;
                // Apply the stripe pattern to the texture
                col.rgb *= stripe;
                return col;
            }
            ENDCG
        }
    }
}