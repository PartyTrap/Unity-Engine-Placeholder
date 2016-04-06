using UnityEngine;
using System.Collections;

public class LightVestige : Enemy_State {
	public float VestigeHealth = 2000;
	[SerializeField] private float VestigeResistance = 5;
	[SerializeField] public bool isAlive = true;
	[SerializeField] private DarkVestige dark;
	[SerializeField] private GameObject core;
	[SerializeField] private Animator anim;
	// Update is called once per frame
	void Start(){
		enemyHealth = Mathf.FloorToInt(VestigeHealth);
	}
	void Update () {
		enemyHealth = Mathf.FloorToInt(VestigeHealth);
		//Check if Dark Vestige is Dead
		if (VestigeHealth <= 0) {
			isAlive = false;
			this.gameObject.GetComponent<LightVestigeAttacks> ().enabled = false;
		} else {
			isAlive = true;
			this.gameObject.GetComponent<LightVestigeAttacks> ().enabled = true;
		}
		if (!isAlive) {
			if (!dark.isAlive) {
				core.SetActive (true);
				anim.SetBool ("open", true);
			}
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
			TakeDamage ((float)c.gameObject.GetComponent<BulletHit> ().dmg);
		}
	}
}
