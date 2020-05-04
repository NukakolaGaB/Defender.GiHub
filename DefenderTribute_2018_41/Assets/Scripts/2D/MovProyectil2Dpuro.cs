using UnityEngine;
using System.Collections;

public class MovProyectil2Dpuro : MonoBehaviour {


	[Tooltip("Esta es la escala que tendran para z=0")]
	public Vector3 tamanno = new Vector3 (1f, 1f, 1f);
	[Tooltip("Distancia a la que la escala se hace 0 (luego vuelve a crecer)")]
	public float distanciaMax = 100f;
	[Tooltip("velocidad de los disparos (se mueven en z)")]
	public float speed;

	public bool usandoInfinito;

	//[SerializeField] AudioClip explosionPr;
	[SerializeField] GameObject exploUnit;
	[SerializeField] GameObject exploUnitProteus;
	[SerializeField] GameObject exploUnitVirus;
	[SerializeField] GameObject exploUnitPoder;
	[SerializeField] GameObject exploUnitJefe;
	[SerializeField]Disparador2D disparador2D;
	[SerializeField]TestRotJefe testRotJefe;

	bool alcanzado = false;

	Transform myTransform;

	// Use this for initialization
	void Awake () {
		gameObject.layer = Tags.entreCapas;
		myTransform = transform;
		SimplePool.Preload(exploUnit, 3);
		SimplePool.Preload(exploUnitProteus, 1);
		SimplePool.Preload(exploUnitVirus, 1);
		SimplePool.Preload(exploUnitPoder, 1);
		usandoInfinito = Puntuaciones.usandoPoderInfinito;
	}
	void OnEnable () {
		gameObject.layer = Tags.entreCapas;
		usandoInfinito = Puntuaciones.usandoPoderInfinito;

	}

	void Start () {
		disparador2D = GameObject.Find ("Disparador2D").GetComponent<Disparador2D> ();
	}

	// Update is called once per frame
	void Update () {

		CambiarLayer (myTransform.position.z);
		if (transform.position.z < distanciaMax) {
			myTransform.localScale = tamanno * (distanciaMax - myTransform.position.z) / distanciaMax;
			myTransform.position += Vector3.forward * speed * Time.deltaTime;
		} else {
			Destruir();
		}
	
	}

	void OnTriggerEnter2D (Collider2D col) {

		if (!alcanzado) {
			alcanzado = true;
			//Debug.Log(col.name);
			if(col.gameObject.tag == "jefe"){
				testRotJefe=col.GetComponent<TestRotJefe>();
				testRotJefe.RecibirDisparo();
				GameObject explo = SimplePool.Spawn(exploUnitJefe,transform.position, transform.rotation) as GameObject;
				if (Puntuaciones.dchaIzda) {
					explo.GetComponent<Rigidbody2D> ().velocity = Vector2.right*8.5f;
				} else {
					explo.GetComponent<Rigidbody2D> ().velocity = -Vector2.right*8.5f;
				}


			}
				else if (col.gameObject.tag == "misil") {
					DestruccionMisil2D misil = col.GetComponent<DestruccionMisil2D>();
					if(misil.escudo.activeSelf){
						//Debug.Log("Escudo activo");
						misil.exploEscudo.Play();
						misil.escudo.SetActive(false);
						disparador2D.Restar1disparo();
						
						
					} else {
						misil.ChocarContraProyectil ();
						if (misil.misilDeJEfe) {
							disparador2D.SumarPuntoJefe (misil.puntuacion);
						} else {
							disparador2D.Sumarpunto (misil.puntuacion, transform.position);
						}
					}
				}
				else if((col.tag == Puntuaciones.muro)){
					
					
					GameObject explo = SimplePool.Spawn(exploUnit,transform.position, transform.rotation) as GameObject;
					//para que la explosion vaya hacia atras:
					if (Puntuaciones.dchaIzda) {
						explo.GetComponent<Rigidbody2D> ().velocity = Vector2.right*8.5f;
					} else {
						explo.GetComponent<Rigidbody2D> ().velocity = -Vector2.right*8.5f;
					}
					
				}
				else if (col.tag == Puntuaciones.perseguido) {
					//si le da a la proteus penaliza
					BonusPersecucion bonusPersecucion = col.GetComponent<BonusPersecucion>();
					bonusPersecucion.RestarVida();
					bonusPersecucion.DestruirPerseguidor();
					SimplePool.Despawn (col.gameObject);
					CrearExplosionParaProteus();
				} 
				else if (col.tag == Puntuaciones.perseguidoR) {
					//si le da al virus que persigue a la proteus recompensa
					PerseguidorBonus perseguidorBonus = col.GetComponent<PerseguidorBonus>();
					perseguidorBonus.MatarVirus();
					if(perseguidorBonus.recompensa==0){

						CrearExplosionParaVirus();
					}
					else{
						CrearExplosionParaPoder();
					}
				}

		}
		

			Destruir ();

	}
	
	void Destruir(){
		//Destroy (gameObject);
		if (!usandoInfinito) {
			disparador2D.Annadir1disparo ();
		}
		alcanzado = false;
		SimplePool.Despawn(gameObject);

	}

	void CrearExplosionParaVirus () {
		
		GameObject explo = SimplePool.Spawn (exploUnitVirus, transform.position, transform.rotation) as GameObject;
		explo.transform.localScale=gameObject.transform.localScale;
		//para que la explosion vaya hacia atras:
		if (Puntuaciones.dchaIzda) {
			explo.GetComponent<Rigidbody2D> ().velocity = Vector2.right*8.5f;
		} else {
			explo.GetComponent<Rigidbody2D> ().velocity = -Vector2.right*8.5f;
		}
	}
	void CrearExplosionParaPoder () {

		GameObject explo = SimplePool.Spawn (exploUnitPoder, transform.position, transform.rotation) as GameObject;
		explo.transform.localScale=gameObject.transform.localScale;
		//para que la explosion vaya hacia atras:
		if (Puntuaciones.dchaIzda) {
			explo.GetComponent<Rigidbody2D> ().velocity = Vector2.right*8.5f;
		} else {
			explo.GetComponent<Rigidbody2D> ().velocity = -Vector2.right*8.5f;
		}
	}

	void CrearExplosionParaProteus () {
		GameObject explo = SimplePool.Spawn (exploUnitProteus, transform.position, transform.rotation) as GameObject;
		explo.transform.localScale=gameObject.transform.localScale;
		//para que la explosion vaya hacia atras:
		if (Puntuaciones.dchaIzda) {
			explo.GetComponent<Rigidbody2D> ().velocity = Vector2.right*8.5f;
		} else {
			explo.GetComponent<Rigidbody2D> ().velocity = -Vector2.right*8.5f;
		}
	}
	void CambiarLayer (float z) {
		if (z > 25f && z < 30f) {
			gameObject.layer = Tags.capaP3;
		} else if (z > 35 && z < 40) {
			gameObject.layer = Tags.capaP4;
		} else if (z > 45 && z < 50) {
			gameObject.layer = Tags.capaP5;
		} else if (z > 55 && z < 60) {
			gameObject.layer = Tags.capaP6;
		} else if (z > 65 && z < 70) {
			gameObject.layer = Tags.capaP7;
		} else if (z > 75 && z < 80) {
			gameObject.layer = Tags.capaP8;
		} else if (z > 85 && z < 90) {
			gameObject.layer = Tags.capaP9;
		} else {
			gameObject.layer = Tags.entreCapas;
		}
	}
}
