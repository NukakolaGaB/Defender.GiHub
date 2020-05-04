using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorMisiones : MonoBehaviour {

	public LanzaMisiles2D lanzaMisiles2D;
	public Disparador2D disparador2D;
	public DanoDeMisiles danoDeMisiles;
	[SerializeField] SumadorBonus sumadorBonus;
	[Tooltip("Cuanto tiempo pasa entre la destruccion del ultimo misil y mostrar bonus")]
	[SerializeField] float tiempoEspera = 2;
	[Tooltip("Cuanto tiempo tarda el bonus en pasar a la puntuacion")]
	[SerializeField] float tiempoEspera2 = 1.4f;
	[SerializeField] GameObject bonusInterface;
	[SerializeField] GameObject panelJefe;
	[SerializeField] Text textoJefe;

	#region interface

	[Tooltip("Texto del marcador")]
	[SerializeField] Text marcador;	
	[Tooltip("Texto de la maxima puntuacion")]
	[SerializeField] Text maxPuntos;
	[Tooltip("Nivel de dificultad (dentro de la escena)")]
	[SerializeField] Text nivel;
	[Tooltip("Nivel de dificultad (bonus)")]
	[SerializeField] Text nivelBonus;
	[Tooltip("Texto con cuantos misiles tiene que destruir")]
	[SerializeField] Text misilesTotalesText;
	[Tooltip("Texto con cuantos misiles quedan por destruir")]
	[SerializeField] Text misilesDestruidosText;
	
	#endregion


	[SerializeField] Transform posScroll;

	public int misilesDerribados;
	public int misilesEnVuelo;
	bool ultimoMisil = false;

	bool proteusReady;

	public int puntuacionNivel;
	public int porcentaje;

	//para cuantas vidas perdidas te da oportunidad de recuperar una
	int fallosSalvar = 0;

	[SerializeField] GameObject jefeFinal;

	// Use this for initialization
	void Awake () {

		bonusInterface.SetActive (false);

	}

	void Start () {

		Accessos.controladorMisiones = this;

		proteusReady = true;

		if (Puntuaciones.panicMode) {
			for (int i = 0; i < Puntuaciones.dificultadPanic; i++) {
				IncrementoDificultad ();
			}
		} else if (Puntuaciones.nivel < Puntuaciones.comienzaEnNivel) {
			PonerseEnNivel (Puntuaciones.comienzaEnNivel);
			Accessos.randomizeMusica.ElegirMusica();
		}


		CambiarScroll (Puntuaciones.scroll);

		marcador.text  = Puntuaciones.score.ToString();
		nivel.text = Puntuaciones.nivel.ToString ();

		//poner el record en el marcador
		if (Puntuaciones.panicMode) {
			switch (Puntuaciones.dificultadPanic) {
			case 0:
				maxPuntos.text = Puntuaciones.maxScorePanic0.ToString ();
				break;
			case 1:
				maxPuntos.text = Puntuaciones.maxScorePanic1.ToString ();
				break;
			case 2:
				maxPuntos.text = Puntuaciones.maxScorePanic2.ToString ();
				break;
			case 3:
				maxPuntos.text = Puntuaciones.maxScorePanic3.ToString ();
				break;
			}
		} else {
			maxPuntos.text = Puntuaciones.maxScore.ToString ();
		}

		// poner cada cuantos misiles se sube de nivel en el canvas:	
		misilesTotalesText.text = Puntuaciones.misilesTotales.ToString ();
		

		//		CargarNivel (Puntuaciones.nivel);
		ActivarLanzador ();
	}

	public void OnEnable(){

		if(Puntuaciones.poderMuro){

			Accessos.poderes.ActivarBotonMuro();

		}
		if(Puntuaciones.poderLimpia){

			Accessos.poderes.ActivarBotonLimpia();

		}
		if(Puntuaciones.poderInfinito){

			Accessos.poderes.ActivarBotonInfin();

		}
	}


	public void MisilDerribado (int puntos, int multiplCombo) {
		
		misilesDerribados++;
		misilEnVueloMenos ();
		misilesDestruidosText.text = (misilesDerribados).ToString ();
		Puntuaciones.score += puntos * multiplCombo;
		marcador.text = Puntuaciones.score.ToString ();
		puntuacionNivel += puntos;
	}

	public void PuntosJefe (int puntos) {
		Puntuaciones.score += puntos;
		marcador.text = Puntuaciones.score.ToString ();
	}

	int CalculoBonus () {

		if (disparador2D.proyDisparados != 0) {
			return puntuacionNivel * misilesDerribados / disparador2D.proyDisparados;
		} else {
			return 0;
		}

	}

	public void misilEnVueloMenos () {
		misilesEnVuelo--;
		if (ultimoMisil && misilesEnVuelo == 0) {
			ultimoMisil = false;
			Invoke ("FinNivel", tiempoEspera);
		}
	}

	public void LanzadoUltimoMisil () {
		if (Puntuaciones.panicMode) {
			Puntuaciones.nivel++;
			if(Puntuaciones.nivel==10 || Puntuaciones.nivel==20 ||Puntuaciones.nivel==30 ){
				Accessos.randomizeMusica.ElegirMusica();

			}
			for (int i = 0; i <= Puntuaciones.dificultadPanic; i++) {
			IncrementoDificultad ();
			}
			nivel.text = Puntuaciones.nivel.ToString ();
			ActivarLanzador ();
		} else {
			ultimoMisil = true;
		}
	}

	public void NoLanzadoUltimoMisil () {
		ultimoMisil = false;
	}


	void FinNivel () {
		bonusInterface.SetActive (true);
		nivelBonus.text = Puntuaciones.nivel.ToString ();
		if (disparador2D.proyDisparados != 0) {
			porcentaje = 100 * misilesDerribados / disparador2D.proyDisparados;
		} else {
			porcentaje = 0;
		}
		sumadorBonus.porcentajeEfectividad.text = porcentaje.ToString()+"%";
		sumadorBonus.puntuacionFinal.text = puntuacionNivel.ToString ();
		sumadorBonus.velocidadSumador = 0f;
		sumadorBonus.puntosASumar = CalculoBonus ();
		gameObject.GetComponent<AudioSource>().enabled=false;
		Invoke ("Trasvasar", 1.5f);
	}

	void Trasvasar () {
		gameObject.GetComponent<AudioSource>().enabled=true;
		if (Puntuaciones.nivel == 10 || Puntuaciones.nivel == 30 || Puntuaciones.nivel == 20 || Puntuaciones.nivel == 40) {
			Invoke ("PanelJefe", tiempoEspera2);
		} else {
			Invoke ("SiguienteNivel", tiempoEspera2);
		}
		sumadorBonus.velocidadSumador = ((float)( CalculoBonus ())) / tiempoEspera2;
	}

	void SiguienteNivel () {
		Puntuaciones.nivel++;
		Puntuaciones.comienzaEnNivel = Puntuaciones.nivel; //para que el texto de puertas sepa que nivel es.
		IncrementoDificultad ();
		nivel.text = Puntuaciones.nivel.ToString ();
		misilesDerribados = 0;
		disparador2D.ResetDisparados();
		Invoke ("DesactivarBonusInt", 0.5f);
		CargarNivel (Puntuaciones.nivel);
	}

	void DesactivarBonusInt () {
		bonusInterface.SetActive (false);
	}
	void PanelJefe(){

		Invoke ("DesactivarBonusInt", 0.5f);
		Invoke ("ActivarPanelJefe", 1);
	}
	void ActivarPanelJefe(){

		if (Puntuaciones.nivel == 10) {
			textoJefe.text = "Grumlock";
		}else if (Puntuaciones.nivel == 30) {
			textoJefe.text = "Hyper Grumlock";
		}else if (Puntuaciones.nivel == 20) {
			textoJefe.text = "Glumpher";
		}else if (Puntuaciones.nivel == 40) {
			textoJefe.text = "Hyper Glumpher";
		}
		panelJefe.SetActive(true);
		Invoke ("CargarJefeFinal", tiempoEspera2+2);

	
	}
	void CargarJefeFinal () {
		//Aqui se lanza el jefe final y cuando este muera se hace CargarNivel (Puntuaciones.nivel)
		if (Puntuaciones.nivel == 10 ) {
			Instantiate(Resources.Load ("Naves/Jefe1") as GameObject, new Vector3 (-26.6f, 1.86f, 45.63f), Quaternion.identity);
			panelJefe.SetActive (false);
			danoDeMisiles.jefeEnAccion = true;
		}
		else if (Puntuaciones.nivel == 30) {
			Instantiate(Resources.Load ("Naves/Jefe3") as GameObject, new Vector3 (-26.6f, 1.86f, 45.63f), Quaternion.identity);
			panelJefe.SetActive (false);
			danoDeMisiles.jefeEnAccion = true;
		}
		else if ( Puntuaciones.nivel == 20) {
			Instantiate(Resources.Load ("Naves/Jefe2") as GameObject, new Vector3 (-26.6f, 1.86f, 45.63f), Quaternion.identity);
			danoDeMisiles.jefeEnAccion = true;
			panelJefe.SetActive (false);
		}
		else if (Puntuaciones.nivel == 40) {
			Instantiate(Resources.Load ("Naves/Jefe4") as GameObject, new Vector3 (-26.6f, 1.86f, 45.63f), Quaternion.identity);
			danoDeMisiles.jefeEnAccion = true;
			panelJefe.SetActive (false);
		}
		else {
			SiguienteNivel ();
		}
	}
	public void MuerteJefeFinal () {

		danoDeMisiles.jefeEnAccion = false;
		Invoke("SiguienteNivel",2f);
	}

	void CargarNivel (int nivelCargado) {



		switch (nivelCargado) {
		case 6:
			GuardarNivel();
			Puntuaciones.dchaIzda = !Puntuaciones.dchaIzda;
			SceneManager.LoadScene (Escenas.escenapuertas);
			break;
		case 11:
			GuardarNivel();
			SiguienteScroll();
			Puntuaciones.dchaIzda = !Puntuaciones.dchaIzda;
			SceneManager.LoadScene(Escenas.escenapuertas);
			break;
		case 16:
			GuardarNivel();
			Puntuaciones.dchaIzda = !Puntuaciones.dchaIzda;
			SceneManager.LoadScene(Escenas.escenapuertas);
			break;
		case 21:
			GuardarNivel();
			Puntuaciones.randomCapa = true; //pasa de lanzar capas progresivamenta a hacerlo al azar
			SiguienteScroll();
			Puntuaciones.dchaIzda = !Puntuaciones.dchaIzda;
			SceneManager.LoadScene(Escenas.escenapuertas);
			break;
		case 26:
			GuardarNivel();
			Puntuaciones.dchaIzda = !Puntuaciones.dchaIzda;
			SceneManager.LoadScene(Escenas.escenapuertas);
			break;
		case 31:
			GuardarNivel();
			SiguienteScroll();
			Puntuaciones.dchaIzda = !Puntuaciones.dchaIzda;
			SceneManager.LoadScene(Escenas.escenapuertas);
			break;
		case 36:
			GuardarNivel();
			Puntuaciones.dchaIzda = !Puntuaciones.dchaIzda;
			SceneManager.LoadScene(Escenas.escenapuertas);
			break;
		case 41:
			GuardarNivel();
			SceneManager.LoadScene(Escenas.juegoSuperado);
			break;
		default:
			ActivarLanzador ();
			break;
		}

	}

	void ActivarLanzador () {

		lanzaMisiles2D.misilesPorLanzar = Puntuaciones.misilesTotales;
		misilesDestruidosText.text = (misilesDerribados).ToString ();

	}

	void SiguienteScroll () {
		Puntuaciones.scroll++;
		if (Puntuaciones.scroll >= 4/*scroll.Length*/) {
			Puntuaciones.scroll = 0;
		}
	}

	void CambiarScroll (int numScroll) {

		Instantiate(Resources.Load ("scroll"+numScroll.ToString()) as GameObject ,posScroll.position,posScroll.localRotation);

	}

	public void ChequeaLanzaProteus () {
		if (Puntuaciones.cuantosImpactan > fallosSalvar && proteusReady) {
			Invoke ("LanzaProteus", Random.Range (5, 35));
			fallosSalvar++;
			proteusReady = false;
		}
	}

	void LanzaProteus () {
		//aqui se puede anadir mensaje de aviso que viene
		int capaBonus = Random.Range (3, 6);
		lanzaMisiles2D.LanzaBonusPersecucion (capaBonus);
		proteusReady = true;
	}

	void PonerseEnNivel (int nuevoNivel) {
		while (Puntuaciones.nivel < nuevoNivel) {
			Puntuaciones.nivel++;
			IncrementoDificultad ();
			nivel.text = Puntuaciones.nivel.ToString ();
		}

		if (nuevoNivel > 30) {
			Puntuaciones.randomCapa = true; //pasa de lanzar capas progresivamenta a hacerlo al azar
			Puntuaciones.scroll = 3;
		} else if (nuevoNivel > 20) {
			Puntuaciones.randomCapa = true; //pasa de lanzar capas progresivamenta a hacerlo al azar
			Puntuaciones.scroll = 2;
		} else if (nuevoNivel > 10) {
			Puntuaciones.scroll = 1;
		} else {
			Puntuaciones.scroll = 0;
		}
	}

	void GuardarNivel () {
		if (!Puntuaciones.panicMode && Puntuaciones.nivel > Puntuaciones.maxNivel) {
			int scoreAnt = PlayerPrefs.GetInt (Guardado.scorePartida, 0);
			if (Puntuaciones.score > scoreAnt) {
				GuardarPartida (); //guarda la situacion de partida para poder retomarla con continuar (cont.)
			}
			Puntuaciones.maxNivel = Puntuaciones.nivel;
			PlayerPrefs.SetInt (Guardado.maximoNivel, Puntuaciones.maxNivel);
			PlayerPrefs.Save();
		}
	}

	#region funciones dificultad
	public void OtraCapa () {
		if (Puntuaciones.ultimaCapa < 9) {
			Puntuaciones.ultimaCapa++;
		}
	}
	public void UnaSolaCapa () {
		Puntuaciones.ultimaCapa = 3;
	}

	public void Xcapas (int x) {
		if (x < 8) {
			Puntuaciones.ultimaCapa = x + 2;
		} else if (x < 1) {
			Puntuaciones.ultimaCapa = 3;
		} else {
			Puntuaciones.ultimaCapa = 9;
		}
	}
	
	public void MasRapido () {
		if (Puntuaciones.tiempoLanzar > Puntuaciones.tiempoLanzarMin) {
			Puntuaciones.tiempoLanzar -= 0.5f;
		} else {
			Puntuaciones.speed *= 1.05f;
		}
	}
	public void Lento () {
		Puntuaciones.tiempoLanzar = 3f;
	}
	
	public void IncrementoDificultad () {
		if (Puntuaciones.ultimaCapa < Puntuaciones.limiteAbsolutoCapas) {
			OtraCapa();
		} else {
			UnaSolaCapa ();
			MasRapido ();
		}
		if (Puntuaciones.nivel > 5) {
			Puntuaciones.cantEscudos += 0.05f;
			if (Puntuaciones.cantEscudos > 2) {
				Puntuaciones.cantEscudos = 2;
			}
		}
	}
	#endregion


	void OnDestroy () {
		GuardarRecord ();
		PlayerPrefs.Save();
	}

	public void GuardarRecord () {

		if (!Puntuaciones.panicMode && Puntuaciones.score > Puntuaciones.maxScore) {
			Puntuaciones.maxScore = Puntuaciones.score;
			PlayerPrefs.SetInt (Guardado.maximaPuntuacion, Puntuaciones.score);
		} else if (Puntuaciones.panicMode) {
			if (Puntuaciones.dificultadPanic == 0 && Puntuaciones.score > Puntuaciones.maxScorePanic0) {
				Puntuaciones.maxScorePanic0 = Puntuaciones.score;
				PlayerPrefs.SetInt (Guardado.maximaPuntuacionPanic0, Puntuaciones.score);
			} else if (Puntuaciones.dificultadPanic == 1 && Puntuaciones.score > Puntuaciones.maxScorePanic1) {
				Puntuaciones.maxScorePanic1 = Puntuaciones.score;
				PlayerPrefs.SetInt (Guardado.maximaPuntuacionPanic1, Puntuaciones.score);
			} else if (Puntuaciones.dificultadPanic == 2 && Puntuaciones.score > Puntuaciones.maxScorePanic2) {
				Puntuaciones.maxScorePanic2 = Puntuaciones.score;
				PlayerPrefs.SetInt (Guardado.maximaPuntuacionPanic2, Puntuaciones.score);
			} else if (Puntuaciones.dificultadPanic == 3 && Puntuaciones.score > Puntuaciones.maxScorePanic3) {
				Puntuaciones.maxScorePanic3 = Puntuaciones.score;
				PlayerPrefs.SetInt (Guardado.maximaPuntuacionPanic3, Puntuaciones.score);
			}
		}
	}

	void GuardarPartida () {
		if (!Puntuaciones.panicMode && Puntuaciones.nivel<40) {
			PlayerPrefs.SetInt (Guardado.scorePartida, Puntuaciones.score);
			PlayerPrefs.SetInt (Guardado.nivelPartida, Puntuaciones.comienzaEnNivel);
			PlayerPrefs.SetInt (Guardado.vidasPartida, Puntuaciones.cuantosImpactan);
			PlayerPrefs.SetFloat (Guardado.speedPartida, Puntuaciones.speed);
			PlayerPrefs.SetFloat (Guardado.tiempoLanzarPartida, Puntuaciones.tiempoLanzar);
		}
		
	}

}
