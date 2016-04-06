using UnityEngine;
using System.Collections;

public class EnemyBulletHit : MonoBehaviour {

	public Player_State PS;
	public GameObject player;
	public int dmg;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");

		PS = player.GetComponent <Player_State> ();
	}
		
	void OnCollisionEnter2D(Collision2D OnHit)
	{

		if (OnHit.gameObject.tag == "Pickup")
		{
			Physics2D.IgnoreCollision(OnHit.collider, this.gameObject.GetComponent<Collider2D>());
		}

		if (OnHit.gameObject.tag == "Enemy" || OnHit.gameObject.tag == "Boss" || OnHit.gameObject.tag == "MommaSpider")
		{
			Physics2D.IgnoreCollision (OnHit.collider, this.gameObject.GetComponent<Collider2D>());
		}

		if (OnHit.gameObject.tag == "Player")
		{
			PS.playerHealth -= (dmg - PS.resistance);
			Destroy(this.gameObject);
		}

		else 
		{
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D obj){
		if(obj.tag != "Belt" && obj.tag != "Pickup" && obj.tag != "Webs" && obj.tag != "Spikes" && obj.tag != "StopTile" && obj.tag != "Fire")
		{
			Destroy(gameObject);
		}
	}
}
