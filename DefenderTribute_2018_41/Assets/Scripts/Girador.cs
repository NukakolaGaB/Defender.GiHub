 using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Girador : MonoBehaviour {


	public Marcador[] marcador;
	[SerializeField] bool panic;
	public Transform selectorpos;

	public Transform calibrador1;
	public Transform calibrador2;

	public float angulo;
	public float anguloAnt;
	public float radio1;
	public float radio2;
	float radio2Peque;
	float radio2Grande;
	public float radio;

	public Vector2 pos;
	public bool cogido;

	bool clickado;
	bool recienClickado;



	bool continuar;
	int seleccionado;
	bool ningunoSeleccionado;
	Vector3 posSeleccionado;
	float angSeleccionado;

	public AudioSource ruletaClick;
	public AudioClip clickSonido;
	public AudioSource ruletaSound;
	//bool clickNoplayed = false;
	bool clickNoplayed2 = false;

	[SerializeField] float calibrado = 2500f;

	public Button historia;

//	public Color colorSeleccionable;
//	public Color colorNoSeleccionable;
//	public Color colorSeleccionado;
	public Color colorTextoSeleccionable;
	public Color colorTextoNoSeleccionable;
	public Color colorTextoSeleccionado;
	public GameObject terxtoInfoCont;

	
	// Use this for initialization
	void Start () {
		ruletaSound = GetComponent<AudioSource> ();
		Puntuaciones.comienzaEnNivel=1;
		for (int i = 0; i < marcador.Length; i++) {
			if (marcador[i].nivel <= Puntuaciones.maxNivel || panic){
				marcador[i].seleccionable = true;
			} else {
				marcador[i].seleccionable = false;
			}
			ColorTexto (marcador[i].texto, marcador[i].seleccionable);
		}

		radio1 = (calibrador1.position - transform.position).sqrMagnitude;
		radio2Peque = (calibrador2.position - transform.position).sqrMagnitude;
		radio2 = radio2Peque;
		radio2Grande = 2 * radio2Peque - radio1;

	}
	
	// Update is called once per frame
	void Update () {

		if (Application.platform == RuntimePlatform.Android) {
			if (Input.touchCount > 0) {
				clickado = true;
				pos = Input.GetTouch (0).position - new Vector2 (transform.position.x, transform.position.y);
			} else {
				clickado = false;
//				anguloAnt = 0f;
			}
		} else if (Input.GetMouseButton (0)) {
			clickado = true;
			pos = Input.mousePosition - transform.position;
		} else {
			clickado = false;
//			anguloAnt = 0f;
		}
//		if (Input.touchCount > 0

//		pos = Input.mousePosition - transform.position;
		radio = pos.sqrMagnitude;
//		pos = transform.InverseTransformDirection (Input.mousePosition - transform.position);
		angulo = Angulo (pos.x, pos.y);

		if (clickado && radio > radio1 && radio < radio2) {
			cogido = true;
			radio2 = radio2Grande;
			historia.interactable=false;
			if (angulo - anguloAnt < 10 && angulo - anguloAnt > -10 && angulo != anguloAnt) { 
				//clickNoplayed = true;
				ruletaSound.enabled = true;
				transform.RotateAround (transform.position, transform.forward, angulo - anguloAnt);
			} else {
				ruletaSound.enabled = false;
			}

		} else if (cogido) {
			cogido = false;
			radio2 = radio2Peque;
			ruletaSound.enabled = false;
			historia.interactable=true;
			ningunoSeleccionado = true;
//			foreach (int i in marcador) {
			for (int i = 0; i < marcador.Length; i++) {
				if (marcador[i].seleccionable && (marcador[i].gameObject.transform.position - selectorpos.position).sqrMagnitude < calibrado && ningunoSeleccionado) {
					marcador[i].seleccionado = true;
					if (panic ) {
						Puntuaciones.dificultadPanic = marcador[i].panic;
					}
					Puntuaciones.comienzaEnNivel = marcador [i].nivel;
					continuar = marcador[i].continuar;
					if(continuar){

						terxtoInfoCont.SetActive(true);
					}
					else{
						terxtoInfoCont.SetActive(false);

					}
					ningunoSeleccionado = false;
					seleccionado = i;
					marcador[i].texto.color = colorTextoSeleccionado;

						clickNoplayed2 = true;
						
				} else {
					ColorTexto (marcador[i].texto, marcador[i].seleccionable);
					marcador[i].seleccionado = false;
				}
			}
			marcador[seleccionado].texto.color = colorTextoSeleccionado;
			marcador[seleccionado].seleccionado = true;
		}

		anguloAnt = angulo;

		if (!cogido) {
			posSeleccionado = marcador[seleccionado].gameObject.transform.position - transform.position;
			angSeleccionado = Angulo (posSeleccionado.x, posSeleccionado.y);
			if (angSeleccionado < 90 - 180 * Time.deltaTime || angSeleccionado > 270) {
				ruletaSound.enabled = true;
				clickNoplayed2 = true;
				transform.RotateAround (transform.position, transform.forward, 100 * Time.deltaTime);
			} else if (angSeleccionado > 90 + 180 * Time.deltaTime && angSeleccionado <= 270) {
				ruletaSound.enabled = true;
				clickNoplayed2 = true;
				transform.RotateAround (transform.position, transform.forward, -100 * Time.deltaTime);
			} else {
				transform.RotateAround (transform.position, transform.forward, 90 -angSeleccionado);
				if(clickNoplayed2){

					clickNoplayed2 = false;
					ruletaClick.PlayOneShot(clickSonido);
					//Debug.Log("Play dos");
				}				   
				ruletaSound.enabled = false;
			}
		}

	}

	float Angulo (float x, float y) {

		float ang = 0;

		if (x > 0 && y > 0) {
			ang = Mathf.Atan (y/x);
		} else if (x < 0 && y > 0) {
			ang = Mathf.PI - Mathf.Atan (-y/x);
		} else if (x < 0 && y < 0) {
			ang = Mathf.PI + Mathf.Atan (y/x);
		} else if (x > 0 && y < 0) {
			ang = 2*Mathf.PI - Mathf.Atan (-y/x);
		} else if (x == 0 && y > 0) {
			ang = Mathf.PI / 2;
		} else if (x == 0 && y < 0) {
			ang = 3 * Mathf.PI / 2;
		} else if (x < 0 && y == 0) {
			ang = Mathf.PI;
		} else if (x >= 0 && y == 0) {
			ang = 0;
		}
		return ang * 180 / Mathf.PI;
	}
	
//	void OnDestroy () {
//		if (continuar) {
//			CargarPartida();
//		}
//		InicializarEscenario (Puntuaciones.comienzaEnNivel);
//	}

	public void CargaInicializa () {
		if (continuar) {
			CargarPartida();
		}
		InicializarEscenario (Puntuaciones.comienzaEnNivel);
	}

	void CargarPartida () {

		Puntuaciones.score = PlayerPrefs.GetInt (Guardado.scorePartida, 0);
		Puntuaciones.comienzaEnNivel = PlayerPrefs.GetInt (Guardado.nivelPartida, 1);
		Puntuaciones.cuantosImpactan = PlayerPrefs.GetInt (Guardado.vidasPartida, 0);
		Puntuaciones.speed = PlayerPrefs.GetFloat (Guardado.speedPartida, Puntuaciones.speed);
		Puntuaciones.tiempoLanzar = PlayerPrefs.GetFloat (Guardado.tiempoLanzarPartida, Puntuaciones.tiempoLanzar);

	}

	void InicializarEscenario (int nuevoNivel) {
		if (nuevoNivel > 30) {
			Puntuaciones.randomCapa = true; //pasa de lanzar capas progresivamenta a hacerlo al azar
			Puntuaciones.scroll = 3;
			Puntuaciones.dchaIzda = true;
		} else if (nuevoNivel > 25) {
			Puntuaciones.randomCapa = true; //pasa de lanzar capas progresivamenta a hacerlo al azar
			Puntuaciones.scroll = 2;
			Puntuaciones.dchaIzda = false;
		} else if (nuevoNivel > 20) {
			Puntuaciones.randomCapa = true; //pasa de lanzar capas progresivamenta a hacerlo al azar
			Puntuaciones.scroll = 2;
			Puntuaciones.dchaIzda = true;
		} else if (nuevoNivel > 15) {
			Puntuaciones.randomCapa = false;
			Puntuaciones.scroll = 1;
			Puntuaciones.dchaIzda = false;
		} else if (nuevoNivel > 10) {
			Puntuaciones.randomCapa = false;
			Puntuaciones.scroll = 1;
			Puntuaciones.dchaIzda = true;
		} else if (nuevoNivel > 5) {
			Puntuaciones.randomCapa = false;
			Puntuaciones.scroll = 0;
			Puntuaciones.dchaIzda = false;
		} else {
			Puntuaciones.randomCapa = false;
			Puntuaciones.scroll = 0;
			Puntuaciones.dchaIzda = true;
		}
	}

	void ColorTexto (Text texto, bool seleccionable) {
		if (texto != null) {
			if (seleccionable) {
				texto.color = colorTextoSeleccionable;
			} else {
				texto.color = colorTextoNoSeleccionable;
			}
		}
	}


}
