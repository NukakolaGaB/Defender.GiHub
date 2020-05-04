using UnityEngine;
using System.Collections;

public class PerseguidorBonus : MonoBehaviour {

	public bool rigid;
	Rigidbody2D myR;
	public Transform perseguido;
	Transform myTransform;
	public float distancia;
	[SerializeField] float speed;
	public DanoDeMisiles danoDeMisiles;
	Vector2 direccion;
	public BonusPersecucion bonusPersecucion;




	[SerializeField] SpriteRenderer sRenderer;
	[SerializeField] Sprite virusS;
	[SerializeField] Sprite limpiarS;
	[SerializeField] Sprite muroS;
	[SerializeField] Sprite infinitoS;

	public int recompensa;

	// Use this for initialization

//		danoDeMisiles=GameObject.Find ("DanoDeMisiles2D").GetComponent<DanoDeMisiles> ();

	void Start () {
//		danoDeMisiles=GameObject.Find ("DanoDeMisiles2D").GetComponent<DanoDeMisiles> ();
		myTransform = transform;
		myR = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rigid) {
			direccion.x = perseguido.position.x - myTransform.position.x - distancia;
			direccion.y = perseguido.position.y - myTransform.position.y - distancia;
			myR.velocity = new Vector2 (direccion.x, direccion.y);
		} else {
//		distancia += Random.Range (-1f, 1f) * Time.deltaTime;
			speed = (perseguido.position - myTransform.position).sqrMagnitude - distancia;
			myTransform.position = Vector3.MoveTowards (myTransform.position, perseguido.position, speed * Time.deltaTime);

//		transform.position = perseguido.position - new Vector3 (distancia, 0, 0);
		}
	}
	public void TipoRecompensa(int rec){

		recompensa = rec;
		switch(rec){

		case 0:
				sRenderer.sprite = virusS;
				break;
			case 1:
				sRenderer.sprite = limpiarS;
				break;
			case 2:
				sRenderer.sprite = infinitoS;
				break;
			case 3:
				sRenderer.sprite = muroS;
				break;

		}
}

	public void MatarVirus () {


		switch (recompensa) {
		case 0:
			danoDeMisiles.SumarVida ();
			break;
		case 1:
			Accessos.poderes.ActivarBotonLimpia ();

			break;
		case 2:
			Accessos.poderes.ActivarBotonInfin ();
			break;
		case 3:
			Accessos.poderes.ActivarBotonMuro ();
			break;
		}
		bonusPersecucion.perseguidor=null;
		SimplePool.Despawn (gameObject);
	}

	void OnTriggerEnter2D (Collider2D choca) {

		if (choca.gameObject.name == "DanoDeMisiles2D") {
			
			SimplePool.Despawn (gameObject);
		}
	}
}
