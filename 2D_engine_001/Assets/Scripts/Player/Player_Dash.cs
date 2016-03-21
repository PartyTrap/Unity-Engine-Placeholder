using UnityEngine;
using System.Collections;

public class Player_Dash : MonoBehaviour {

	private Rigidbody2D rb;
    public int cooldown;
	public Player_Move player;
    public int active = 1;

	public float distance;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
            rb.AddForce (player.move * distance * active);
            if(player.isMove == true && active == 1)
                StartCoroutine (wait());
		}
	}

    private IEnumerator wait(){

        active = 0;
        yield return new WaitForSeconds(cooldown);
        active = 1;
    }
        
}
