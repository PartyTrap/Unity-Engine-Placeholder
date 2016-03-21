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
		player = GameObject.Find ("Player");
		if (!player)
			player = GameObject.Find ("Player_Ranged");
		PS = player.GetComponent <Player_State> ();

	}
	//on collision destroy the bullet Clone
	void OnCollisionEnter2D(Collision2D OnHit)
	{
		ES = OnHit.gameObject.GetComponent<Enemy_State> ();

        if (OnHit.gameObject.name == PS.name)
        {
            PS.playerHealth -= (dmg - PS.resistance);
            Destroy(this.gameObject);
        }
        else if (ES)
        {
            ES.enemyHealth -= (dmg - ES.resistance);
            anim = OnHit.gameObject.GetComponent<Animator>();
            if (anim)
                anim.SetTrigger("Hit");
            Destroy(this.gameObject);
        }else {
			Destroy (this.gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D obj){
        if(obj.tag != "Belt")
			Destroy(gameObject);
	}

}

