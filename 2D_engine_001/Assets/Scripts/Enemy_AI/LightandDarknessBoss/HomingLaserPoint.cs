using UnityEngine;
using System.Collections;

public class HomingLaserPoint : MonoBehaviour {

	public GameObject player;
	public TrailRenderer trail;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		Physics2D.IgnoreLayerCollision (9, 9);
		Physics2D.IgnoreLayerCollision (9, 10);
		trail.sortingLayerName ="Dynamic";
		trail.sortingOrder = 1;
	}

	// Update is called once per frame
	void Update () {
		this.gameObject.transform.LookAt (player.transform.position);
		this.gameObject.GetComponent<Rigidbody2D> ().AddForce (this.transform.forward * 100);

	}
}
