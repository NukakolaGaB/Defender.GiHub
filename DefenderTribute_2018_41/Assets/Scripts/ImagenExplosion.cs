using UnityEngine;
using System.Collections;

public class ImagenExplosion : MonoBehaviour {


	[SerializeField] GameObject exploUnit;
	int num;

	// Use this for initialization
	void Start () {
		num = Random.Range (3, 6);
		for (int i = 0; i < num; i++) {
			Instantiate (exploUnit, new Vector3 (transform.position.x, transform.position.y + Random.Range (-0.35f, 0.35f),  transform.position.z + Random.Range (0f, 0.15f)), transform.rotation);
		}
	}
}
