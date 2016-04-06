using UnityEngine;
using System.Collections;

public class FinalbossCutscene : MonoBehaviour {
	public Player_Shoot ps;
	public Player_Dash pd;
	public Player_Move pm;
	public DarkVestige dv;
	public LightVestige lv;
	public BossMove bm;
	public GameObject cam;
	public GameObject boss;
	public GameObject bl;
	public GameObject player;
	public GameObject core;
	public BossAudioManager sound;
	public Animator panim;
	public Animator banim;
	public float counter;
	void Start(){
		sound = GameObject.Find ("BossAudioManager").GetComponent<BossAudioManager> ();
		bl.SetActive (true);
	}
	void OnDestroy(){
		ps.enabled = true;
		pd.enabled = true;
		pm.enabled = true;
		bm.enabled = true;
		dv.enabled = true;
		lv.enabled = true;
	}
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter == 60) {
			sound.PlayEnemyClip ();
			panim.SetFloat ("MoveX", -1.0f);
			panim.SetFloat ("DirectionX", -1.0f);
		}
		if (counter > 60 && counter < 120) {
			cam.GetComponent<CameraFollow> ().playerToFollow = null;
			cam.transform.Translate (new Vector3 (-0.2f, 0.0f, 0.0f));
		}
		//move camera
		if (counter >= 120 && counter <= 180) {
			
			cam.transform.Translate (new Vector3 (0.0f, 0.2f, 0.0f));
		}
		if (counter == 180) {
			bl.SetActive (false);

			banim.SetBool ("open", false);
		}
		if (counter == 300) {
			core.SetActive (false);
			sound.PlayEnemyClip ();
			banim.SetBool ("intro", false);
			panim.SetFloat ("MoveX", 0.0f);
			panim.SetFloat ("MoveY", 1.0f);
			panim.SetFloat ("DirectionX", 0.0f);
			panim.SetFloat ("DirectionY", 1.0f);

		}
		if (counter >= 300 && counter <= 360) {

			cam.transform.Translate(new Vector3 (0.2f, -0.2f, 0.0f));
		}
		if (counter == 360) {
			cam.transform.Translate (new Vector3 (0.0F, -12.0F, 0.0F));
			cam.GetComponent<CameraFollow> ().playerToFollow = player;
			Destroy (this.gameObject);
		}
	}

}
