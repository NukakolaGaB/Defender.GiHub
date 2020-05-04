using UnityEngine;
using System.Collections;

public class AsignadorSpriteMisil : MonoBehaviour {


	public Sprite[] spriteCapa;
	public SpriteRenderer sprite;

	void OnEnable () {
		sprite.sprite = spriteCapa [Puntuaciones.capa -3];
	}
}
