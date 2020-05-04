using UnityEngine;
using System.Collections;

public class ExploUnitScale : MonoBehaviour {

	float escala;
	public LanzaMisiles2D lanzaMisiles2D;

	//[SerializeField] ParticleSystem TrailWhite;
	[SerializeField] ParticleSystem Sparks;
	[SerializeField] ParticleSystem Fireball;
	//[SerializeField] ParticleSystem Trozos;
	[SerializeField] ParticleSystem HumoNegro;


	public float Escala {
		get {
			return escala;
		}
		set {
			escala = value;
			//TrailWhite.startSize = value * Random.Range (0.5f, 1f)*2f;
			//TrailWhite.startSpeed = value * Random.Range (1f, 3f)*2f;
			Sparks.startSize  = value * Random.Range (0.01f, 0.1f)*2f;
			Sparks.startSpeed  = value * Random.Range (2f, 6f)*2f;
//			Sparks.ShapeModule.radius = value * 0.01f;
//			Sparks.shape.radius = value * 0.01f;
			Fireball.startSize  = value * Random.Range (6f, 10f)*2f;
			Fireball.startSpeed  = value * Random.Range (2f, 4f)*2f;
			//Trozos.startSize  = value * Random.Range (0.01f, 0.5f)*2f;
			//Trozos.startSpeed  = value * Random.Range (5f, 15f)*2f;
			HumoNegro.startSize  = value * Random.Range (1f, 1.5f)*2f;
			HumoNegro.startSpeed  = value * Random.Range (2f, 3f)*2f;
		}
	}

	public void Sentido(Vector2 misilRB){

		//lanzaMisiles2D = GameObject.Find ("LanzaMisiles2D").GetComponent<LanzaMisiles2D> ().sentido;
		GetComponent<Rigidbody2D> ().velocity = misilRB*-1.5f;
		Invoke("Destruir",1f);


	}
	public void Destruir(){
	
		SimplePool.Despawn(gameObject);
		
	}


}
