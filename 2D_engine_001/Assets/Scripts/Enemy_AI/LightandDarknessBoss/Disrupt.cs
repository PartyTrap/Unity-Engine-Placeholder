using UnityEngine;
using System.Collections;

public class Disrupt : MonoBehaviour {
	[SerializeField] private Player_Move target;
	void OnDisable(){
		target.Speed = target.Speed * -1;
	}
	// Update is called once per frame
	void OnEnable(){
		target.Speed = target.Speed * -1;
	}
}
