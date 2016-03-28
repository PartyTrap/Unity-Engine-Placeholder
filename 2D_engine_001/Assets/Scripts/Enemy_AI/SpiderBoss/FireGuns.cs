using UnityEngine;
using System.Collections;

public class FireGuns : MonoBehaviour {
	public GameObject rightGun;
	public GameObject leftGun;
	public GameObject bullet;
	public float rdir = 1.0f;
	public float ldir = -1.0f;
	public float rightGunAngle;
	public float leftGunAngle;
	public int counter;
	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (9, 9);

	}
	
	// Update is called once per frame
	void Update () {
		rightGun.transform.Rotate (new Vector3 (0.0f, 0.0f, rdir));
		rightGunAngle += rdir;
		leftGun.transform.Rotate (new Vector3 (0.0f, 0.0f, ldir));
		leftGunAngle += ldir;
		if (rightGunAngle == 30) {
			rdir = -rdir;
		}
		if(rightGunAngle == -30){
			rdir = -rdir;
		}
		if (leftGunAngle == 30) {
			ldir = -ldir;
		}
		if (leftGunAngle == -30) {
			ldir = -ldir;
		}
		counter++;
		if (counter == 10) {
			counter = 0;
			GameObject bullet1 = (Instantiate (bullet, rightGun.transform.position, rightGun.transform.rotation)) as GameObject;
			GameObject bullet2 = (Instantiate (bullet, leftGun.transform.position, leftGun.transform.rotation)) as GameObject;
			bullet1.GetComponent<Rigidbody2D> ().AddForce (bullet1.transform.up * -500);
			bullet2.GetComponent<Rigidbody2D> ().AddForce (bullet1.transform.up * -500);
		}
	}
}
