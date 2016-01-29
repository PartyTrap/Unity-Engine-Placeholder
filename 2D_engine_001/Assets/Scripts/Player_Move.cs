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
				transform.eulerAngles = new Vector3(0,0,270);
		       
		        anim.SetTrigger("Walk_Left");
				
		    }
			else if (Input.GetKey("d"))
			{
					keyPressed = "d";
					
						transform.eulerAngles = new Vector3(0, 0, 90);
		        
			           anim.SetTrigger("Walk_Right");
				
			      }
		else if (Input.GetKey("s"))
		{
					keyPressed = "s";
					
					transform.eulerAngles = new Vector3(0, 0, 0);
	         
					anim.SetTrigger("Walk_Down");
			 }
			else if (Input.GetKey("w"))
			{
					keyPressed = "w";
				
					transform.eulerAngles = new Vector3(0, 0, 180);
		       
					anim.SetTrigger("Walk_Up");
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