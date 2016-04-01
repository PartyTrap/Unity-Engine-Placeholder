using UnityEngine;
using System.Collections;

public class Revive : MonoBehaviour {
	[SerializeField] private GameObject dark;
	[SerializeField] private GameObject light;

	void OnEnable(){
		dark.GetComponent<DarkVestige> ().HealDamage (2000.0f);
		light.GetComponent<LightVestige> ().HealDamage (2000.0F);
		//Play animation
	}
}
