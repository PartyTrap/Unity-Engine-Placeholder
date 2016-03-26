using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    private bool zoomed = false;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (zoomed == false)
            {
                this.GetComponent<CameraFollow>().follow = false;
                Zoom();
            }
            else
            {
                this.GetComponent<CameraFollow>().follow = true;
                this.transform.position = new Vector3 (0,0,-10);
                zoomed = false;
            }
        }
         
	}

    private void Zoom(){

        this.transform.position = new Vector3 (10,-32,-45);
        zoomed = true;

    }
}
