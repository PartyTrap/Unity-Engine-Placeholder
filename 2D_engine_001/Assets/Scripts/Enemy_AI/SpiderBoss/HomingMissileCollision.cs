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

        if (c.gameObject.tag == "Player")
        {
            PS.playerHealth -= (dmg - PS.resistance);
            Destroy(this.gameObject);
        }
       
	}
}
