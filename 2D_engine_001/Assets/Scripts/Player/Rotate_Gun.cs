using UnityEngine;
using System.Collections;

public class Rotate_Gun : MonoBehaviour {

	private Vector2 lastMove;
	[SerializeField]private Player_Move PM;

	// Update is called once per frame
	void Update () {
		if (PM.lastMove.x > 0) {//right
			Debug.Log ("Stuff");
			this.transform.eulerAngles = new Vector3 (0, 0, 90);
		}
		if (PM.lastMove.x < 0) {//left
			this.transform.eulerAngles = new Vector3 (0, 0, 270);
		}
		if (PM.lastMove.y > 0) {//up
			this.transform.eulerAngles = new Vector3 (0, 0, 180);
		}
		if (PM.lastMove.y < 0) {//down
			this.transform.eulerAngles = new Vector3 (0, 0, 0);
		}

	}
}