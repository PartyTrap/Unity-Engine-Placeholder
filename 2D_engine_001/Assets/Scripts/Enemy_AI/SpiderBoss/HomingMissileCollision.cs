using UnityEngine;
using System.Collections;

public class HomingMissileCollision : MonoBehaviour {
	public GameObject missile;
	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<Player_State> ().playerHealth = c.gameObject.GetComponent<Player_State> ().playerHealth - 15;
		}
		Destroy (missile);
	}
}
