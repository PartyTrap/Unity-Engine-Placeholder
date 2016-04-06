using UnityEngine;
using System.Collections;

public class Revive : MonoBehaviour {
	[SerializeField] private GameObject dark;
	[SerializeField] private GameObject light;
	[SerializeField] private Animator anim;

	void OnEnable(){
		dark.GetComponent<DarkVestige> ().HealDamage (2000.0f);
		light.GetComponent<LightVestige> ().HealDamage (2000.0F);
		anim.SetBool ("open", false);
	}
}
