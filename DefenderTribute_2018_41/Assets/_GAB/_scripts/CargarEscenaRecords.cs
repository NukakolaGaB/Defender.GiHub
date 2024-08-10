using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class CargarEscenaRecords : MonoBehaviour {


	public void Play(){
		
		//Application.LoadLevelAdditive(3);
		
		SceneManager.LoadScene(Escenas.guardarnombre);
		//Debug.Log (Puntuaciones.dchaIzda +"de Play");
	}

}
