using UnityEngine;
using System.Collections;

public class Vinepull : MonoBehaviour {
	[SerializeField] private LineRenderer vine;
	[SerializeField] private GameObject player;
	[SerializeField] private Material vinemat;
	// Use this for initialization
	void OnEnable(){
		vine.sortingLayerID = 4;
		vine.sortingOrder = 0;
		vine.SetWidth (0.5f, 0.5f);
		vine.SetColors (Color.green, Color.green);
		vine.SetPosition (0, this.gameObject.transform.position);
		vine.SetPosition (1, player.transform.position);
		vine.enabled = true;
		vine.material = vinemat;
	}
	// Update is called once per frame
	void Update () {
		vine.SetPosition (1, player.transform.position);
		player.GetComponent<Rigidbody2D> ().AddForce ((player.transform.position - this.gameObject.transform.position).normalized * -350);
	}
	void OnDisable(){
		vine.enabled = false;
	}
}
