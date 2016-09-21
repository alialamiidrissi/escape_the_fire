using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {

    public ObjectPool coins_pool;
    private int nbCoins;
    // Use this for initialization
    void Start () {
        nbCoins = Random.Range(1, 3);
	}
	
	public void createCoins(Vector3 positionT,bool addCentral)
    {
        createCoin(new Vector3(positionT.x - 1.5f, positionT.y + 1f, positionT.z));
        if (nbCoins >= 2 && addCentral)
            createCoin(new Vector3(positionT.x, positionT.y + 1f, positionT.z));
        if (nbCoins == 3)
            createCoin(new Vector3(positionT.x + 1.5f, positionT.y + 1f, positionT.z));
        nbCoins= Random.Range(1, 3);
    }

    private void createCoin(Vector3 pos)
    {
        GameObject coin1 = coins_pool.getObject();
        coin1.transform.position = pos;
        coins_pool.enableObject(coin1);
    }
}
