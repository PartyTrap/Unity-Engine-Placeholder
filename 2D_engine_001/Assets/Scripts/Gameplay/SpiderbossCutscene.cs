using UnityEngine;
using System.Collections;

public class SpiderbossCutscene : MonoBehaviour {
	public Player_Shoot ps;
	public Player_Dash pd;
	public Player_Move pm;
	public Boss2Roll br;
	public GameObject cam;
	public GameObject boss;
	public GameObject player;
	public BossAudioManager sound;
	public Animator panim;
	public float counter;
	void Start(){
		sound = GameObject.Find ("BossAudioManager").GetComponent<BossAudioManager>();
	}
	void OnDestroy(){
		ps.enabled = true;
		pd.enabled = true;
		pm.enabled = true;
		br.enabled = true;
	}
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter == 60) {
			sound.PlayEnemyClip ();
			panim.SetFloat ("MoveY", 1.0f);
			panim.SetFloat ("DirectionY", 1.0f);
		}
		//move camera
		if (counter >= 60 && counter <= 120) {
			cam.GetComponent<CameraFollow> ().playerToFollow = null;
			cam.transform.Translate (new Vector3 (0.0f, 0.2f, 0.0f));
		}
		if (counter == 120) {
			sound.PlayEnemyClip ();
		}
		if (counter >= 120 && counter <= 180) {
			
			cam.transform.Translate(new Vector3 (0.0f, -0.2f, 0.0f));
		}
		if (counter == 180) {
			cam.transform.Translate (new Vector3 (0.0F, -12.0F, 0.0F));
			cam.GetComponent<CameraFollow> ().playerToFollow = player;
			Destroy (this.gameObject);
		}
	}
}
