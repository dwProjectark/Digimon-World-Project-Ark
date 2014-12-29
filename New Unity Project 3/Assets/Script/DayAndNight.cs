using UnityEngine;
using System.Collections;

public class DayAndNight : MonoBehaviour {
	public float slider;
	public float slider2;
	public float Hour;
	private float Tod;
	public Light sun;
	public int speed;

	public Color NightFogColor;
	public Color DuskFogColor;
	public Color MorningFogColor;
	public Color MiddayFogColor;
	
	public Color NightAmbientLight;
	public Color DuskAmbientLight;
	public Color MorningAmbientLight;
	public Color MiddayAmbientLight;
	
	public Color NightTint;
	public Color DuskTint;
	public Color MorningTint;
	public Color MiddayTint;
	
	public Material SkyBoxMaterial1;
	public Material SkyBoxMaterial2;
	
	public Color SunNight;
	public Color SunDay;

	public GameObject Water;
	public bool IncludeWater = false;
	public Color WaterNight;
	public Color WaterDay;


	void OnGUI () {
		
		if(slider >= 1.0)
		{
			slider = 0;
		}
		
		slider = GUI.HorizontalSlider(new Rect(20,20,200,30), slider, 0f,1f);
		Hour= slider*24;
		Tod= slider2*24;
		sun.transform.localEulerAngles =new Vector3((slider*360)-90, 0, 0);
		slider = slider +Time.deltaTime/speed;
		sun.color = Color.Lerp (SunNight, SunDay, slider*2);
		
		//THIS WAS ADDED IN TUTORIAL NUMBER 24. It allows for changing the color that reflects of a water object.
		//Uncheck IncludeWater if you are not interested in using this.
		if (IncludeWater == true)
		{
			Water.renderer.material.SetColor("_horizonColor", Color.Lerp(WaterDay,WaterNight,slider2*2f-0.2f));
		}
		
		if(slider<0.5){
			slider2= slider;
		}
		if(slider>0.5){
			slider2= (1-slider);
		}
		sun.intensity = (slider2-0.2f)*1.7f;
		
		
		if(Tod<4){
			//it is Night
			RenderSettings.skybox=SkyBoxMaterial1;
			RenderSettings.skybox.SetFloat("_Blend", 0);
			SkyBoxMaterial1.SetColor ("_Tint", NightTint);
			RenderSettings.ambientLight = NightAmbientLight;
			RenderSettings.fogColor = NightFogColor;
		}
		if(Tod>4&&Tod<6){
			RenderSettings.skybox=SkyBoxMaterial1;
			RenderSettings.skybox.SetFloat("_Blend", 0);
			RenderSettings.skybox.SetFloat("_Blend", (Tod/2)-2);
			SkyBoxMaterial1.SetColor ("_Tint", Color.Lerp (NightTint, DuskTint, (Tod/2)-2) );
			RenderSettings.ambientLight = Color.Lerp (NightAmbientLight, DuskAmbientLight, (Tod/2)-2);
			RenderSettings.fogColor = Color.Lerp (NightFogColor,DuskFogColor, (Tod/2)-2);
			//it is Dusk
			
		}
		if(Tod>6&&Tod<8){
			RenderSettings.skybox=SkyBoxMaterial2;
			RenderSettings.skybox.SetFloat("_Blend", 0);
			RenderSettings.skybox.SetFloat("_Blend", (Tod/2)-3);
			SkyBoxMaterial2.SetColor ("_Tint", Color.Lerp (DuskTint,MorningTint,  (Tod/2)-3) );
			RenderSettings.ambientLight = Color.Lerp (DuskAmbientLight, MorningAmbientLight, (Tod/2)-3);
			RenderSettings.fogColor = Color.Lerp (DuskFogColor,MorningFogColor, (Tod/2)-3);
			//it is Morning
			
		}
		if(Tod>8&&Tod<10){
			RenderSettings.ambientLight = MiddayAmbientLight;
			RenderSettings.skybox=SkyBoxMaterial2;
			RenderSettings.skybox.SetFloat("_Blend", 1);
			SkyBoxMaterial2.SetColor ("_Tint", Color.Lerp (MorningTint,MiddayTint,  (Tod/2)-4) );
			RenderSettings.ambientLight = Color.Lerp (MorningAmbientLight, MiddayAmbientLight, (Tod/2)-4);
			RenderSettings.fogColor = Color.Lerp (MorningFogColor,MiddayFogColor, (Tod/2)-4);

			//it is getting Midday
			
		}
	}
}
