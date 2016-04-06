using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public Enemy_State ES;
    public BossState BS;
	public GameObject E;
   



	// Use this for initialization
	void Start () {
       
	}

	// Update is called once per frame
	void Update () {
		this.transform.eulerAngles = new Vector3 (0, 180, 0);
		this.transform.position = E.transform.position;
		this.transform.position += new Vector3(0,1.0f,0);
        if (BS.enemyHealth <= 0 )
		{
            
			Delete_UI ();
			Destroy (this.gameObject.GetComponentInParent<GameObject>());
		}
	}
	public void Delete_UI(){
		Destroy (this.gameObject);
	}
}
