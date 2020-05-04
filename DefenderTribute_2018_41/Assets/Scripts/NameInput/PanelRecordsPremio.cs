using UnityEngine;
using System.Collections;

public class PanelRecordsPremio : MonoBehaviour {

	[SerializeField] GameObject nameInput;
	public Animator scrollAnimator;

	// Use this for initialization
	void Start () {
		if (!Puntuaciones.panicMode) {

			for (int i = 0; i < 5; i++) {
				if (Puntuaciones.score > Puntuaciones.puntuacionesRecordP [i]) {
					for (int j = 4; j > i; j--) {
						Puntuaciones.puntuacionesRecordP [j] = Puntuaciones.puntuacionesRecordP [j - 1];
						Puntuaciones.nivelRecordP [j] = Puntuaciones.nivelRecordP [j - 1];
						Puntuaciones.nombresRecordP [j] = Puntuaciones.nombresRecordP [j - 1];

						PlayerPrefs.SetInt (Guardado.scoresPremio [j], Puntuaciones.puntuacionesRecordP [j]);
						PlayerPrefs.SetInt (Guardado.nivelesPremio [j], Puntuaciones.nivelRecordP [j]);
						PlayerPrefs.SetString (Guardado.nombresPremio [j], Puntuaciones.nombresRecordP [j]);
					}
					Puntuaciones.puntuacionesRecordP [i] = Puntuaciones.score;
					Puntuaciones.nivelRecordP [i] = Puntuaciones.nivel;
					CambiarNombre (i);
					i = 5;
				} else if (i == 4) {

					scrollAnimator.SetBool ("Listo", true);
				}
			}
		} else {

			for (int i = 0; i < 5; i++) {
				if (Puntuaciones.score > Puntuaciones.puntuacionesRecordPanic [i]) {
					for (int j = 4; j > i; j--) {
						Puntuaciones.puntuacionesRecordPanic [j] = Puntuaciones.puntuacionesRecordPanic [j - 1];
						Puntuaciones.nivelRecordPanic [j] = Puntuaciones.nivelRecordPanic [j - 1];
						Puntuaciones.nombresRecordPanic [j] = Puntuaciones.nombresRecordPanic [j - 1];
						
						PlayerPrefs.SetInt (Guardado.scoresPremioP [j], Puntuaciones.puntuacionesRecordPanic [j]);
						PlayerPrefs.SetInt (Guardado.nivelesPremioP [j], Puntuaciones.nivelRecordPanic [j]);
						PlayerPrefs.SetString (Guardado.nombresPremioP [j], Puntuaciones.nombresRecordPanic [j]);
					}
					Puntuaciones.puntuacionesRecordPanic [i] = Puntuaciones.score;
					Puntuaciones.nivelRecordPanic [i] = Puntuaciones.nivel;
					CambiarNombre (i);
					i = 5;
				} else if (i == 4) {
					
					scrollAnimator.SetBool ("Listo", true);
				}
			}
			
		}
	}

	void CambiarNombre (int pos) {
		nameInput.SetActive (true);
		nameInput.GetComponent<BotonGo> ().posicionEnTabla = pos;
	}
}
