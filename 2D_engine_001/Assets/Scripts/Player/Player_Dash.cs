using UnityEngine;
using System.Collections;

public class Player_Dash : MonoBehaviour {

	private Rigidbody2D rb;
    public float cooldown;
	public Player_Move player;
    public int active = 1;
    public float stamina;
    [SerializeField] private AudioManager audio;

	public float distance;
	// Use this for initialization
	void Start () {
        audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		rb = this.GetComponent<Rigidbody2D> ();
        stamina = cooldown;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKeyDown (KeyCode.X)) {
            rb.AddForce (player.move * distance * active);
            if (player.isMove == true && active == 1)
            {
                StartCoroutine(wait());
            }
		}
	}

    private IEnumerator wait(){

        audio.PlayPlayerDashClip();
        active = 0;
        stamina = 0;
        for (float x = 0; x < cooldown; x = x + 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            stamina = stamina + 0.01f;
        }
        active = 1;
    }
        
}
