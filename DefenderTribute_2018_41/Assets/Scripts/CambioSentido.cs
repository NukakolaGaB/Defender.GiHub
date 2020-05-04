using UnityEngine;
using System.Collections;

public class CambioSentido : MonoBehaviour {
	

	void Awake () {

		if (!Puntuaciones.dchaIzda) {
			CambiarSentido();
		}
	}

	public void CambiarSentido () {
		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
}
