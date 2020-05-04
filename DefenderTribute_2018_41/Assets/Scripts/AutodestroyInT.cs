using UnityEngine;
using System.Collections;

public class AutodestroyInT : MonoBehaviour {


	public float tiempovida = 12f;
	// Use this for initialization
	void Start () {
		Invoke ("Autodestruirse", tiempovida);
	}
	void OnEnable () {
		Invoke ("Autodestruirse", tiempovida);
	}

	void Autodestruirse () {
		SimplePool.Despawn(gameObject);
	}
}
