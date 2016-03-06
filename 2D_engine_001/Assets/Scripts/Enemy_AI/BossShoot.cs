using UnityEngine;
using System.Collections;

public class BossShoot : MonoBehaviour {
	public int counter;
	public GameObject thornprefab;
	public Rotator r;
	public bool active;
	// Use this for initialization
	void Start () {
		counter = 0;
		r = GetComponentInParent<Rotator> ();
		active = r.rotate;
		Physics2D.IgnoreLayerCollision (this.gameObject.layer, this.gameObject.layer);
	}
	
	// Update is called once per frame
	void Update () {
		active = r.rotate;
		if (active) {
			counter++;
			if (counter == 30) {
				counter = 0;
				Debug.Log ("shooting");
				GameObject thorn = (Instantiate (thornprefab, this.transform.position, this.transform.rotation)) as GameObject;
				Rigidbody2D thornrb = thorn.GetComponent<Rigidbody2D> ();
				thornrb.AddForce (this.transform.up * -200);
			}
		}
	}
}
