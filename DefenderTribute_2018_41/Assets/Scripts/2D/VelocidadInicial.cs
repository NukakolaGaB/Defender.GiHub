using UnityEngine;
using System.Collections;

public class VelocidadInicial : MonoBehaviour {

	[SerializeField] Rigidbody2D myrigid;
	[SerializeField] float sentido;
	[SerializeField] Transform mytransform;
	float z;
	Vector2 vel;
	[SerializeField] GameObject tobera;

	[SerializeField] GameObject puntoMira;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnEnable () {

		z = mytransform.position.z;
		if (z > 0) {
			z= 1/z;
		} else {
			z = 0.333f;
		}
		vel = sentido * Puntuaciones.speed * z * Vector2.right * 50;
		myrigid.velocity = vel;

		if (Puntuaciones.puntoMira) {
			float x = mytransform.position.z;
			x = x * vel.x / 85;
			puntoMira.SetActive (true);
			// aqui no ponemos sentido, porque ya lo tiene en vel.
			puntoMira.transform.position = mytransform.position + mytransform.right * x;
//			puntoMira.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1 - 0.15f * Puntuaciones.nivel);
		} else {
			puntoMira.SetActive (false);
		}
	}


	void Arrancar () {
		myrigid.gravityScale = 0;
		tobera.SetActive (true);
		myrigid.velocity = vel;
	}
	public void Parado () {
		vel = myrigid.velocity;
		myrigid.velocity = -0.1f * vel;
		myrigid.gravityScale = 0.5f;
		tobera.SetActive (false);
		Invoke ("Arrancar", 0.5f);
	}
}
