using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Selector : MonoBehaviour {


	public SelectorRotatorio nivel1;
	public SelectorRotatorio nivel6;
	public SelectorRotatorio nivel11;
	public SelectorRotatorio nivel16;
	public SelectorRotatorio nivel21;
	public SelectorRotatorio nivel26;
	public SelectorRotatorio nivel31;
	public SelectorRotatorio continuar;
	
	public int nivelSeleccionado;

	// Use this for initialization
	void Awake () {

		nivel6.seleccionable = false;
		nivel11.seleccionable = false;
		nivel16.seleccionable = false;
		nivel21.seleccionable = false;
		nivel26.seleccionable = false;
		nivel31.seleccionable = false;
		continuar.seleccionable = true;
	
		if (Puntuaciones.maxNivel > 5) {
			nivel6.seleccionable = true;
			if (Puntuaciones.maxNivel > 10) {
				nivel11.seleccionable = true;
				if (Puntuaciones.maxNivel > 15) {
					nivel16.seleccionable = true;
					if (Puntuaciones.maxNivel > 20) {
						nivel21.seleccionable = true;
						if (Puntuaciones.maxNivel > 25) {
							nivel26.seleccionable = true;
							if (Puntuaciones.maxNivel > 30) {
								nivel31.seleccionable = true;
							}
						}
					}
				}
			}
		}
	}
	public void Seleccionar (SelectorRotatorio seleccionado) {

//		nivel1.seleccionadoDefinitivo = false;
//		nivel6.seleccionadoDefinitivo = false;
//		nivel11.seleccionadoDefinitivo = false;
//		nivel16.seleccionadoDefinitivo = false;
//		nivel21.seleccionadoDefinitivo = false;
//		nivel26.seleccionadoDefinitivo = false;
//		nivel31.seleccionadoDefinitivo = false;
//		continuar.seleccionadoDefinitivo = false;
//
//		seleccionado.seleccionadoDefinitivo = true;

		nivel1.seleccionado = false;
		nivel6.seleccionado = false;
		nivel11.seleccionado = false;
		nivel16.seleccionado = false;
		nivel21.seleccionado = false;
		nivel26.seleccionado = false;
		nivel31.seleccionado = false;
		continuar.seleccionado = false;
		
		seleccionado.seleccionado = true;

		Puntuaciones.comienzaEnNivel = seleccionado.nivel;
		nivelSeleccionado = seleccionado.nivel;

		if (seleccionado == continuar) {
			CargarPartida();
		}
		InicializarEscenario (Puntuaciones.comienzaEnNivel);
	}

	void CargarPartida () {
		Puntuaciones.score = PlayerPrefs.GetInt ("scorePartida", 0);
		Puntuaciones.comienzaEnNivel = PlayerPrefs.GetInt ("nivelPartida", 1);
		Puntuaciones.cuantosImpactan = PlayerPrefs.GetInt ("vidasPartida", 0);
		Puntuaciones.speed = PlayerPrefs.GetFloat ("speedPartida", Puntuaciones.speed);
		Puntuaciones.tiempoLanzar = PlayerPrefs.GetFloat ("tiempoLanzarPartida", Puntuaciones.tiempoLanzar);
//		Puntuaciones.scroll = PlayerPrefs.GetInt ("scrollPartida", 0);
//		int randomCapaPartida = PlayerPrefs.GetInt ("randomCapaPartida", 0);
//		if (randomCapaPartida == 1) {
//			Puntuaciones.randomCapa = true;
//		} else {
//			Puntuaciones.randomCapa = false;
//		}
//		int dchaIzdaPartida = PlayerPrefs.GetInt ("dchaIzdaPartida", 0);
//		if (dchaIzdaPartida == 1) {
//			Puntuaciones.dchaIzda = true;
//		} else {
//			Puntuaciones.dchaIzda = false;
//		}
	}

	void InicializarEscenario (int nuevoNivel) {
		if (nuevoNivel > 35) {
			Puntuaciones.randomCapa = true; //pasa de lanzar capas progresivamenta a hacerlo al azar
			Puntuaciones.scroll = 3;
			Puntuaciones.dchaIzda = true;
		} else if (nuevoNivel > 30) {
			Puntuaciones.randomCapa = true; //pasa de lanzar capas progresivamenta a hacerlo al azar
			Puntuaciones.scroll = 3;
			Puntuaciones.dchaIzda = false;
		}else if (nuevoNivel > 25) {
			Puntuaciones.randomCapa = true; //pasa de lanzar capas progresivamenta a hacerlo al azar
			Puntuaciones.scroll = 2;
			Puntuaciones.dchaIzda = true;
		} else if (nuevoNivel > 20) {
			Puntuaciones.randomCapa = true; //pasa de lanzar capas progresivamenta a hacerlo al azar
			Puntuaciones.scroll = 2;
			Puntuaciones.dchaIzda = false;
		} else if (nuevoNivel > 15) {
			Puntuaciones.randomCapa = false;
			Puntuaciones.scroll = 1;
			Puntuaciones.dchaIzda = true;
		} else if (nuevoNivel > 10) {
			Puntuaciones.randomCapa = false;
			Puntuaciones.scroll = 1;
			Puntuaciones.dchaIzda = false;
		} else if (nuevoNivel > 5) {
			Puntuaciones.randomCapa = false;
			Puntuaciones.scroll = 0;
			Puntuaciones.dchaIzda = true;
		} else {
			Puntuaciones.randomCapa = false;
			Puntuaciones.scroll = 0;
			Puntuaciones.dchaIzda = false;
		}
	}
}
