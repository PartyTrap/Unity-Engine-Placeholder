using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    public bool zoomed = false;
	private bool paused = false;
	//public bool PauseGame;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {

			if (Input.GetKeyDown (KeyCode.M)) {			
				if (zoomed == false) {
					this.GetComponent<CameraFollow> ().follow = false;
				paused = true;
					Zoom ();

				} else {
					this.GetComponent<CameraFollow> ().follow = true;
					this.transform.position = new Vector3 (0, 0, -10);
					paused = false;
					zoomed = false;
				}
			}
         
		}

   public void Zoom(){

        this.transform.position = new Vector3 (10,-32,-45);
		zoomed = true;
		pause ();

    }

	public void pause(){
			if (paused == true) {
				Time.timeScale = 0.1f;   ///GAME PAUSED   ///////
			} else {
				Time.timeScale = 1.0f;   ///// GAME RESUME //////
			}
	}


	}


