using UnityEngine;
using System.Collections;

public class HomingMissileScript : MonoBehaviour {
	public GameObject player;
	public GameObject beacon;
	public GameObject target;
	public TrailRenderer trail;
	public Vector3 playerPosition;
	private Vector3 playerRB;
	public int timer;
	public int lifetimer;
	public int targetlock = 30;
	// Use this for initialization
	void Start () {
		timer = 0;
		player = GameObject.FindGameObjectWithTag ("Player");
		Physics2D.IgnoreLayerCollision (9, 9);
		Physics2D.IgnoreLayerCollision (9, 10);
		Physics2D.IgnoreLayerCollision (8, 8);
		trail.sortingLayerName ="Dynamic";
		trail.sortingOrder = 1;
	}
	
	// Update is called once per frame
	void Update () {
		lifetimer++;
		timer++;
		this.gameObject.GetComponent<Rigidbody2D> ().AddForce (this.transform.forward * 50);
		if (!(timer > targetlock)) {
			if (timer > (targetlock / 2)) {
				this.gameObject.transform.LookAt (player.transform.position);
				playerPosition = player.transform.position;
			}
		}
		if (timer == targetlock) {
			//Finalize Lock On
			target = Instantiate (beacon, playerPosition, beacon.transform.rotation) as GameObject;
			this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
			this.gameObject.transform.LookAt (target.transform.position);
			this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		}
		if (lifetimer == 180) {
			Destroy (this.gameObject);
		}
	}

}
