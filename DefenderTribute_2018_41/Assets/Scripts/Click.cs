using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

	[SerializeField] Disparador2D disparador2D;
	Vector3 mousePos;


	public void Click2D () {

		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		disparador2D.Disparar (mousePos.x, mousePos.y);
	}

}
