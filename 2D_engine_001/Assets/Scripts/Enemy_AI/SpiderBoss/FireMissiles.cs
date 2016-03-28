using UnityEngine;
using System.Collections;

public class FireMissiles : MonoBehaviour {
	public int addAngle=0;
	public int minAngle= -45;
	public int maxAngle= 45;
	public int direction = 1;
	public int counter =0;
	public float baseAngle;
	public GameObject missilePrefab;
	// Use this for initialization
	void Start () {
		baseAngle = this.transform.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter % 2 == 1) {
			addAngle += direction;
			if (addAngle + direction > maxAngle) {
				direction = -1;
			} 
			if (addAngle + direction < minAngle) {
				direction = 1;
			}
		}
		if(counter == 10){
			counter = 0;
			this.transform.eulerAngles = new Vector3 (0, 0, baseAngle + addAngle);
			GameObject missile = (Instantiate (missilePrefab,this.gameObject.transform.position,this.transform.rotation)) as GameObject;
			missile.GetComponent<Rigidbody2D>().AddForce(this.gameObject.transform.up * 2000);
		}
	}
}
