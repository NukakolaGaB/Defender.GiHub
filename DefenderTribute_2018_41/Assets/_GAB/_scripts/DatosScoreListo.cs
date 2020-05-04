using UnityEngine;
using System.Collections;

public class DatosScoreListo : MonoBehaviour {

	public Animator scrollAnim;
	public GameObject panelDatos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void DatosFin(){

		panelDatos.SetActive(false);
		scrollAnim.SetBool ("Listo", true);

	}
}
