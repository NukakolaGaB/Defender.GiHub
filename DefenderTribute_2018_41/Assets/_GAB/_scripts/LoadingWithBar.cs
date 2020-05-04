using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingWithBar : MonoBehaviour {

	//[SerializeField] Image barraCarga;
	[SerializeField] Slider barraCarga;
	[SerializeField] AudioSource audioGinkgo;

	// Use this for initialization
	public void EmpezarCarga () {
		StartCoroutine(AsynchronousLoad (1));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator AsynchronousLoad (int scene)
	{
		yield return null;

		AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
		//AsyncOperation ao = Application.LoadLevelAsync(scene);
		ao.allowSceneActivation = false;
		
		while (! ao.isDone )
		{
			// [0, 0.9] > [0, 1]
			//float progress = Mathf.Clamp01(ao.progress / 0.9f);
			barraCarga.value=ao.progress;
			float carga = Mathf.Lerp(barraCarga.value,ao.progress,0.5f);
			//Debug.Log("Loading progress: " + (progress * 100) + "%");
			
			// Loading completed
			if (ao.progress == 0.9f)
			{

					ao.allowSceneActivation = true;
			}
			//Debug.Log(carga);
			yield return null;
		}
	}
	public void LanzarAudioGinkgo(){
	
		audioGinkgo.Play ();
	
	
	}
}
