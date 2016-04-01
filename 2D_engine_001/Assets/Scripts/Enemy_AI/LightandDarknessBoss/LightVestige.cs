﻿using UnityEngine;
using System.Collections;

public class LightVestige : Enemy_State {
	[SerializeField] private float VestigeHealth = 2000;
	[SerializeField] private float VestigeResistance = 5;
	[SerializeField] private bool isAlive = true;
	// Update is called once per frame
	void Update () {
		enemyHealth = Mathf.FloorToInt(VestigeHealth);
		//Check if Dark Vestige is Dead
		if (VestigeHealth <= 0) {
			isAlive = false;
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
}
