using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CambioTiempoBarrera : MonoBehaviour {

	[SerializeField] Slider slider;

	public void CambiaDuracionBarrera () {
		Puntuaciones.duracionBarrera = slider.value;
	}
}
