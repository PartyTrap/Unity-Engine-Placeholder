using UnityEngine;
using System.Collections;

public class SpawnMinions : MonoBehaviour {
	[SerializeField] private GameObject sp1;
	[SerializeField] private GameObject sp2;
	[SerializeField] private GameObject sp3;
	[SerializeField] private GameObject sp4;
	[SerializeField] private GameObject sp5;
	[SerializeField] private GameObject minion;
	void OnEnable(){
		Instantiate (minion, sp1.transform.position, sp1.transform.rotation);
		Instantiate (minion, sp2.transform.position, sp2.transform.rotation);
		Instantiate (minion, sp3.transform.position, sp3.transform.rotation);
		Instantiate (minion, sp4.transform.position, sp4.transform.rotation);
		Instantiate (minion, sp5.transform.position, sp5.transform.rotation);
	}
}
