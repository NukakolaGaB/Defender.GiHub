using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_ADS
using UnityEngine.Advertisements; // only compile Ads code on supported platforms
#endif
public class DanoDeMisiles : MonoBehaviour {

	public ControladorMisiones controladorMisiones;

	[SerializeField] GameObject gameOver;
	[SerializeField] GameOver 	gameOverscrpt;
	[SerializeField] GameObject boton;
	[SerializeField] GameObject camaraRadar;
	[SerializeField] AudioSource explosionMisil;

	public bool verAnuncio=false;
	public GameObject panelAnuncio ;
	public Text panelAnuncioText;

	[SerializeField] Image vida1;
	[SerializeField] Image vida2;
	[SerializeField] Image vida3;
	[SerializeField] Image vida4;
	Color azul = new Color(9f/255f,129f/255f,214f/255f,1f);

	public bool jefeEnAccion;

	void Awake(){

		panelAnuncio.SetActive(false);

	}
	
	// Use this for initialization
	void Start () {


		if (!Puntuaciones.dchaIzda) {
			CambiarSentido();
		}

		RefreshVida ();
		

	}
	

	
	public void Impacto () {
		explosionMisil.Play();
		Puntuaciones.cuantosImpactan++;
		controladorMisiones.misilEnVueloMenos ();
		Accessos.mascaraDanno.Encender();
		RefreshVida ();
		
		if (Puntuaciones.cuantosImpactan >= Puntuaciones.limiteImpactos) {
			GameOver ();
		} else {
			controladorMisiones.ChequeaLanzaProteus ();
		}
	}
	
	public void ComprobarAnuncio(){
		
		if(verAnuncio==false){
			panelAnuncio.SetActive(false);
			gameOver.SetActive(true);
			boton.SetActive(false);
			Time.timeScale=1;
			gameOverscrpt.Reintentar();
		}else{
			gameOver.SetActive(false);
			camaraRadar.SetActive(true);
#if UNITY_ADS
            if (Advertisement.IsReady("rewardedVideo"))
            {
                panelAnuncio.SetActive(false);
                var options = new ShowOptions { resultCallback = HandleShowResult };
                Advertisement.Show("rewardedVideo", options);
                //anuncioLanzado=true;
            }
#endif
            //if (Advertisement.IsReady())
            //{
            //	panelAnuncio.SetActive(false);
            //	Advertisement.Show();
            //	//anuncioLanzado=true;
            //	Time.timeScale=1;
            //	RecuperarVidas ();
            //	RefreshVida ();

            //}
        }
	}
    #if UNITY_ADS
		private void HandleShowResult(ShowResult result)
		{
			switch (result)
			{
			case ShowResult.Finished:
				//Debug.Log("The ad was successfully shown.");
				//
				// YOUR CODE TO REWARD THE GAMER
				// Give coins etc.
				Time.timeScale=1;
				RecuperarVidas ();
				RefreshVida ();
				break;
			case ShowResult.Skipped:
				//Debug.Log("The ad was skipped before reaching the end.");
				//gameOverscrpt.Reintentar();
                panelAnuncio.SetActive(false);
                gameOver.SetActive(true);
                boton.SetActive(false);
                Time.timeScale = 1;
                gameOverscrpt.Reintentar();
                //RecuperarVidas ();
                //RefreshVida ();
                break;
			case ShowResult.Failed:
                //Debug.LogError("The ad failed to be shown.");
                //gameOverscrpt.Reintentar();
                panelAnuncio.SetActive(false);
                gameOver.SetActive(true);
                boton.SetActive(false);
                Time.timeScale = 1;
                gameOverscrpt.Reintentar();
                break;
			}
		}
#endif
	/// <summary>
	/// Actualiza el color de los sprites de la barra de vida.
	/// </summary>
	void RefreshVida () {
#region colorear barra de vida
		
		if(Puntuaciones.cuantosImpactan<=0){
			
			vida1.color = azul;
			vida2.color = azul;
			vida3.color = azul;
			vida4.color = azul;
			
		}
		else if(Puntuaciones.cuantosImpactan==1){
			
			vida1.color = Color.red;
			vida2.color = azul;
			vida3.color = azul;
			vida4.color = azul;
			
		}
		else if(Puntuaciones.cuantosImpactan==2){
			
			vida1.color = Color.red;
			vida2.color = Color.red;
			vida3.color = azul;
			vida4.color = azul;
			
		}
		else if(Puntuaciones.cuantosImpactan==3){
			
			vida1.color = Color.red;
			vida2.color = Color.red;
			vida3.color = Color.red;
			vida4.color = azul;
			
		}
		else if(Puntuaciones.cuantosImpactan==4){
			
			vida1.color = Color.red;
			vida2.color = Color.red;
			vida3.color = Color.red;
			vida4.color = Color.red;
			
		}
#endregion
	}

	public void CambiarSentido () {
		transform.position = new Vector3 (-transform.position.x, transform.position.y, transform.position.z);
	}

	/// <summary>
	/// para recuperar 1 vida al salvar la proteus.
	/// </summary>
	public void SumarVida () {
		if (Puntuaciones.cuantosImpactan > 0) {
			Puntuaciones.cuantosImpactan--;
			RefreshVida ();
		}
	}
	public void RestarVida () {
		Puntuaciones.cuantosImpactan++;
		RefreshVida ();
		if (Puntuaciones.cuantosImpactan >= Puntuaciones.limiteImpactos) {
			GameOver ();
		}
	}

	/// <summary>
	/// para recuperar vidas al ver 1 video.
	/// </summary>
	void RecuperarVidas(){

		boton.SetActive (true);
		if(Puntuaciones.cuantosImpactan==4){
			
			Puntuaciones.cuantosImpactan=2;
		}else if(Puntuaciones.cuantosImpactan>0){
			
			Puntuaciones.cuantosImpactan--;
		}
		
		
	}

	void GameOver () {

		QuitarMisilesEnVuelo ();
		boton.SetActive(false);
		camaraRadar.SetActive(false);

		if (Puntuaciones.videosParaVer > 0) {
			Puntuaciones.videosParaVer--;
            #if UNITY_ADS
			if (Advertisement.IsReady("rewardedVideo")){
				panelAnuncio.SetActive (true);
				Time.timeScale = 0;
			}
			else{

				verAnuncio=false;
				ComprobarAnuncio();

			}
#endif
		} else {
			gameOver.SetActive (true);
		}
	}

	void QuitarMisilesEnVuelo () {

		GameObject[] misil = GameObject.FindGameObjectsWithTag (Tags.misil);

		if (jefeEnAccion) {
			if (misil.Length > 0) {
				foreach (GameObject dest in misil) {
					SimplePool.Despawn (dest);
				}
				controladorMisiones.misilesEnVuelo = 0;
			}

		} else {
			if (misil.Length > 0) {
				foreach (GameObject dest in misil) {
					SimplePool.Despawn (dest);
					controladorMisiones.lanzaMisiles2D.misilesPorLanzar++;
				}
				controladorMisiones.NoLanzadoUltimoMisil ();
				controladorMisiones.misilesEnVuelo = 0;
			}
		}
	}

}

