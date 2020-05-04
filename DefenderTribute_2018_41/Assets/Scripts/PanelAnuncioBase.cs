using UnityEngine;
using System.Collections;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif
using UnityEngine.UI;

public class PanelAnuncioBase : MonoBehaviour {

	public bool verAnuncio;
	public GameObject panelAnuncio ;
	public Animator animator;

	// Use this for initialization
	void Start () {
		panelAnuncio.SetActive(false);
	}

	void Update () {
	
	}
    #if UNITY_ADS
	public void ActivarAnuncio(){

        if (Advertisement.IsReady("rewardedVideo"))
        {
            panelAnuncio.SetActive(true);
            Time.timeScale = 0;
        }
        //if (Advertisement.IsReady())
        //{
        //    panelAnuncio.SetActive(true);
        //    Time.timeScale = 0;
        //}
        else {
		
		
			NoVerAnuncio();
		
		}

	}
	public void VerAnuncio(){

		verAnuncio=true;
		ComprobarAnuncio();

	}
	public void NoVerAnuncio(){
		
		verAnuncio=false;
		ComprobarAnuncio();
			
	}
	public void ComprobarAnuncio(){
		
		
		if(verAnuncio==false){
			panelAnuncio.SetActive(false);
			Time.timeScale =1;
			animator.SetBool("Seguir",true);

		}else{
            //			panelAnuncio.SetActive(false);

            if (Advertisement.IsReady("rewardedVideo"))
            {
                var options = new ShowOptions { resultCallback = HandleShowResult };
                Advertisement.Show("rewardedVideo", options);
            }
            //if (Advertisement.IsReady())
            //{
            //   // var options = new ShowOptions { resultCallback = HandleShowResult };
            //    Advertisement.Show();
            //    Time.timeScale = 1;
            //    RecuperarVidas();
            //    animator.SetBool("Seguir", true);
            //}

        }
		
	}
    private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			//Debug.Log("The ad was successfully shown.");
			//
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			panelAnuncio.SetActive(false);
			Time.timeScale=1;
			RecuperarVidas();
			animator.SetBool("Seguir",true);
		
			break;
		case ShowResult.Skipped:
			//Debug.Log("The ad was skipped before reaching the end.");
			panelAnuncio.SetActive(false);
			Time.timeScale=1;
			animator.SetBool("Seguir",true);
			break;
		case ShowResult.Failed:
			//Debug.LogError("The ad failed to be shown.");
			panelAnuncio.SetActive(false);
			Time.timeScale=1;
			animator.SetBool("Seguir",true);
			break;
		 default:
			//Debug.Log ("Ni failed,ni skipped,ni finished");
			break;
		}
	}
#endif
	void RecuperarVidas(){

		if(Puntuaciones.cuantosImpactan==4){

			Puntuaciones.cuantosImpactan=2;
		}else if(Puntuaciones.cuantosImpactan>0){

			Puntuaciones.cuantosImpactan--;
		}

	}	
}
