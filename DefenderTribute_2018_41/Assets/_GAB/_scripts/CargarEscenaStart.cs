using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CargarEscenaStart : MonoBehaviour {

	// Use this for initialization
	void Start () {

        SceneManager.LoadScene(Escenas.start);
		//Application.LoadLevel(Escenas.start);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
