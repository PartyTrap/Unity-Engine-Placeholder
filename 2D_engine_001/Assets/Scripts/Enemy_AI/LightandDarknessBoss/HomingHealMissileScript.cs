using UnityEngine;
using System.Collections;

public class HomingHealMissileScript : MonoBehaviour {

	public GameObject darkVestige;
	public TrailRenderer trail;
	public Vector3 targetPosition;
	public int timer;
	public int lifetimer;
	public int targetlock = 120;
	// Use this for initialization
	void Start () {
		timer = 0;
		darkVestige = GameObject.Find ("DarkHalf");
		Physics2D.IgnoreLayerCollision (9, 9);
		Physics2D.IgnoreLayerCollision (9, 10);
		Physics2D.IgnoreLayerCollision (8, 8);
		trail.sortingLayerName ="Dynamic";
		trail.sortingOrder = 1;
		this.gameObject.GetComponent<Rigidbody2D> ().AddForce (this.transform.up * 400);
	}

	// Update is called once per frame
	void Update () {
		timer++;
		this.gameObject.GetComponent<Rigidbody2D> ().AddForce (this.transform.forward * 50);
		if (!(timer > targetlock)) {
			if (timer > (targetlock / 2)) {
				this.gameObject.transform.LookAt (darkVestige.transform.position);
			}
		}

	}

}
