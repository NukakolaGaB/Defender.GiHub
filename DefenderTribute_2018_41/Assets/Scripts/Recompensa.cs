using UnityEngine;
using System.Collections;

public class Recompensa : MonoBehaviour {

	public DanoDeMisiles danoDeMisiles;

	public void SumarVida () {
		danoDeMisiles.SumarVida ();
	}
	public void RestarVida () {
		danoDeMisiles.RestarVida ();
	}
}
