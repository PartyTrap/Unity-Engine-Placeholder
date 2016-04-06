using UnityEngine;
using System.Collections;

public class BossState : Enemy_State {
	public int bossHealth = 5000;
	public int damageTaken;
	public GameObject explosion;
	public GameObject aud;
	// Use this for initialization
	void Start () {
		setResist (10);
        max = bossHealth;
		aud = GameObject.Find ("BossAudioManager");
	}
	
	// Update is called once per frame
	void Update () {
		if (bossHealth < 2500) {
			setResist (5);
		}
		if (bossHealth < 1250) {
			setResist (0);
		}
		enemyHealth = bossHealth;
		if (bossHealth <= 0) {
			
			Instantiate (explosion, this.gameObject.transform.position, this.gameObject.transform.localRotation);
			aud.GetComponent<BossAudioManager> ().PlayEnemyDeathClip ();

			Destroy (this.gameObject.transform.parent.gameObject);
		}
			
	}
	void OnCollisionEnter2D(Collision2D c ){
		if (c.gameObject.tag == "Bullet") {
			Debug.Log ("Hit");
			damageTaken = c.gameObject.GetComponent<BulletHit> ().dmg;
			bossHealth = bossHealth - (damageTaken - getResist());
			Destroy (c.gameObject);
		}
	}
}
