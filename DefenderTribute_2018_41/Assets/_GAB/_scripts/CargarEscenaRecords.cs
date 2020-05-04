using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;


public class CargarEscenaRecords : MonoBehaviour {


	public void Play(){
		
		//Application.LoadLevelAdditive(3);
		
		EditorSceneManager.LoadScene(Escenas.guardarnombre);
		//Debug.Log (Puntuaciones.dchaIzda +"de Play");
	}

}
