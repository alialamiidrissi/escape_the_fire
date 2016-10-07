using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static bool paused = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel(string level){
		SceneManager.LoadScene(level);
        UIManager.paused = false;
	}
    public void quit()
    {
        Application.Quit();
    }
}