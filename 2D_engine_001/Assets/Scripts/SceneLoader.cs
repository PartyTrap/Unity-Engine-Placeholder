using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	public void LoadToScene (string sceneName){
		SceneManager.LoadScene(sceneName);
	}

	}
	
