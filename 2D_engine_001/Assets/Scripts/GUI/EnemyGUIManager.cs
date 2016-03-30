using UnityEngine;
using System.Collections;

public class EnemyGUIManager : MonoBehaviour {

	[SerializeField]private Enemy_State es;
	private float dmg;
	private float currHealth;
	private float move;

	// Use this for initialization
	void Start () {
		currHealth = es.enemyHealth;
	}

	// Update is called once per frame
	void Update () {
		dmg = currHealth - es.enemyHealth;
		GetComponent<RectTransform> ().Translate (new Vector3 (-dmg, 0, 0));
	}
}
