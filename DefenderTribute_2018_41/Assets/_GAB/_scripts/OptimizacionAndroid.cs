using UnityEngine;
using System.Collections;

public class OptimizacionAndroid : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if(Application.isMobilePlatform){
		
			Application.targetFrameRate = 60;
		
		}
	}

}
