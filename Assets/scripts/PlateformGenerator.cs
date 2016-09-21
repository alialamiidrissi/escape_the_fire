using UnityEngine;
using System.Collections;

public class PlateformGenerator : MonoBehaviour
{
    public GameObject plateform;
    public Transform genPoint;
    private float platformWidth;
    public int gapCounter;
    private int counter;
    public ObjectPool plateform_pool;
    public bool useGaps;
    public CoinGenerator coins;
    public ObstacleGeneratorAlt obstacles;
    public int coinsDistributionProbability;
    public int obstacleDistributionProbability;
    private bool addCentral;
    // Use this for initialization
    public float gap;
    void Start()
    {
        platformWidth = ((plateform.GetComponent<BoxCollider2D>().size.x) - 0.05f);
        Instantiate(plateform, transform.position, transform.rotation);
        counter = 1;
        addCentral = true;
    }

    // Update is called once per frame
    void Update()
    {
        addCentral = true;
        if (transform.position.x < genPoint.position.x)
        {
            float x = (counter == 0) ? transform.position.x + platformWidth + gap : transform.position.x + platformWidth;
            transform.position = new Vector3(x, plateform.transform.position.y, transform.position.z);
            if (useGaps)
                counter = (counter + 1) % gapCounter;
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
}
