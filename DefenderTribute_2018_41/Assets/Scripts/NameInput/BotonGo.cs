using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BotonGo : MonoBehaviour {

	[Tooltip ("array con cada una de las letras para meter el nombre")] 
	[SerializeField] Text [] letras;

	[Tooltip("arrays con las casillas de los records")]
	[SerializeField] Text [] nombresP;
	[SerializeField] Text [] puntuacionesP;
	[SerializeField] Text [] nivelesP;


	string name = "";

	public int posicionEnTabla;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Go () {

		name = "";

		foreach (Text letra in letras) {
			name += letra.text;
		}
		if (Puntuaciones.panicMode) {
		
			Puntuaciones.nombresRecordPanic [posicionEnTabla] = name;
			nombresP [posicionEnTabla].text = name;
			Puntuaciones.puntuacionesRecordPanic [posicionEnTabla] = Puntuaciones.score;
			puntuacionesP [posicionEnTabla].text = Puntuaciones.puntuacionesRecordPanic [posicionEnTabla].ToString ();
			Puntuaciones.nivelRecordPanic [posicionEnTabla] = Puntuaciones.nivel;
			nivelesP [posicionEnTabla].text = Puntuaciones.nivelRecordPanic [posicionEnTabla].ToString ();
			//
			PlayerPrefs.SetString (Guardado.nombresPremioP [posicionEnTabla], name);
			PlayerPrefs.SetInt (Guardado.scoresPremioP [posicionEnTabla], Puntuaciones.score);
			PlayerPrefs.SetInt (Guardado.nivelesPremioP [posicionEnTabla], Puntuaciones.nivel);

		} else {
			Puntuaciones.nombresRecordP [posicionEnTabla] = name;
			nombresP [posicionEnTabla].text = name;
			Puntuaciones.puntuacionesRecordP [posicionEnTabla] = Puntuaciones.score;
			puntuacionesP [posicionEnTabla].text = Puntuaciones.puntuacionesRecordP [posicionEnTabla].ToString ();
			Puntuaciones.nivelRecordP [posicionEnTabla] = Puntuaciones.nivel;
			nivelesP [posicionEnTabla].text = Puntuaciones.nivelRecordP [posicionEnTabla].ToString ();
			//
			PlayerPrefs.SetString (Guardado.nombresPremio [posicionEnTabla], name);
			PlayerPrefs.SetInt (Guardado.scoresPremio [posicionEnTabla], Puntuaciones.score);
			PlayerPrefs.SetInt (Guardado.nivelesPremio [posicionEnTabla], Puntuaciones.nivel);
		}
		PlayerPrefs.Save ();

		gameObject.SetActive (false);
	}

}
