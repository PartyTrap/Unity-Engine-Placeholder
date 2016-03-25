using UnityEngine;
using System.Collections;

public class Conveyor_Belt : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    public Vector3 direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D col){
        if (col.tag == "Player")
        {
            col.attachedRigidbody.AddForce(direction * speed);
           // rb = col.GetComponent<Rigidbody2D>();
           //rb.AddForce(new Vector3(1, 0, 0) * speed);
        }
    }

    void OnTriggerExit2D(Collider2D col){

        //if (col.tag == "Player")
        //    col.attachedRigidbody.AddForce(direction * -speed);

    }
}
