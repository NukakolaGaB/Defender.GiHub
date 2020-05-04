using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectorNivel : MonoBehaviour {

//	[SerializeField] Slider selector;
	public GameObject nivel1;
	public GameObject nivel6;
	public GameObject nivel11;
	public GameObject nivel16;
	public GameObject nivel21;
	public GameObject nivel26;
	public GameObject nivel31;
	public GameObject continuar;

	// Use this for initialization
	void Start () {

		nivel6.SetActive(false);
		nivel11.SetActive(false);
		nivel16.SetActive(false);
		nivel21.SetActive(false);
		nivel26.SetActive(false);
		nivel31.SetActive(false);
		continuar.SetActive(false);

//		selector.maxValue = Puntuaciones.maxNivel;

			nivel1.SetActive(true);
	
		if (Puntuaciones.maxNivel > 5) {
			nivel6.SetActive(true);
			if (Puntuaciones.maxNivel > 10) {
				nivel11.SetActive(true);
				if (Puntuaciones.maxNivel > 15) {
					nivel16.SetActive(true);
					if (Puntuaciones.maxNivel > 20) {
						nivel21.SetActive(true);
						if (Puntuaciones.maxNivel > 25) {
							nivel26.SetActive(true);
							if (Puntuaciones.maxNivel > 30) {
								nivel31.SetActive(true);
								
							}
						}
					}
				}
			}
		}
	}
	public void Nivel1 () {
		Puntuaciones.comienzaEnNivel = 1;
	}
	public void Nivel6 () {
		Puntuaciones.comienzaEnNivel = 6;
	}
	public void Nivel11 () {
		Puntuaciones.comienzaEnNivel = 11;
	}
	public void Nivel16 () {
		Puntuaciones.comienzaEnNivel = 16;
	}
	public void Nivel21 () {
		Puntuaciones.comienzaEnNivel = 21;
	}
	public void Nivel26 () {
		Puntuaciones.comienzaEnNivel = 26;
	}
	public void Nivel31 () {
		Puntuaciones.comienzaEnNivel = 31;
	}
	public void Continuar () {

	}
//	public void CambiarNivel () {
////		int nivel = Mathf.CeilToInt (selector.value);
//		switch (nivel) {
//		case 1:
//			Puntuaciones.comienzaEnNivel = 1;
//			break;
//		case 2:
//			Puntuaciones.comienzaEnNivel = 11;
//			break;
//		case 3:
//			Puntuaciones.comienzaEnNivel = 21;
//			break;
//		case 4:
//			Puntuaciones.comienzaEnNivel = 31;
//			break;
//		default:
//			Puntuaciones.comienzaEnNivel = 1;
//			break;
//		}
//	}

}
