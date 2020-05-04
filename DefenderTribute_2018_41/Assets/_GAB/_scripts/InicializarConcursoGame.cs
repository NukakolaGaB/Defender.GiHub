using UnityEngine;
using System.Collections;

public class InicializarConcursoGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ParametrosConcurso(){

		Puntuaciones.comienzaEnNivel = 1;
		//Puntuaciones.valeParaPremio = true;
		Puntuaciones.panicMode = false;
		Puntuaciones.randomCapa = false;
		Puntuaciones.scroll = 0;
		Puntuaciones.dchaIzda = true;


	}
}
