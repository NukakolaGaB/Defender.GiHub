using UnityEngine;
using System.Collections;

public class SonidoGirador : MonoBehaviour {

	[SerializeField] AudioSource click;

	float anguloAnterior;
	[SerializeField] float anguloclick;

	// Use this for initialization
	void Start () {

		anguloAnterior = transform.rotation.z;
	
	}
	
	// Update is called once per frame
	void Update () {

		if ((transform.rotation.z - anguloAnterior) > anguloclick*Time.deltaTime || (transform.rotation.z - anguloAnterior) < -anguloclick*Time.deltaTime) {
			click.enabled = true;
		} else {
			click.enabled = false;
		}
		anguloAnterior = transform.rotation.z;
	
	}
}
