using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstaclePool : ObjectPool
{
    private static HashSet<GameObject> activeObstacles = new HashSet<GameObject>();
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    public void enableObstacle(GameObject obstacle)
    {
        bool enable = true;
        foreach (GameObject activeObstacle in activeObstacles)
        {
            if (activeObstacle.GetComponent<BoxCollider2D>().bounds.Intersects(obstacle.GetComponent<BoxCollider2D>().bounds))
                enable = false;
        }
        if (enable)
        {
            obstacle.SetActive(true);
            activeObstacles.Add(obstacle);
        }
    }


    public void disableObstacle(GameObject obstacle)
    {
        obstacle.SetActive(false);
        activeObstacles.Remove(obstacle);
    }
}
