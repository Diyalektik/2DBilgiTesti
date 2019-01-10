using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDegisimi : MonoBehaviour {

	

	void Start () {
        DontDestroyOnLoad(this);
        

	}
	
    public void SceneGec()
    {
        
        if (SceneManager.GetActiveScene().buildIndex+1<= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       
    }
	

}
