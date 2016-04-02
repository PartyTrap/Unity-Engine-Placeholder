using UnityEngine;
using System.Collections;

public class Player_Shoot : MonoBehaviour {

    [SerializeField]private bulletSpawn BS;
    [SerializeField]private Player_State PS;
    [SerializeField]private AudioManager audio;
	// Use this for initialization
	void Start () {
        audio = GameObject.Find("PlayerAudioManager").GetComponent<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Z)) {
            audio.PlayBulletFireClip();
			BS.fireBullet (PS.dmg);
		}
	}
}
