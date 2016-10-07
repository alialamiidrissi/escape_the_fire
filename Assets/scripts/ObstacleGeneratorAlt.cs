using UnityEngine;
using System.Collections;

public class ObstacleGeneratorAlt : MonoBehaviour
{
    /*  public ObjectPool obstacle_one;
      public ObjectPool obstacle_two;
      public ObjectPool fireBlastsPool;
      public ObjectPool firePlace;
      public int firePlaceprobability;
      public int fireBlastProbability;
      private bool flip;

      */
    public int flipProbability;
    
    private float startTime;
    public ObjectPool[] objectPools;
    public float[] Probabiltydistribution;
    void Start()
    {
        startTime = Time.time;
    }
    public bool createObstacle(Vector3 pos)
    {
        GameObject obstacle;
        float timeA = Time.time - startTime;
        int index = Utilities.choose(Probabiltydistribution);
        if((index == 0 || index == 1 && timeA < 15f) )
            index = chooseSimple();
        obstacle = objectPools[index].getObject();
        obstacle.transform.position = new Vector3(pos.x, obstacle.transform.position.y, obstacle.transform.position.z);
        obstacle.SetActive(true);
        return index == 1 || index == 3;
    }
    public int chooseSimple()
    {
        return Random.Range(0, 100) < flipProbability ? 2 : 3;
    }
}
