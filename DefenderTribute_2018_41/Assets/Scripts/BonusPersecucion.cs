using UnityEngine;
using System.Collections;

public class BonusPersecucion : MonoBehaviour {

	public bool rigid;
	Rigidbody2D myR;
	float posYcentral;
	float posX;
	float posY;
	float posZ;
	[SerializeField] float speed = 1f;
	float sentido = 1;
	[SerializeField] float angSpeed = 1f;
	[SerializeField] float amplitud = 3f;

	[SerializeField] SpriteRenderer proteusRenderer;
	[SerializeField] Sprite help;
	[SerializeField] Sprite bonus;

	[Tooltip("Aqui se pone el prefab del perseguidor")]
//	[SerializeField] GameObject prefabPerseguidor;
	public GameObject perseguidor;
	[Tooltip("Aqui se pone a que distancia lo sigue perseguidor")]
	public float distancia = 5f;
	PerseguidorBonus perseguidorBonus;
	public DanoDeMisiles danoDeMisiles;

	[SerializeField] Transform myTransform;

	// Use this for initialization

	void Start () {
		myR = GetComponent<Rigidbody2D> ();
		}

	void OnEnable () {
		
		if (Puntuaciones.dchaIzda) {
			sentido = -1;
		}
		
		posX = myTransform.position.x;
		posY = myTransform.position.y;
		posYcentral = posY;
		posZ = myTransform.position.z;
	
		}
	public void CambiarSpriteProteus(int recompensa){
	
		if (recompensa == 0) {

			proteusRenderer.sprite = help;

		} else {

			proteusRenderer.sprite = bonus;

		}

	}
	void AsignarDanoDeMisiles () {

		perseguidor.layer = gameObject.layer;
		perseguidorBonus.danoDeMisiles = danoDeMisiles;
	}
	
	// Update is called once per frame
	void Update () {

		if (rigid) {
			myR.velocity = new Vector2 (speed* sentido, speed * Mathf.Sin (angSpeed * Time.time));
		} else {
			posX += speed * Time.deltaTime * sentido;
			posY = posYcentral + amplitud * Mathf.Sin (angSpeed * Time.time);

			myTransform.position = new Vector3 (posX, posY, posZ);
		}
	}

	public void RestarVida () {
		danoDeMisiles.RestarVida ();
	}

	public void DestruirPerseguidor() {
		if(perseguidor!= null){
		SimplePool.Despawn (perseguidor);
		}
	}
	void OnTriggerEnter2D (Collider2D choca) {
		if (choca.gameObject.name == "DanoDeMisiles2D") {

			SimplePool.Despawn (gameObject);
			if (perseguidor != null) {
				DestruirPerseguidor();
			}
		}
	}
}
