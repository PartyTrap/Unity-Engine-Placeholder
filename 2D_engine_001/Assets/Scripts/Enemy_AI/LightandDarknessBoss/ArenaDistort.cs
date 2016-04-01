using UnityEngine;
using System.Collections;

public class ArenaDistort : MonoBehaviour {
	[SerializeField] private int mapPhase;
	[SerializeField] private GameObject mapGen;
	// Use this for initialization
	void OnEnable(){
		mapPhase++;
		if (mapPhase == 3) {
			mapPhase = 0;
		}
		switch (mapPhase) {
		case 0:
			mapGen.GetComponent<mapGenerationBossArena3> ().setMap (BossArena2.map);
			break;
		case 1:
			mapGen.GetComponent<mapGenerationBossArena3> ().setMap (BossArena.map);
			break;
		case 2:
			mapGen.GetComponent<mapGenerationBossArena3> ().setMap (BossArena3.map);
			break;
		}
		mapGen.GetComponent<mapGenerationBossArena3> ().redrawMap ();
	}
}
