using UnityEngine;
using System.Collections;

public class CloneDestroy : MonoBehaviour {


	public float tiempoVida;


	void OnEnable () {

		Invoke ("Autodestruccion",tiempoVida);
	}
	
	// Update is called once per frame
	void Autodestruccion () {
			
		SimplePool.Despawn(gameObject);
	}
}
