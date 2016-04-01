using UnityEngine;
using System.Collections;

public class HomingBlackHoleCollision : MonoBehaviour {

	// Use this for initialization
	public GameObject missile;
	public BlackHoleDamage blackHole;
	public Rigidbody2D rb;
	void Start ()
	{
		Physics2D.IgnoreLayerCollision(9, 9);
		Physics2D.IgnoreLayerCollision(9, 11);
		Physics2D.IgnoreLayerCollision (9, 10);

	}

	void OnCollisionEnter2D(Collision2D c){
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		rb.isKinematic = true;
		blackHole.blackHole = true;
		this.gameObject.transform.eulerAngles = new Vector3 (0, -90, 90);

	}

}
