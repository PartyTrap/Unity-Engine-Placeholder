using UnityEngine;
using System.Collections;

public class cutsceneManager : MonoBehaviour {
	public Player_Shoot pa;
	public Player_Move pm;
	public Player_Dash pd;
	public EnemyAITest eat;
	public GameObject player;
	public GameObject canvas;
	public int counter;
	public Animator anim;
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = player.GetComponent<Animator> ();

	}
	void OnDestroy(){
		pa.enabled = true;
		pm.enabled = true;
		pd.enabled = true;
		eat.enabled = true;
		canvas.SetActive (true);
	}
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter == 60) {
			anim.SetBool ("isMoving", false);
			anim.SetFloat ("DirectionY", 1.0f);
			anim.SetFloat ("MoveY", 1.0f);
		}
		if (counter == 120) {
			anim.SetBool ("isMoving", false);
			anim.SetFloat("DirectionY",0.0f);
			anim.SetFloat ("DirectionX", 1.0f);
			anim.SetFloat ("MoveX", 1.0f);
		}
		if (counter == 180) {
			anim.SetBool ("isMoving", false);
			anim.SetFloat ("DirectionX", 0.0f);
			anim.SetFloat ("DirectionY", -1.0f);
			anim.SetFloat ("MoveY", -1.0f);
		}
		if (counter == 240) {
			anim.SetBool ("isMoving", false);
			anim.SetFloat ("DirectionX", -1.0f);
			anim.SetFloat("DirectionY",0.0f);
			anim.SetFloat ("MoveX", -1.0f);
		}
		if (counter == 300) {
			anim.SetBool ("isMoving", true);
			anim.SetFloat("DirectionY",0.0f);
			anim.SetFloat ("DirectionX", 1.0f);
			anim.SetFloat ("MoveX", 1.0f);
			anim.SetFloat ("MoveY", 0.0f);
			player.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * pm.Speed);
		}
		if(counter == 360){
			anim.SetBool ("isMoving", true);
			anim.SetFloat ("MoveX", 1.0f);
			anim.SetFloat ("MoveY", 0.0f);
			anim.SetFloat("DirectionY",0.0f);
			anim.SetFloat ("DirectionX", 1.0f);
			player.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * pm.Speed);
			Destroy (this.gameObject);
		}

	}
}
