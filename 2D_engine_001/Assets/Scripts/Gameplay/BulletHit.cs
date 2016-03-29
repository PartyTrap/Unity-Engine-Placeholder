using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{ 	
	public Player_State PS;
	public Enemy_State ES;
	public GameObject player;
	public int dmg;
	private Animator anim;

	void Start ()
	{
        player = GameObject.FindGameObjectWithTag("Player");
		
		PS = player.GetComponent <Player_State> ();

	}

	//on collision destroy the bullet Clone
	void OnCollisionEnter2D(Collision2D OnHit)
	{
        if (OnHit.gameObject.tag == "Pickup")
        {
            Physics2D.IgnoreCollision(OnHit.collider, this.gameObject.GetComponent<Collider2D>());
        }
		if (OnHit.gameObject.tag == "Enemy" || OnHit.gameObject.tag == "Boss" || OnHit.gameObject.tag == "MommaSpider")
            ES = OnHit.gameObject.GetComponent<Enemy_State> ();

        if (OnHit.gameObject.tag == "Player")
        {
            PS.playerHealth -= (dmg - PS.resistance);
            Destroy(this.gameObject);
        }
		else if (OnHit.gameObject.tag == "Enemy" || OnHit.gameObject.tag == "Boss" || OnHit.gameObject.tag == "MommaSpider")
        {
            ES.enemyHealth -= (dmg - ES.resistance);
            anim = OnHit.gameObject.GetComponent<Animator>();
            if (anim)
                anim.SetTrigger("Hit");
            Destroy(this.gameObject);
        }else {
			Destroy (this.gameObject);
		}
        ES = null;
	}
	void OnTriggerEnter2D(Collider2D obj){
<<<<<<< HEAD
		if(obj.tag != "Belt" && obj.tag != "Pickup" && obj.tag != "Webs" && obj.tag != "Spikes" && obj.tag != "StopTile" )
=======
        if(obj.tag != "Belt" && obj.tag != "Pickup" && obj.tag != "Webs" && obj.tag != "Spikes" && obj.tag != "Environment")
>>>>>>> refs/remotes/origin/master
			Destroy(gameObject);
	}
}

