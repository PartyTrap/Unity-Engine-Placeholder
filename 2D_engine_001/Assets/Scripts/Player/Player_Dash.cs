using UnityEngine;
using System.Collections;

public class Player_Dash : MonoBehaviour {

	private Rigidbody2D rb;
	public Player_Move player;

	public float distance;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			rb.AddForce (player.lastMove * distance);
		}
	}
}
