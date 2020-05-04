using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GestorCanvasInfo : MonoBehaviour {

	public GameObject[] canvas;

	// Use this for initialization
	void Start () {

		Puntuaciones.cuantosCanvasInfo = canvas.Length;

		if(Puntuaciones.indiceCanvasInfo < Puntuaciones.cuantosCanvasInfo - 1){

			Puntuaciones.indiceCanvasInfo++;

		}
		else{
			Puntuaciones.indiceCanvasInfo=0;

		}
		canvas[Puntuaciones.indiceCanvasInfo].SetActive(true);
	}
}
