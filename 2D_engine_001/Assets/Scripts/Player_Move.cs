using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour {

	public float Speed;
	private string keyPressed;
	Animator anim;
	private 
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update(){
		if (Input.GetKey("a"))
			{
				keyPressed = "a";
				anim.SetTrigger("Walk_Left");
				transform.eulerAngles = new Vector3(0,0,270);
		    }
			else if (Input.GetKey("d"))
			{
					keyPressed = "d";
					anim.SetTrigger("Walk_Right");
					transform.eulerAngles = new Vector3(0, 0, 90);
			}
			else if (Input.GetKey("s"))
			{
					keyPressed = "s";
					anim.SetTrigger("Walk_Down");
					transform.eulerAngles = new Vector3(0, 0, 0);
			}
			else if (Input.GetKey("w"))
			{
					keyPressed = "w";
					anim.SetTrigger("Walk_Up");
					transform.eulerAngles = new Vector3(0, 0, 180);
			}
		      else
		    {
		           keyPressed = "";
		           anim.SetTrigger("Idle");
		    }
	}
	// Update is called once per frame
	void FixedUpdate () {


		if (Input.anyKey) {
			if ((keyPressed == "s") || (keyPressed == "w") || (keyPressed == "d") || (keyPressed == "a")) {
				GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.up * Speed * -1);
			}
		}
	}
}