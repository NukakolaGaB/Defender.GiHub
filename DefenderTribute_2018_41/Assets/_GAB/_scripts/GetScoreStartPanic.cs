using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GetScoreStartPanic : MonoBehaviour {

	public Text nombrePlayer;
	public Text scorePlayer;
	public Text nivelPlayer;
	public int n;

	// Use this for initialization
	void Start () {
	
		nombrePlayer.text = Puntuaciones.nombresRecordPanic [n];
		scorePlayer.text = Puntuaciones.puntuacionesRecordPanic [n].ToString();
		nivelPlayer.text = Puntuaciones.nivelRecordPanic [n].ToString();
	}
	

}
