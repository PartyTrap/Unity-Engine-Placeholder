using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour {

	public float Speed;
	private string keyPressed;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

	void Update(){
		if (Input.GetKey("a"))
		{
			keyPressed = "a";
			//Quaternion rotation = Quaternion.EulerRotation(0,0,90);
			transform.eulerAngles = new Vector3(0,0,270);
            //GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.up * Speed * -1);
            anim.SetTrigger("Walk_Left");
			//anim.SetTrigger("Walk");
        }
		else if (Input.GetKey("d"))
		{
			keyPressed = "d";
			//Quaternion rotation = Quaternion.EulerRotation(0, 0, 270);
			transform.eulerAngles = new Vector3(0, 0, 90);
            //GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.up * Speed * -1);
            anim.SetTrigger("Walk_Right");
			//anim.SetTrigger("Walk");
        }
		else if (Input.GetKey("s"))
		{
			keyPressed = "s";
			//Quaternion rotation = Quaternion.EulerRotation(0, 0, 180);
			transform.eulerAngles = new Vector3(0, 0, 0);
            //GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.up * Speed * -1);
           // anim.SetTrigger("Walk");
			anim.SetTrigger("Walk_Down");
        }
		else if (Input.GetKey("w"))
		{
			keyPressed = "w";
			//Quaternion rotation = Quaternion.EulerRotation(0, 0, 180);
			transform.eulerAngles = new Vector3(0, 0, 180);
            //GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.up * Speed * -1);
            //anim.SetTrigger("Walk");
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