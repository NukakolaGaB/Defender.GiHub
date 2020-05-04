using UnityEngine;
using System.Collections;

public class SelectorIdioma : MonoBehaviour {

	public void Castellano () {
		Idioma.elegido = 0;
	}
	public void English () {
		Idioma.elegido = 1;
	}
	public void Euskara () {
		Idioma.elegido = 2;
	}
}
