Shader "VueCode/UnlitMod"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color ("Main Color", Color) = (1,1,1,1)

		_Cutoff("Alpha cutoff", Range(0.00001,1)) = 0.5

		_Stroke ("Stroke Alpha", Range(0,1)) = 0.1
		_StrokeColor ("Stroke Color", Color) = (1,1,1,1)

				_Stroke2 ("Stroke Alpha", Range(0,1)) = 0.1
		_StrokeColor2 ("Stroke Color", Color) = (1,1,1,1)

			_Pure ("Blue Value for Pure", Range(0,1))  = 0.1
			_PureColor1("Pure Color", Color) = (1,1,1,.5)
	}
	SubShader
	{
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		LOD 100
		 Blend SrcAlpha OneMinusSrcAlpha
		Lighting Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			  
			struct appdata
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed _Cutoff;

			half4 _Color;

			fixed _Stroke;
			half4 _StrokeColor;

			fixed _Stroke2;
			half4 _StrokeColor2;
			fixed _Pure;
			float4 _PureColor1;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
				return o;
			}
			
			float4 frag (v2f i) : SV_Target
			{
				// sample the texture
				float4 col = tex2D(_MainTex, i.texcoord);
				
				clip(col.a - _Cutoff);
				float4 fragcol = col;
				//
				fragcol.a = 1;
				//if(col.a < _Stroke) fragcol = _StrokeColor;
				//else if (col.a < _Stroke2) fragcol = _StrokeColor2;
				//else 	  fragcol = _Color;

				//if (col.b > _Pure) fragcol = _PureColor1;

				return fragcol;
			}
			ENDCG
		}
	}
}
