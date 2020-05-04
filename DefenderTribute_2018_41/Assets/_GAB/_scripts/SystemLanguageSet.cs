using UnityEngine;
using System.Collections;

public class SystemLanguageSet : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		switch (Application.systemLanguage) {

		case SystemLanguage.Spanish:
			Idioma.elegido=Idioma.castellano;
			break;
		case SystemLanguage.English:
			Idioma.elegido=Idioma.ingles;
			break;
		case SystemLanguage.Basque:
			Idioma.elegido=Idioma.euskera;
			break;
		default :
			Idioma.elegido=Idioma.castellano;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
