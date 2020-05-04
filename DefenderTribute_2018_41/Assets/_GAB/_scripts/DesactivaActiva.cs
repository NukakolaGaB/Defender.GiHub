using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DesactivaActiva : MonoBehaviour {

	[SerializeField] GameObject padreInfo;
	[SerializeField] GameObject padreCohetes;


	// Use this for initialization
	void Start () {

		padreCohetes.SetActive(false);
		padreInfo.SetActive(true);
	
	}
	
	// Update is called once per frame
	public void ActivarJuego () {
	

		padreCohetes.SetActive(true);
		padreInfo.SetActive(false);

	}
	public void ActivarInfo () {
		
		
		padreCohetes.SetActive(false);
		padreInfo.SetActive(true);
		
	}
	public void CargarEscena(){

		SceneManager.LoadScene(Escenas.seleccionModo);
		//Application.LoadLevel(Escenas.seleccionModo);



	}
}
