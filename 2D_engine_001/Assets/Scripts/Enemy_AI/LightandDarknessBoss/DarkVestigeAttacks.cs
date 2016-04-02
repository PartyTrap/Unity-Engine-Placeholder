using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DarkVestigeAttacks : MonoBehaviour {

	[SerializeField] private FireBlackHole blackHole;
	[SerializeField] private FireMissiles lasers;
	[SerializeField] private SpawnMinions spawner;
	[SerializeField] private BossMove move;
	[SerializeField] private int bhcooldown;
	[SerializeField] private int lcooldown;
	[SerializeField] private int scooldown;
	public List<int> bossattack = new List<int>();
	// Update is called once per frame
	void Update () {
		if (bhcooldown > 0) {
			bhcooldown--;
		}
		if (lcooldown > 0) {
			lcooldown--;
		}
		if (scooldown > 0) {
			scooldown--;
		}
		if (bhcooldown == 0) {
			bossattack.Add (0);
		}
		if (lcooldown == 0) {
			bossattack.Add (1);
		}
		if (scooldown == 0) {
			bossattack.Add (2);
		}
		if (bossattack.Count > 0) {
			int decision = Random.Range (0, bossattack.Count);
		
			switch (((int)bossattack [decision])) {
			case 0: //Black Hole
				blackHole.enabled = true;
				blackHole.enabled = false;
				bhcooldown = 420;
				break;
			case 1: //Lasers
				lasers.enabled = true;
				lcooldown = 120;
				break;
			case 2: //Spawn
				spawner.enabled = true;
				spawner.enabled = false;
				scooldown = 300;
				break;
			}
			bossattack.Clear ();
		} else {
			move.Move ();
		}
		if (lcooldown == 60) {
			lasers.enabled = false;
		}
	}
}
