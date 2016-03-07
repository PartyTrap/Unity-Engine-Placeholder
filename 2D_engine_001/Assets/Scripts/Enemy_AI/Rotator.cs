using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	public bool rotate = false;
	// Use this for initialization
	void Start () {
		//rotate = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (rotate) {
			this.transform.Rotate (new Vector3 (0, 0, 1));
		}
	}
}
