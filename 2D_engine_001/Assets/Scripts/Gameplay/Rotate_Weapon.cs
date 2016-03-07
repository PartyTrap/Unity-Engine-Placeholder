using UnityEngine;
using System.Collections;

public class Rotate_Weapon : MonoBehaviour {

	Vector2 lastMove;

	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {

			lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0.0f);
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {

			lastMove = new Vector2 (0.0f, Input.GetAxisRaw ("Vertical"));
		}
		if (lastMove.x > 0)//right
			transform.eulerAngles = new Vector3 (0, 0, 90);
		if (lastMove.x < 0)//left
			transform.eulerAngles = new Vector3 (0, 0, 270);
		if (lastMove.y > 0)//up
			transform.eulerAngles = new Vector3 (0, 0, 180);
		if (lastMove.y < 0)//down
			transform.eulerAngles = new Vector3 (0, 0, 0);
	}
}
