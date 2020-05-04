using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ResetGame : MonoBehaviour {

	public bool resetGame;

	[SerializeField] GameObject botonEsp;
	[SerializeField] GameObject botonEng;
	[SerializeField] GameObject botonEus;

	// Use this for initialization
	void Awake () {

		switch (Application.systemLanguage) {
		case SystemLanguage.Spanish:
			Idioma.elegido = 0;
			EventSystem.current.firstSelectedGameObject = botonEsp;
			break;
		case SystemLanguage.English:
			Idioma.elegido = 1;
			EventSystem.current.firstSelectedGameObject = botonEng;
			break;
		case SystemLanguage.Basque:
			Idioma.elegido = 2;
			EventSystem.current.firstSelectedGameObject = botonEus;
			break;
		default:
			Idioma.elegido = 1;
			EventSystem.current.firstSelectedGameObject = botonEng;
			break;
		}

		if(resetGame){
			PlayerPrefs.DeleteAll();
//			PlayerPrefs.DeleteKey("maximoNivel");
//			PlayerPrefs.DeleteKey(Guardado.vidasPartida);
//			PlayerPrefs.DeleteKey(Guardado.nivelPartida);
		
			resetGame=false;
		}
		Time.timeScale=1;
		Puntuaciones.indiceCanvasInfo = Random.Range (0, Puntuaciones.cuantosCanvasInfo);

		Puntuaciones.videosParaVer = 3;

		Puntuaciones.cuantosImpactan=0;
		Puntuaciones.cantEscudos = 0;
		Puntuaciones.dchaIzda = true;
		Puntuaciones.score = 0;
		Puntuaciones.nivel = 1;
		Puntuaciones.scroll = 0;
		Puntuaciones.ultimaCapa = 3;
		Puntuaciones.randomCapa = false;
		Puntuaciones.tiempoLanzar = 2;
		Puntuaciones.speed = Puntuaciones.speedInicial;
		Puntuaciones.maxNivel = PlayerPrefs.GetInt (Guardado.maximoNivel, 1);
		Puntuaciones.maxScore = PlayerPrefs.GetInt(Guardado.maximaPuntuacion, 0);
		Puntuaciones.maxScorePanic0 = PlayerPrefs.GetInt(Guardado.maximaPuntuacionPanic0, 0);
		Puntuaciones.maxScorePanic1 = PlayerPrefs.GetInt(Guardado.maximaPuntuacionPanic1, 0);
		Puntuaciones.maxScorePanic2 = PlayerPrefs.GetInt(Guardado.maximaPuntuacionPanic2, 0);
		Puntuaciones.maxScorePanic3 = PlayerPrefs.GetInt(Guardado.maximaPuntuacionPanic3, 0);
		Puntuaciones.poderMuro = false;
		Puntuaciones.poderLimpia = false;
		Puntuaciones.poderInfinito = false;
		Puntuaciones.usandoPoderInfinito = false;
		//PlayerPrefs.Save();
//		Puntuaciones.valeParaPremio = true;

		for (int i = 0; i < 5; i++) {
			Puntuaciones.nombresRecordP[i] = PlayerPrefs.GetString (Guardado.nombresPremio[i], Puntuaciones.nombresRecordP[i]);
			Puntuaciones.puntuacionesRecordP[i] = PlayerPrefs.GetInt (Guardado.scoresPremio[i], Puntuaciones.puntuacionesRecordP[i]);
			Puntuaciones.nivelRecordP[i] = PlayerPrefs.GetInt (Guardado.nivelesPremio[i], Puntuaciones.nivelRecordP[i]);

			Puntuaciones.nombresRecordPanic[i] = PlayerPrefs.GetString (Guardado.nombresPremioP[i], Puntuaciones.nombresRecordPanic[i]);
			Puntuaciones.puntuacionesRecordPanic[i] = PlayerPrefs.GetInt (Guardado.scoresPremioP[i], Puntuaciones.puntuacionesRecordPanic[i]);
			Puntuaciones.nivelRecordPanic[i] = PlayerPrefs.GetInt (Guardado.nivelesPremioP[i], Puntuaciones.nivelRecordPanic[i]);
		}
	}
	

}
