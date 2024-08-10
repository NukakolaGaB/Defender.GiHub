using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CargarNivel : MonoBehaviour {

	public AudioSource sonidoPuertas;
	public PanelAnuncioBase panelAnuncioBase;
	public int escena;
	public Animator animador;


	public void Play(){

        //Application.LoadLevelAdditive(3);

        SceneManager.LoadScene(escena);
		//Debug.Log (Puntuaciones.dchaIzda +"de Play");
	}
	public void SonidoBoton(){

		gameObject.GetComponent<AudioSource>().Play ();


	}
#if UNITY_ADS
	public void LanzarAnuncio(){
        //Debug.Log("Entrado en lanzar anuncio");
		if(Puntuaciones.cuantosImpactan>0 ){
			
			panelAnuncioBase.ActivarAnuncio();
			
		}
		else{

			animador.SetBool("Seguir",true);
		}
	}
#endif
#if UNITY_EDITOR
	public void LanzarAnuncio()
	{

		animador.SetBool("Seguir", true);

	}
#endif
	public void SonidoPuertas(){
	
		sonidoPuertas.Play();
	}

	}
