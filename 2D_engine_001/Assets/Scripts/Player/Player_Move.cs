using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour {

	private float moveHorizontal;
	private float moveVertical;

	private Vector3 move;
	private bool isMove;
	public Vector2 lastMove;

	public float Speed;
	private string keyPressed;
	Animator anim;
	Rigidbody2D rb;
	private 
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){
		isMove = false;
		transform.eulerAngles = new Vector3(0,0,0);
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {

			isMove = true;
			lastMove = new Vector2(Input.GetAxisRaw ("Horizontal"), 0.0f);
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {

			isMove = true;
			lastMove = new Vector2(0.0f, Input.GetAxisRaw ("Vertical"));
		}
		anim.SetBool("isMoving", isMove);
	}
	// Update is called once per frame
	void FixedUpdate () {
			
		moveHorizontal = Input.GetAxisRaw ("Horizontal");
		moveVertical = Input.GetAxisRaw ("Vertical");

		move = new Vector3 (moveHorizontal, moveVertical, 0.0f);

		anim.SetFloat ("MoveX", moveHorizontal);
		anim.SetFloat ("MoveY", moveVertical);
		anim.SetFloat ("DirectionX", lastMove.x);
		anim.SetFloat ("DirectionY", lastMove.y);
		rb.AddForce (move * Speed);

	}
}