using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossCoreAttacks : MonoBehaviour {
	[SerializeField] private FireLaserPoint tlaser;
	[SerializeField] private GameObject blaser;
	[SerializeField] private GameObject blaserSprite;
	[SerializeField] private Revive revive;
	[SerializeField] private BossMove move;
	[SerializeField] private int tcooldown;
	[SerializeField] private int bcooldown = 200;
	[SerializeField] private int rcooldown = 1200;
	public List<int> bossattacks = new List<int> ();
	// Update is called once per frame
	void Update () {
		if (tcooldown > 0) {
			tcooldown--;
		}
		if (bcooldown > 0) {
			bcooldown--;
		}
		if (rcooldown > 0) {
			rcooldown--;
		}
		if (tcooldown == 0) {
			bossattacks.Add (0);
		}
		if (bcooldown == 0) {
			bossattacks.Add (1);
		}
		if (rcooldown == 0) {
			bossattacks.Add (2);
		}
		if (bossattacks.Count > 0) {
			int decision = Random.Range (0, bossattacks.Count);
			switch (((int)bossattacks [decision])) {
			case 0: //Trailing laser
				tlaser.enabled = true;
				tcooldown = 300;
				break;
			case 1: //Buster Laser
				move.enabled = false;
				blaser.SetActive (true);
				blaserSprite.SetActive (false);
				bcooldown = 300;
				break;
			case 2: //Revive
				revive.enabled = true;
				revive.enabled = false;
				this.gameObject.SetActive(false);
				//Play anim
				break;
			}
			bossattacks.Clear ();
		} else {
			move.Move ();
		}
		if (tcooldown == 150) {
			tlaser.enabled = false;
		}
		if (bcooldown == 150) {
			blaser.SetActive(false);
			move.enabled = true;
		}
		if (bcooldown == 75) {
			blaserSprite.SetActive (true);
		}
	}
}
