using UnityEngine;
using System.Collections;

public class HomingMissileCollision : MonoBehaviour {
    public Player_State PS;
    public float dmg;

    void Start ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        PS = player.GetComponent <Player_State> ();
        Physics2D.IgnoreLayerCollision(11, 10);
        Physics2D.IgnoreLayerCollision(9, 11);

    }

	void OnCollisionEnter2D(Collision2D c){
<<<<<<< HEAD
		if (c.gameObject.tag == "Player") {
			c.gameObject.GetComponent<Player_State> ().playerHealth = c.gameObject.GetComponent<Player_State> ().playerHealth - 15;
		}
		Destroy (missile);
=======

        if (c.gameObject.tag == "Player")
        {
            PS.playerHealth -= (dmg - PS.resistance);
            Destroy(this.gameObject);
        }
       
>>>>>>> refs/remotes/origin/master
	}
}
