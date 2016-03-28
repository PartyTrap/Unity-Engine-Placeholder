using UnityEngine;
using System.Collections;

public class Flamethrower : MonoBehaviour {
	public float dir = 1.0f;
	public float angle = 0;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		angle += dir;
		this.transform.Rotate(new Vector3(0.0f,0.0f,dir));
		if(angle == 30){
			dir = -dir;
		}
		if(angle == -30){
			dir = -dir;
		}
	}
}
