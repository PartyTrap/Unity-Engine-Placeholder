using UnityEngine;
using System.Collections;

public class Crater : MonoBehaviour {
	public int counter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter == 160) {
			Destroy (this.gameObject);
		}
	}
}
