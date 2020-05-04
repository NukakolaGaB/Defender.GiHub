using UnityEngine;
using System.Collections;

public class Retry : MonoBehaviour {

	//[SerializeField] GameObject RetryPanel;
	public AudioSource sonidoBoton;
	
	public void Reintentar () {
		Time.timeScale = 1;
		sonidoBoton.enabled=true;
		Application.LoadLevel (Escenas.start);
	}
}
