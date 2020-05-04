using UnityEngine;
using System.Collections;

public class ResetPlayerPrefs : MonoBehaviour {

	public int misilesTotales = 10;
	//public bool panicMode = true;
	public int maxNivel = 1;
	public int cuantosImpactan;

	// Use this for initialization
	void Awake () {

		Puntuaciones.misilesTotales=misilesTotales;
		//Puntuaciones.panicMode=panicMode;
		Puntuaciones.maxNivel=maxNivel;
		Puntuaciones.cuantosImpactan=cuantosImpactan;
		
	}
}
