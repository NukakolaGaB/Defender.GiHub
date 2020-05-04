using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityStandardAssets.ImageEffects;

public class MascaraDanno : MonoBehaviour {

	[SerializeField] Image myImage;
	[SerializeField] VignetteAndChromaticAberration vignetteAndChromaticAberration;
	[SerializeField] Animator mascaraAnim;


	void Awake(){
	
		//myObject = gameObject;
//		vignetteAndChromaticAberration.chromaticAberration=0.2f;
	
	}
	// Use this for initialization
	void Start () {


		Accessos.mascaraDanno = this;
		//myImage.enabled=false;
	}
	void OnEnable(){

		//vignetteAndChromaticAberration.chromaticAberration=9f;
		//Encender();

	}
	public void Encender(){
		
		//myImage.enabled=true;
		mascaraAnim.SetBool("Dannado",true);
		//vignetteAndChromaticAberration.chromaticAberration=9f;
		
	}
	// Update is called once per frame
	public void Apagar(){
		mascaraAnim.SetBool("Dannado",false);
		//myImage.enabled=false;
		//vignetteAndChromaticAberration.chromaticAberration=0.2f;

	}
}
