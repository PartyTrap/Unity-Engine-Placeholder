using UnityEngine;
using System.Collections;

public class BossState : Enemy_State {
	public int bossHealth = 5000;
	public int resistance;
	public int damageTaken;
	// Use this for initialization
	void Start () {
		resistance = 25;
        max = bossHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (bossHealth < 2500) {
			resistance = 20;
		}
		if (bossHealth < 1250) {
			resistance = 0;
		}
        enemyHealth = bossHealth;
       
	}
	void OnCollisionEnter2D(Collision2D c ){
		if (c.gameObject.tag == "Bullet") {
			Debug.Log ("Hit");
			damageTaken = c.gameObject.GetComponent<BulletHit> ().dmg;
			bossHealth = bossHealth - (damageTaken - resistance);
			Destroy (c.gameObject);
			if (bossHealth <= 0) {
				//Play death animation
				Destroy (this.gameObject.transform.parent.gameObject);
			}
		}
	}
}
