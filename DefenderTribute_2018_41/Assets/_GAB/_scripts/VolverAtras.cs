using UnityEngine;
using System.Collections;

public class VolverAtras : MonoBehaviour {
	

	// Update is called once per frame
	void Update () {	

	
	if (Input.GetKeyDown(KeyCode.Escape)){ 
			//int Escena = Application.GetActiveScene().buildIndex;

				Application.LoadLevel(Application.loadedLevel-1);


			
		}
	}
}