using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleGenerator : MonoBehaviour {
    //distance to player
    public float minDist;
    public float maxDist;

    //time between obstacles appearence
    public float minTime;
    public float maxTime;

    public ObstaclePool obstacle_one_pool;

    private float startTime;
    private float delay;
    private float distoPlayer;

    private GameObject player;



    // Use this for initialization
    void Start () {
        startTime = Time.time;
        delay = Random.Range(minTime, maxTime);
        distoPlayer = Random.Range(minDist, maxDist);
        player = GameObject.Find("player");

    }
	
	// Update is called once per frame
	void Update () {
	    if(Time.time-startTime >= delay)
        {
            GameObject obstacle = obstacle_one_pool.getObject();
            obstacle.transform.position = new Vector3(player.transform.position.x+ distoPlayer, 1.5f, obstacle.transform.position.z);
            obstacle_one_pool.enableObstacle(obstacle);
            startTime = Time.time;
            delay = Random.Range(minTime, maxTime);
            distoPlayer = Random.Range(minDist, maxDist);
        }
	}
}
