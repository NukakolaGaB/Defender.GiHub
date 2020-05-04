using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	void OnEnable () {

		Time.timeScale = 0.5f;
		Invoke ("Reintentar", 0.5f);
	}
	

	public void Reintentar () {

		Time.timeScale = 1;
		//		if (Puntuaciones.panicMode) {
		//			Application.LoadLevel (Escenas.guardarnombre);
		//		} else {
		//			Application.LoadLevel (Escenas.start);
		//		}
		SceneManager.LoadScene(Escenas.guardarnombre);
		//Application.LoadLevel (Escenas.guardarnombre);
	}
}
