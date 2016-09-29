using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;
    private CameraController cameraGame;
    public PlayerController player;
    private Vector3 playerStartPoint;
    private Destroyer[] platformList;

	// Use this for initialization
	void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;
        cameraGame = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update() {

    }
    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f); // delay for half a second
        platformList = FindObjectsOfType<Destroyer>();
        for(int i=0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);
        cameraGame.transform.position = new Vector3(cameraGame.transform.position.x -cameraGame.shift, cameraGame.transform.position.y, cameraGame.transform.position.z);
        cameraGame.shift = 0;
    }
}
