using UnityEngine;
using System.Collections;

public class ThornHit : MonoBehaviour {

	private Animator anim;

	void Start(){
		anim = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<Player_State> ().playerHealth -= 10;
			anim.SetTrigger ("Hit");
		}
		Destroy (this.gameObject);
	}
}
