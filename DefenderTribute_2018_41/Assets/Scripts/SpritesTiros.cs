using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpritesTiros : MonoBehaviour {


	[SerializeField] Image tiro1;
	[SerializeField] Image tiro2;
	[SerializeField] Image tiro3;


	public void Refresh (int disparos) {
		if (disparos <= 0) {
			tiro1.color = Color.gray;
			tiro2.color = Color.gray;
			tiro3.color = Color.gray;
		} else if (disparos == 1) {
			tiro1.color = Color.yellow;
			tiro2.color = Color.gray;
			tiro3.color = Color.gray;
		} else if (disparos == 2) {
			tiro1.color = Color.yellow;
			tiro2.color = Color.yellow;
			tiro3.color = Color.gray;
		} else if (disparos >= 3) {
			tiro1.color = Color.yellow;
			tiro2.color = Color.yellow;
			tiro3.color = Color.yellow;
		}
	}
	// Use this for initialization
//	void Awake () {
//		tiro1 = GameObject.Find ("Tiro1").GetComponent<Image> ();
//		tiro2 = GameObject.Find ("Tiro2").GetComponent<Image> ();
//		tiro3 = GameObject.Find ("Tiro3").GetComponent<Image> ();
//	}
}
