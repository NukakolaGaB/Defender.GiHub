using UnityEngine;
using System.Collections;

public class LanzarAnimacion : MonoBehaviour {

	public Animator animator;
	[SerializeField] Girador giradorHistoria;

	public void Panic () {
		Puntuaciones.panicMode = true;
		int azar = Random.Range (0,3);
		Puntuaciones.scroll = azar;
		if (azar == 0) {
			Puntuaciones.dchaIzda = true;
		} else {
			Puntuaciones.dchaIzda = false;
		}
		///Debug.Log (Puntuaciones.dchaIzda);
 	PlayAnimacion ();
	}
	public void History () {
		Puntuaciones.panicMode = false;
		giradorHistoria.CargaInicializa ();
		PlayAnimacion ();
	}

	public void PlayAnimacion(){


		animator.SetBool("Pulsado",true);

	}
	public void Sonido(){

		gameObject.GetComponent<AudioSource>().enabled=true;

	}
	
}
