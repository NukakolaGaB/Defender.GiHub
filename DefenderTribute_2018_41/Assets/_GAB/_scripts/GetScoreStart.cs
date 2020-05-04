using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GetScoreStart : MonoBehaviour {

	public Text nombrePlayer;
	public Text scorePlayer;
	public Text nivelPlayer;
	public int n;

	// Use this for initialization
	void Start () {
	
		nombrePlayer.text = Puntuaciones.nombresRecordP [n];
		scorePlayer.text = Puntuaciones.puntuacionesRecordP [n].ToString();
		nivelPlayer.text = Puntuaciones.nivelRecordP [n].ToString();
	}
	

}
