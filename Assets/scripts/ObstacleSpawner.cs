using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{

    private float nextSpawn = 0;


    public ObstaclePool obstacle_one_pool;
    public AnimationCurve spawnCurve;
    public float curveLengthInSeconds = 30f;
    private float startTime;
    public float randomness = 0.5f;


    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextSpawn)
        {
            GameObject obj = obstacle_one_pool.getObject();
            obj.transform.position = new Vector3(transform.position.x,-1,obj.transform.position.z);
            obj.transform.rotation = Quaternion.identity;
            obstacle_one_pool.enableObject(obj);

            float curvePos = (Time.time - startTime) / curveLengthInSeconds;
            if (curvePos > 1f)
            {
                curvePos = 1f;
                startTime = Time.time;
            }

            nextSpawn = Time.time + spawnCurve.Evaluate(curvePos) + Random.Range(-randomness, randomness);

        }

    }
}