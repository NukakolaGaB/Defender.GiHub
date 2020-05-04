using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SaltoEscena : MonoBehaviour {

	bool activo=false;

	public int escena;

	void Update () {	
		
		
		if (Input.GetKeyDown(KeyCode.Escape)){
			//int Escena = Application.GetActiveScene().buildIndex;

			SceneManager.LoadScene(escena);
			//Application.LoadLevel(escena);
			
			
			
		}
	}
	public void VolverStart(){

		//Debug.Log ("Hago algo");
		if (activo) {

			SceneManager.LoadScene(escena);
			//Application.LoadLevel (escena);
		}
	}
	public void ActivarVolverStart(){

		activo = true;



	}
}
