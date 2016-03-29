using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BOSSHEALTHINATOR : MonoBehaviour {

	public Enemy_State ES;
	private Text Health;

	// Use this for initialization
	void Start () {
		Health = this.GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
        Health.text = ES.enemyHealth.ToString();
	}
}
