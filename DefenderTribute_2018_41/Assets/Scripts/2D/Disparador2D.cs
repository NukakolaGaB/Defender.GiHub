using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Disparador2D : MonoBehaviour {
	
	public ControladorMisiones controladorMisiones;


	
	[Tooltip("prefab del disparo")]
	[SerializeField] GameObject proyectil;
	
	[Tooltip("Cuantos disparos se puede hacer a la vez")]
	[SerializeField] int numDisparos = 3;

	[SerializeField]AudioSource audioDisparos;
	[SerializeField]AudioSource audioEscudo;
	[SerializeField]AudioSource audioFinPoder;

	[Tooltip("Texto con cuantos disparos ha hecho en total")]
	[SerializeField] Text proyDisparadosText;
	public int proyDisparados;


	[Tooltip("Siguiente escena (int)")]
	public int escena;
	
	
	[Tooltip("cada cuantos misiles destruidos aumenta dificultad")]

	
	[SerializeField]SpritesTiros spritestiros;
	
	[Tooltip("Tiempo que tiene para poder hacer combo")]
	[SerializeField] float tiempoCombo;
	float contadorCombo = 2f;
	[Tooltip("prefab del aviso combo!")]
	[SerializeField] GameObject combo;
	int multiplicadorCombo = 1;

	void Awake () {
		Accessos.disparador2D = this;
		Puntuaciones.usandoPoderInfinito = false;
	}

	// Use this for initialization
	void Start () {

		spritestiros.Refresh (numDisparos);
		SimplePool.Preload(proyectil, 3);
		SimplePool.Preload(combo, 1);
	}

	
	// Update is called once per frame
	void Update () {

		contadorCombo += Time.deltaTime;
	}
	
	public void Disparar (float x, float y) {

		if (numDisparos > 0) {
			//decrementa el nº de disparos, los proyectiles lo aumentan al destruirse
			numDisparos--;
			spritestiros.Refresh (numDisparos);

			proyDisparados++;
			proyDisparadosText.text = proyDisparados.ToString();
			audioDisparos.Play();

			SimplePool.Spawn(proyectil, new Vector3 (x, y, 1f), transform.rotation);


		}
		
	}
	/// <summary>
	/// Incrementa en 1 el numero de disparos.
	/// </summary>
	public void Annadir1disparo () {
		
		if(numDisparos<3 ){
			
			numDisparos++;
			spritestiros.Refresh (numDisparos);

		}
	}

	public void DisparosInfinitos(){
	
		numDisparos = 1000;
		spritestiros.Refresh (numDisparos);

	}
	public void DisparosInfinitosDesact(){

		audioFinPoder.Play ();
		numDisparos = 3;
		spritestiros.Refresh (numDisparos);
		Puntuaciones.usandoPoderInfinito = false;
		//Debug.Log("desactivado");
	}

    //Interface
	public void Restar1disparo () {
		
		proyDisparados--;;
		proyDisparadosText.text = proyDisparados.ToString();
		audioEscudo.Play();
	}

	public void IncrementarProyDisparados () {
		proyDisparados++;;
		proyDisparadosText.text = proyDisparados.ToString();
	}


	public void ResetDisparados () {
		proyDisparados = 0;
		proyDisparadosText.text = proyDisparados.ToString();
	}

	/// <summary>
	/// Suma los puntos de los misiles normales.
	/// </summary>
	/// <param name="x">Puntos a sumar.</param>
	/// <param name="pos">Posicion del acierto (para poner el multiplicador).</param>
	public void Sumarpunto (int x, Vector3 pos) {

		if (contadorCombo < tiempoCombo) {
			multiplicadorCombo *= 2;
			GameObject comboSignal = SimplePool.Spawn (combo, pos, transform.rotation) as GameObject;
			comboSignal.GetComponent<TextMesh>().text = "x"+multiplicadorCombo.ToString();
			if(multiplicadorCombo==2){
				
				int recompensa;
					if (Puntuaciones.cuantosImpactan > 0) {
					
						recompensa = Random.Range (0, 8);

					} else {
						recompensa = Random.Range (1, 8);

					}
				if (recompensa < 4) {
					Accessos.lanzaMisiles2D.LanzaBonusPersecucion (Random.Range (3, 7), recompensa);
				}

			}
		} else {
			multiplicadorCombo = 1;
		}
		contadorCombo = 0;
		controladorMisiones.MisilDerribado (x, multiplicadorCombo);

	}

	/// <summary>
	/// Suma los puntos de los misiles del jefe.
	/// </summary>
	/// <param name="x">Puntos a sumar.</param>
	public void SumarPuntoJefe (int x) {
		controladorMisiones.PuntosJefe (x);
	}
}

