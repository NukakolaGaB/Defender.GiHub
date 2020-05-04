using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class CargarNivel : MonoBehaviour {

	public AudioSource sonidoPuertas;
	public PanelAnuncioBase panelAnuncioBase;
	public int escena;
	public Animator animador;


	public void Play(){

		//Application.LoadLevelAdditive(3);
	
		EditorSceneManager.LoadScene(escena);
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
	public void SonidoPuertas(){
	
		sonidoPuertas.Play();
	}

	}
