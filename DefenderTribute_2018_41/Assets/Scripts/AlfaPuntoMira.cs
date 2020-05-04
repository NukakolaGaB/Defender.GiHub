using UnityEngine;
using System.Collections;

public class AlfaPuntoMira : MonoBehaviour {


	[SerializeField] SpriteRenderer mySprite;
	[SerializeField] SpriteRenderer mySprite2;

	float contador;
	float sumaResta = 1;
	float  ajuste ;

	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () {

		if (contador >= 1) {
			sumaResta = -1.2f;
		} else if (contador <= 0.6f) {
			sumaResta = 1.2f;
		}
		contador += Time.deltaTime * sumaResta;
		mySprite.color = new Color (0	, 1,0, 1);
		mySprite2.color = new Color (0	, 1,0, 1);
		ajuste = contador * 0.08f + 0.08f;
		mySprite.transform.localScale = new Vector3 (ajuste, ajuste, ajuste);
		mySprite2.transform.localScale = new Vector3 (ajuste, ajuste, ajuste);

	}
}
