using UnityEngine;
using System.Collections;

public class SpiderBossEnding : MonoBehaviour {

    [SerializeField]private BossState BS;
    [SerializeField]private mapGenerationBossArena2 newMap;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (BS.bossHealth <= 0)
        {
            newMap.setMap(BossArena2b.map);
            newMap.redrawMap();
        }
           
	}
}
