using UnityEngine;
using System.Collections;
using System;

public class CoinGenerator : MonoBehaviour
{

    /*public ObjectPool coins_pool;
    public ObjectPool life_points;
    */
    public static bool generateHit=false;
    public ObjectPool[] coinObjectPools;
    public float[] coinProbabiltydistribution;
    private float[] initialProbabilityDistribution;
    public CameraController cam;
    public PlayerController player;
    public ScoreLPManager scoreLife;
    private bool decreasedHealth, decreasedSpeedUp;
    private int nbCoins;
    //public int lifePointsprobability;
    // Use this for initialization
    void Start()
    {
        nbCoins = UnityEngine.Random.Range(1, 3);
        initialProbabilityDistribution = new float[coinProbabiltydistribution.Length];
      Array.Copy(coinProbabiltydistribution,initialProbabilityDistribution,coinProbabiltydistribution.Length);
        decreasedHealth = false;
        decreasedSpeedUp = false;
    }

    void Update()
    {
        print(scoreLife.LifePoints);
        if (scoreLife.LifePoints < 40)
        {
            if (!decreasedHealth)
            {
                coinProbabiltydistribution[1] += 6;
                coinProbabiltydistribution[0] -= 6;
                decreasedHealth = true;
            }
        }
        else
        {
            if (decreasedHealth)
            {
                coinProbabiltydistribution[0] += (initialProbabilityDistribution[1] - coinProbabiltydistribution[1]);
                decreasedHealth = false;
            }
            coinProbabiltydistribution[1] = initialProbabilityDistribution[1];
        }
        if (cam.shift > 1.5)
        {   if (!decreasedSpeedUp)
            {
                coinProbabiltydistribution[2] += 6;
                coinProbabiltydistribution[0] -= 6;
                decreasedSpeedUp = true;
            }
        }
        else
        {
            if (decreasedSpeedUp)
            {
                coinProbabiltydistribution[0] += (initialProbabilityDistribution[2] - coinProbabiltydistribution[2]);
                decreasedSpeedUp = false;
            }
            coinProbabiltydistribution[2] = initialProbabilityDistribution[2];
        }
    }
    public void createCoins(Vector3 positionT, bool addCentral)
    {
        createCoin(new Vector3(positionT.x - 1.5f*0.6f, positionT.y, positionT.z));
        if (nbCoins >= 2 && addCentral)
            createCoin(new Vector3(positionT.x, positionT.y, positionT.z));
        if (nbCoins == 3)
            createCoin(new Vector3(positionT.x + 1.5f*0.6f, positionT.y, positionT.z));
        nbCoins = UnityEngine.Random.Range(1, 3);
    }

    private void createCoin(Vector3 pos)
    {
        int toChoose = Utilities.choose(coinProbabiltydistribution);
        /*if ( (toChoose == 2 && cam.shift < 0.1) || (toChoose == 3 && player.HitCount < 3) )
            toChoose = 0;
            */
        GameObject coin1 = coinObjectPools[toChoose].getObject();
        coin1.transform.position= new Vector3(pos.x,coin1.transform.position.y,pos.z);
        coin1.SetActive(true);
    }
}
