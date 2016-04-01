using UnityEngine;
using System.Collections;

public class HomingHealMissileCollision : MonoBehaviour {
	[SerializeField] GameObject missile;
	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision(9, 10);
		Physics2D.IgnoreLayerCollision(9, 9);
	}
	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "Boss") {
			c.gameObject.GetComponent<DarkVestige> ().HealDamage (2000.0f);
		}
		Destroy (missile);

	}
}
