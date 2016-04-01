using UnityEngine;
using System.Collections;

public class FireLaserPoint : MonoBehaviour {
	[SerializeField] private GameObject laserPoint;
	[SerializeField] private GameObject laserEnd;
	[SerializeField] private LineRenderer laser;
	public Material lasermat;
	void OnEnable(){
		laserEnd = (Instantiate (laserPoint, this.gameObject.transform.position, this.gameObject.transform.rotation)) as GameObject;
		laser = this.gameObject.GetComponent<LineRenderer> ();
		laser.enabled = true;
		laser.sortingLayerID = 4;
		laser.sortingOrder = 0;
		laser.SetWidth (0.5f, 0.5f);
		laser.SetColors (Color.red, Color.red);
		laser.material = lasermat;
		laser.SetPosition (0, this.gameObject.transform.position);

	}
	void OnDisable(){
		Destroy (laserEnd.gameObject);
		laser.enabled = false;
	}
	void Update(){
		laser.SetPosition (1, laserEnd.transform.position);
	}
}
