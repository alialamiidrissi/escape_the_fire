using UnityEngine;
using System.Collections;

public class ObstacleGeneratorAlt : MonoBehaviour
{
    public ObjectPool obstacle_one;
    public ObjectPool obstacle_two;
    public int firePlaceprobability;
    public ObjectPool firePlace;
    public int flipProbability;
    private bool flip;
    private float startTime;

    void Start()
    {
        flip = false;
        startTime = Time.time;
    }
    public bool createObstacle(Vector3 pos)
    {
        GameObject obstacle;
        bool toRet;
        if (Random.Range(0, 100) <= firePlaceprobability && Time.time-startTime>=15f)
        {
            obstacle = firePlace.getObject();
            toRet = false;
        }
        else
        {
            if (!flip)
            {
                obstacle = obstacle_one.getObject();
                toRet = false;
            }
            else
            {
                obstacle = obstacle_two.getObject();
                toRet = true;
            }
            if (Random.Range(0, 100) <= flipProbability)
            {
                flip = !flip;
            }
        }
        obstacle.transform.position = new Vector3(pos.x, obstacle.transform.position.y, obstacle.transform.position.z);
        obstacle.SetActive(true);
        return toRet;
    }
}
