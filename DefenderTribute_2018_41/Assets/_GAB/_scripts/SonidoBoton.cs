using UnityEngine;
using System.Collections;

public class SonidoBoton : MonoBehaviour {

	private AudioSource sonidoBoton;

	public void PlaySonidoBoton(){

		sonidoBoton=gameObject.GetComponent<AudioSource>();
		sonidoBoton.enabled=true;
		Invoke ("DesactivarBoton", 0.16f);

	}
	public void DesactivarBoton(){

		sonidoBoton.enabled=false;


	}
}
