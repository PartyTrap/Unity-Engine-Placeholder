using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightVestigeAttacks : MonoBehaviour {
	[SerializeField] private Heal heal;
	[SerializeField] private ArenaDistort arena;
	[SerializeField] private Disrupt disruption;
	[SerializeField] private BossMove move;
	[SerializeField] private int acooldown = 300;
	[SerializeField] private int dcooldown = 600;
	[SerializeField] private DarkVestige dv;
	public List<int> bossattacks = new List<int>(); 
	// Update is called once per frame
	void Update () {
		if (acooldown > 0) {
			acooldown--;
		}
		if(dcooldown > 0){
			dcooldown--;
		}
		if (acooldown == 0) {
			bossattacks.Add (0);
		}
		if (dcooldown == 0) {
			bossattacks.Add (1);
		}
		if (dv.enemyHealth < 200) {
			bossattacks.Add (2);
		}
		if (bossattacks.Count > 0) {
			int decision = Random.Range (0, bossattacks.Count);
			switch (((int)bossattacks [decision])) {
			case 0://Arena Distort
				arena.enabled = true;
				arena.enabled = false;
				acooldown = 720;
				break;
			case 1://Disrupt Controls
				disruption.enabled = true;
				dcooldown = 240;
				break;
			case 2://Heal 
				heal.enabled = true;
				heal.enabled = false;
				break;
			}
			bossattacks.Clear ();
		} else {
			move.Move ();
		}
		if (dcooldown == 120) {
			disruption.enabled = false;
		}
	}
}
