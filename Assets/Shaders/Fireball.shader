Shader "Custom/FireballEmbers"
{
    Properties
    {
        _MainTex ("Noise Texture", 2D) = "white" {}
        _Color ("Ember color", Color) = (1,0.4,0,1)
        _GlowIntensity("Glow intensity", Float) = 2.0
        _FadeDistance("Fade distance", Float) = 1.5
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Blend SrcAlpha One
        ZWrite Off
        ZTest LEqual

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
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };

            sampler2D _MainTex;
            float4 _Color;
            float _GlowIntensity;
            float _FadeDistance;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color * _Color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Sample texture noise (ensure texture is correctly set!)
                float noise = tex2D(_MainTex, i.uv).r;

                // Apply glow intensity
                float glow = noise * _GlowIntensity;

                // Fade effect based on UV and noise
                float alpha = noise * saturate(1.0 - i.uv.y * _FadeDistance);

                return float4(i.color.rgb * glow, alpha);
            }
            ENDCG
        }
    }
}
