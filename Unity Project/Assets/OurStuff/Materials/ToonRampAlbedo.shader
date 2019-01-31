Shader "Holistic/ToonRampAlbedo" {
	Properties 
	{
		_Color  ("Color", Color) = (1,1,1,1)
		_RampTex ("Ramp Texture", 2D) = "white"{}
		_myDiffuse("Diffuse Texture", 2D) = "white"{}
	}
	
	SubShader 
	{
		CGPROGRAM
		#pragma surface surf ToonRamp

		float4 _Color;
		sampler2D _RampTex;
		sampler2D _myDiffuse;
		
		struct Input
		{
			float2 uv_myDiffuse;
			float3 viewDir;
			float3 Normal;
		};

		void surf (Input IN, inout SurfaceOutput o) 
		{
			o.Albedo = tex2D(_myDiffuse, IN.uv_myDiffuse).rgb;
			o.Emission = float4(0,0,0,0);
		}
		
		float4 LightingToonRamp(SurfaceOutput s, fixed3 lightDir, fixed3 viewDir, fixed atten)
		{
			float diff = dot(s.Normal, lightDir);
			float h = diff * 0.5 + 0.5;
			float2 rh = clamp(h, 0.05, 0.95);
			float3 ramp = (tex2D(_RampTex, rh).rgb - 0.5) * 1.2 + 0.5;

			float4 c;
			
			c.rgb = s.Albedo * _LightColor0.rgb * (ramp);
			c.a = s.Alpha;

			//c.e = float4(0,0,0,0);

			/*
			if (dot(s.Normal, viewDir) < 0.5)
			{
				c.rgb = float3(0, 0, 0);
			}*/

			return c;
		}

		ENDCG
	} 
	
	FallBack "Diffuse"

}
