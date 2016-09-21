using UnityEngine;
using System.Collections;

public class ObstacleGeneratorAlt : MonoBehaviour
{
    public ObjectPool obstacle_one;
    public ObjectPool obstacle_two;
    public ObjectPool firePlace;
    public int flipProbability;
    private bool flip;
    void Start()
    {
        flip = false;
    }
    public bool createObstacle(Vector3 pos)
    {
        GameObject obstacle;
        bool toRet;
        if (!flip)
        {
            print(flip);
            obstacle = obstacle_one.getObject();
            toRet = false;
        }
        else
        {
            obstacle = obstacle_two.getObject();
            obstacle.transform.position = new Vector3(pos.x, obstacle.transform.position.y, obstacle.transform.position.z);
            toRet = true;
        }
        obstacle.SetActive(true);
        if (Random.Range(0, 100) <= flipProbability)
        {
            flip = !flip;
        }
        return toRet;
    }
}
