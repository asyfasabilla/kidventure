Shader "Custom/FlipKartu"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _FlipX ("Flip Horizontal", Float) = 0
        _FlipY ("Flip Vertical", Float) = 0
        _Color ("Color Tint", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        Cull Off
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            float _FlipX;
            float _FlipY;

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

            v2f vert (appdata v)
            {
                v2f o;
                float2 uv = TRANSFORM_TEX(v.uv, _MainTex);

                if (_FlipX > 0.5)
                    uv.x = 1.0 - uv.x;
                if (_FlipY > 0.5)
                    uv.y = 1.0 - uv.y;

                o.uv = uv;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv) * _Color;
                return col;
            }
            ENDCG
        }
    }
}
