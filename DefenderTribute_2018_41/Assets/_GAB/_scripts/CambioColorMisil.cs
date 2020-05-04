using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CambioColorMisil : MonoBehaviour {

	public Image misil;
	public int escena;

	// Use this for initialization
	void Start () {
		// Create a temporary reference to the current scene.
		Scene currentScene = SceneManager.GetActiveScene();

		// Retrieve the index of the scene in the project's build settings.
		int buildIndex = currentScene.buildIndex;

		if (buildIndex == 2 ){
			misil.color=new Color(1,0,0,1);
		}
	}
}
