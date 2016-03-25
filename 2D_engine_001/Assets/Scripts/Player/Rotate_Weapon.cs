using UnityEngine;
using System.Collections;

public class Rotate_Weapon : MonoBehaviour {

	private Vector2 lastMove;
	[SerializeField]private Player_Move PM;

	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
			
			lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0.0f);
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
			
			lastMove = new Vector2 (0.0f, Input.GetAxisRaw ("Vertical"));
		}*/

		if (PM.lastMove.x > 0) {//right
			Debug.Log ("Stuff");
			this.transform.eulerAngles = new Vector3 (0, 0, 270);
		}
		if (PM.lastMove.x < 0) {//left
			this.transform.eulerAngles = new Vector3 (0, 0, 90);
		}
		if (PM.lastMove.y > 0) {//up
			this.transform.eulerAngles = new Vector3 (0, 0, 0);
		}
		if (PM.lastMove.y < 0) {//down
			this.transform.eulerAngles = new Vector3 (0, 0, 180);
		}
	}
}
