using UnityEngine;
using System.Collections;

public class Dynamic_Object : MonoBehaviour {

	public float Speed = 0.1f;
	public LayerMask Blocking_Layer;

	private BoxCollider2D box_Collider;
	private Rigidbody2D rB2D;
	private float inverse_move_time;



	// Use this for initialization
	protected virtual void Start () {

		box_Collider = GetComponent<BoxCollider2D> ();
		rB2D = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
