using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CargarNivelSimple : MonoBehaviour {
	public int escena;
	AsyncOperation async;
	// Use this for initialization

	void Start(){
	
		StartCoroutine( PlayLevel ());
		//Debug.Log("cargada?" );
	
	}
	public IEnumerator PlayLevel () {
		//Application.LoadLevel(escena);
		//Application.LoadLevelAsync(escena);
		//Debug.Log("Loading start");
		//Debug.Log("cargada?" );
		async = SceneManager.LoadSceneAsync(escena);
		//async = Application.LoadLevelAsync(escena);
		async.allowSceneActivation = false;
		Application.backgroundLoadingPriority = ThreadPriority.Low;
		//Application.backgroundLoadingPriority = ThreadPriority.Low;
		yield return async;

	}
	public void Lanzala(){

		async.allowSceneActivation = true;


	}
}
