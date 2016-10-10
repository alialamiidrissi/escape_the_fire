using UnityEngine;
using System.Collections;

public class PlateformGenerator : MonoBehaviour
{
    public GameObject plateform;
    public Transform genPoint;
    private float platformWidth;
    public static bool simple;
    public int gapCounter;
    private int counter;
    public ScoreLPManager score;
    public ObjectPool plateform_pool;
    public bool useGaps;
    public CoinGenerator coins;
    public ObstacleGeneratorAlt obstacles;
    public int coinsDistributionProbability;
    public int obstacleDistributionProbability;
    private bool addCentral;
    private float startTime;
    // Use this for initialization
    public float gap;
    private float delay;
    private int minRange, maxRange;
    void Start()
    {
        platformWidth = ((plateform.GetComponent<BoxCollider2D>().size.x))*0.6f;
        Instantiate(plateform, transform.position, transform.rotation);
        counter = 1;
        addCentral = true;
        startTime = Time.time;
        minRange = 8;
        maxRange = 10;
        delay = 5;
    }

    // Update is called once per frame
    void Update()
    { float runtime = Time.time - startTime;
        if (runtime > delay )
        {
            if (obstacleDistributionProbability < 40)
            {
                obstacleDistributionProbability += 5;
            }
            if(runtime > 10f)
            {
                if (minRange > 3)
                    minRange -= 1;
                if (score.Score > 2000 && maxRange > 6)
                    maxRange -= 1;
            }
            delay *= 1.5f;
        }
        addCentral = true;
        if (runtime > 10f)
        {
            useGaps = true;
            gapCounter = Random.Range(minRange, maxRange);
        }
        if (transform.position.x < genPoint.position.x)
        {
            float x = (counter == 0) ? transform.position.x + platformWidth + gap : transform.position.x + platformWidth;
            transform.position = new Vector3(x, plateform.transform.position.y, transform.position.z);
            if (useGaps)
            {
                counter = (counter + 1) % gapCounter;
                if (counter == 0)
                    simple = true;
                else
                    simple = false;
            }
            GameObject obj = plateform_pool.getObject();
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            plateform_pool.enableObject(obj);
            if (Random.Range(0, 100) <= obstacleDistributionProbability)
            {
                if (obstacles.createObstacle(obj.transform.position))
                    addCentral = false;
            }

            if (Random.Range(0, 100) <= coinsDistributionProbability)
                coins.createCoins(obj.transform.position, addCentral);
            plateform_pool.enableObject(obj);

        }
    }
    void restart()
    {
        startTime = Time.time;
        useGaps = false;
    }
}
