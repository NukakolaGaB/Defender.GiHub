using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CambioColorMisil : MonoBehaviour {

	public Image misil;
	public int escena;

	// Use this for initialization
	void Start () {
		if(Application.loadedLevelName == "2"){
			misil.color=new Color(1,0,0,1);
		}
	}
}
