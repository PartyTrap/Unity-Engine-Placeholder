using UnityEngine;
using System.Collections;

public class Heal : MonoBehaviour {
	[SerializeField] private GameObject healMissile;
	void Start(){
	}
	void Update(){
	}
	void OnEnable(){
		Instantiate (healMissile, this.gameObject.transform.position, this.gameObject.transform.rotation);
	}
}
