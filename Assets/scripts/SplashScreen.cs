using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    public string SceneToLoad;
    public int SecTillSceneLoad;

	// Use this for initialization
	void Start () {
        Invoke("OpenNextScene", SecTillSceneLoad);
	}
	
	void OpenNextScene()
    {
        SceneManager.LoadScene(SceneToLoad);

    }
}
