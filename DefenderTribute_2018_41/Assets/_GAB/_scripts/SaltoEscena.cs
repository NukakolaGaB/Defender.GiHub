using UnityEngine;
using System.Collections;

public class SaltoEscena : MonoBehaviour {

	bool activo=false;

	public int escena;

	void Update () {	
		
		
		if (Input.GetKeyDown(KeyCode.Escape)){ 
			//int Escena = Application.GetActiveScene().buildIndex;
			
			Application.LoadLevel(escena);
			
			
			
		}
	}
	public void VolverStart(){

		//Debug.Log ("Hago algo");
		if (activo) {
		
			Application.LoadLevel (escena);
		}
	}
	public void ActivarVolverStart(){

		activo = true;



	}
}
