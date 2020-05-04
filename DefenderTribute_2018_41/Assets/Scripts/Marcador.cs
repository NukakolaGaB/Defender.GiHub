using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Marcador : MonoBehaviour {

	public bool seleccionable;
	[Tooltip("uno marcado (asi sera por defecto) y el resto sin marcar")]
	public bool seleccionado;
	[Tooltip("Esto en true (marcado) para continuar y en false (sin marcar) para el resto")]
	public bool continuar;
	[Tooltip("en que nivel empieza el juego")]
	public int nivel;
	[Tooltip("Nivel dificultad del panic: 0 easy, 1 normal, 3 hard, 4 crazy")]
	public int panic;
	public Image imagen;
	public Text texto;
	
}
