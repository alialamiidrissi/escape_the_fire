using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static bool paused = false;
    public GameObject pauseMenu;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel(string level){
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
        UIManager.paused = false;
	}
    public void quit()
    {
        Application.Quit();
    }
    public  void pauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        paused = true;
    }
    public void resumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

}