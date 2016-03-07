using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{ 	
	public Player_State state;
	public GameObject player;
	public int dmg;
	void Start ()
	{
		player = GameObject.Find ("Player");
		state = player.GetComponent <Player_State> ();
	}
	//on collision destroy the bullet Clone
	void OnCollisionEnter2D(Collision2D OnHit)
	{
		if (OnHit.gameObject.name == state.name) {
			state.playerHealth -= dmg;
			Destroy (this.gameObject);
		}else 
			Destroy(this.gameObject);
	}
	void OnTriggerEnter2D(Collider2D obj){
		
			Destroy(gameObject);
	}

}

