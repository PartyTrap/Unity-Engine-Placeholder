using UnityEngine;
using System.Collections;

public class BossCore : Enemy_State{
	public float VestigeHealth = 8000;
	[SerializeField] private float VestigeResistance = 5;
	[SerializeField] private bool isAlive = true;
	[SerializeField] private Animator anim;
	// Update is called once per frame
	void Update () {
		enemyHealth = Mathf.FloorToInt(VestigeHealth);
		if (VestigeHealth <= 0) {
			isAlive = false;
			anim.SetBool ("dying", true);
		} else {
			isAlive = true;
		}
		if (isAlive) {
			//Conduct Attacks

		}
	}
	public void TakeDamage(float damage){
		float netDamage = damage - VestigeResistance;
		if (netDamage < 0) {
			netDamage = 0;
		}
		VestigeHealth -= netDamage;
	}
	public void HealDamage(float heal){
		VestigeHealth += heal;
		if (VestigeHealth > 2000) {
			VestigeHealth = 2000;
		}
		enemyHealth = Mathf.FloorToInt(VestigeHealth);
	}
	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "Bullet") {
			TakeDamage (c.gameObject.GetComponent<BulletHit> ().dmg);
		}
	}
}
