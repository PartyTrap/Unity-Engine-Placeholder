using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    [SerializeField] private GameObject audioManager;

	public void LoadToScene (string sceneName){
		SceneManager.LoadScene(sceneName);
	}

    public void LoadFromMem (){
        Instantiate(audioManager);
        Debug.Break();
        SceneManager.LoadScene(PlayerData.Instance.Level.ToString());
    }

	}
	
