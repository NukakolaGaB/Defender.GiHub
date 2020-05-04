using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class VolverAtras : MonoBehaviour {

	Scene currentScene;
	int buildIndex;
	private void Start()
	{
		// Create a temporary reference to the current scene.
		currentScene = SceneManager.GetActiveScene();

		// Retrieve the index of the scene in the project's build settings.
		buildIndex = currentScene.buildIndex;
	}
	
	// Update is called once per frame
	void Update () {	

	
	if (Input.GetKeyDown(KeyCode.Escape)){
			//int Escena = Application.GetActiveScene().buildIndex;

			SceneManager.LoadScene(buildIndex - 1);
				//Application.LoadLevel(Application.loadedLevel-1);


			
		}
	}
}