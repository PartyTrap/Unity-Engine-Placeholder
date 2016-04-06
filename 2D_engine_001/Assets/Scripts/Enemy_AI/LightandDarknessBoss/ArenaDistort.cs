using UnityEngine;
using System.Collections;

public class ArenaDistort : MonoBehaviour {
	[SerializeField] private int mapPhase;
	[SerializeField] private GameObject mapGen;
    [SerializeField] private GameObject Flashbang;
	// Use this for initialization
	void OnEnable(){
        Instantiate(Flashbang, Vector3.zero,Quaternion.identity);
        StartCoroutine(wait());
		
	}

    public IEnumerator wait(){

        yield return new WaitForSeconds(3);
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
