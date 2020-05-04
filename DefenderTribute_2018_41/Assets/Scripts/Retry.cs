using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour {

	//[SerializeField] GameObject RetryPanel;
	public AudioSource sonidoBoton;
	
	public void Reintentar () {
		Time.timeScale = 1;
		sonidoBoton.enabled=true;
		SceneManager.LoadScene(Escenas.start);
		//Application.LoadLevel (Escenas.start);
	}
}
