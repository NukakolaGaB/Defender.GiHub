using UnityEngine;
using System.Collections;

public class CargarNivelStart : MonoBehaviour {
	public int escena;
	public bool quit;

	public Animator tierraAnim;
	public Animator botonAnim;
	public Animator botonAnimConc;
	public Animator blancoAnim;


	public void Play(){

		if (quit) {
			Application.Quit();
		} else {
			Application.LoadLevel (escena);
		} 
	}
	public void SonidoBoton(){

		gameObject.GetComponent<AudioSource>().Play ();


	}

	public void TierraPlay(){

		tierraAnim.SetBool("Play",true);
		botonAnim.SetBool("Pressed",true);
		if (botonAnimConc != null) {
			botonAnimConc.SetBool ("Pressed", true);
		}
	}
	public void TierraPlay1(){

		escena = Escenas.seleccionModo;
		tierraAnim.SetBool("Play",true);
		botonAnim.SetBool("Pressed",true);
		if (botonAnimConc != null) {
			botonAnimConc.SetBool ("Pressed", true);
		}
	}
	public void TierraPlay2(){

		escena = Escenas.escenapuertas;
		tierraAnim.SetBool("Play",true);
		botonAnim.SetBool("Pressed",true);
		if (botonAnimConc != null) {
			botonAnimConc.SetBool ("Pressed", true);
		}
	}
	public void PlayBlanco(){


		blancoAnim.SetBool("playBlanco",true);

	}
}
