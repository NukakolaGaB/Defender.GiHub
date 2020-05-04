using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SumadorBonus : MonoBehaviour {

	[Tooltip("Texto donde aparece el porcentaje de disparos acertados")]
	public Text porcentajeEfectividad;
	[Tooltip("El porcentaje  de disparos acertados")]
	public float porcentajeAciertos;

	public Text puntuacionFinal;

	[Tooltip("Texto donde aparecen los puntos a sumar")]
	[SerializeField] Text puntos;
	[Tooltip("Los puntos a sumar")]
	public int puntosASumar;
	
	[Tooltip("Texto del marcador")]
	[SerializeField] Text marcador;

	int trasvase;

	public float velocidadSumador;

	// Use this for initialization
	void Start () {

//		porcentajeEfectividad = GameObject.Find("PorcentajeEfectividad").GetComponent<Text>();
//		puntuacionFinal = GameObject.Find("PuntuacionFinal").GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

		trasvase = Mathf.CeilToInt (velocidadSumador * Time.deltaTime);

		if (puntosASumar >= trasvase) {
			puntosASumar -= trasvase;
			Puntuaciones.score += trasvase;
		} else {
			Puntuaciones.score += puntosASumar;
			puntosASumar = 0;
		}
		marcador.text = Puntuaciones.score.ToString ();
		puntos.text = puntosASumar.ToString ();

	}
}
