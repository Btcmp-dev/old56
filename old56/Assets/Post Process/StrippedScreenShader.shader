Shader "Custom/StripedScreenShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _StripeAmount ("Stripe Amount", Float) = 100
        _LensDistortionStrength("Lens distortion Strength",Float) = 1
        _LensDistortionTightness("Lens distortion Tightness",Float) = 1
        _OutOfBoundColour("Out of bound color", Color) = (0,0,0,1)
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

            float _LensDistortionStrength;
            float _LensDistortionTightness;
            float4 _OutOfBoundColour;
            float uv_centered;



            v2f vert(appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {

                fixed4 col = tex2D(_MainTex, i.uv);

                //////CRT Stripes
                // Calculate the stripe pattern
                float stripe = sin(float2(i.uv.y * _StripeAmount, 0)) * 0.2 + 0.8; //множитель - темнота полос, слагаемое - яркость картинки
                // Apply the stripe pattern to the texture
                col.rgb *= stripe;

                /* Эффект получился менее красивым, а заставить полоски обратываться не поверх я не смог
                /////Lens distortion
                const float2 uvNormalized = i.uv * 2 - 1; 
                float2 uv_centered = float2(uvNormalized.x, uvNormalized.y);

                const float distortionMagnitude = abs(uv_centered[0] * uv_centered[1]); 

                //const float smoothDistortionMagnitude = pow(distortionMagnitude, _LensDistortionTightness);//use exponential function
                const float smoothDistortionMagnitude=1-sqrt(1-pow(distortionMagnitude,_LensDistortionTightness));//use circular function
                //const float smoothDistortionMagnitude=pow(sin(UNITY_HALF_PI*distortionMagnitude),_LensDistortionTightness);
                
                float2 uvDistorted = i.uv + uv_centered * smoothDistortionMagnitude * _LensDistortionStrength; 

                //Handle out of bound uv
                if (uvDistorted[0] < 0 || uvDistorted[0] > 1 || uvDistorted[1] < 0 || uvDistorted[1] > 1) {
                    col = _OutOfBoundColour; 
                } else {
                    col = tex2D(_StripeTex, uvDistorted); 
                }
                */
                return col;
            }
            ENDCG
        }
    }
}