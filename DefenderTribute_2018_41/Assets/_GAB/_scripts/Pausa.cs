using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Pausa : MonoBehaviour {

	public GameObject disparador;
	public GameObject mascaraPausa;
	public AudioMixer sonidoTodo;
	public Text textoBoton;
	public Image botonPausa;
	public Animator botonAnim;

	void Awake(){


		mascaraPausa.SetActive(false);
		sonidoTodo.SetFloat("VelAudio",1f);

	}

	public void PausarJuego(){

		if(Time.timeScale==1){

			Time.timeScale=0;
			botonPausa.color=Color.red;
			botonAnim.SetBool("PActivada",true);
			disparador.SetActive(false);
			mascaraPausa.SetActive(true);
			sonidoTodo.SetFloat("VelAudio",0f);

		}
		else{

			Time.timeScale=1;
			botonPausa.color=new Color(44f/255f,124f/255f,1); 	
			botonAnim.SetBool("PActivada",false);
			disparador.SetActive(true);
			mascaraPausa.SetActive(false);
			sonidoTodo.SetFloat("VelAudio",1f);

		}
		textoBoton.color = botonPausa.color;
	}

}
