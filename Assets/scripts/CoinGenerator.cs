using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour
{

    /*public ObjectPool coins_pool;
    public ObjectPool life_points;
    */
    public ObjectPool[] coinObjectPools;
    public float[] coinProbabiltydistribution;
    private int nbCoins;
    //public int lifePointsprobability;
    // Use this for initialization
    void Start()
    {
        nbCoins = Random.Range(1, 3);
    }


    public void createCoins(Vector3 positionT, bool addCentral)
    {
        print("enter");
        createCoin(new Vector3(positionT.x - 1.5f, positionT.y + 1f, positionT.z));
        if (nbCoins >= 2 && addCentral)
            createCoin(new Vector3(positionT.x, positionT.y + 1f, positionT.z));
        if (nbCoins == 3)
            createCoin(new Vector3(positionT.x + 1.5f, positionT.y + 1f, positionT.z));
        nbCoins = Random.Range(1, 3);
    }

    private void createCoin(Vector3 pos)
    {
        GameObject coin1 = coinObjectPools[Utilities.choose(coinProbabiltydistribution)].getObject();
        coin1.transform.position = pos;
        coin1.SetActive(true);
    }
}
