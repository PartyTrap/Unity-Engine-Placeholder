using UnityEngine;
using System.Collections;

public class Smashattack : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D c){
		if(c.gameObject.tag == "Player"){
			c.gameObject.GetComponent<Player_State> ().playerHealth -= 50;
			//Process Knockback

			c.gameObject.GetComponent<Rigidbody2D> ().AddForce (this.transform.position - c.gameObject.transform.position * 300);

		}
	}

}
