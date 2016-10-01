using UnityEngine;
using System.Collections;

public class CoinHandler : MonoBehaviour
{

    // Use this for initialization
    private ScoreLPManager score;
    void Start()
    {
        score = FindObjectOfType<ScoreLPManager>();
    }
    void OnTriggerEnter2D(Collider2D coll)

    {
        if (coll.gameObject.name == "player")
        {
            gameObject.SetActive(false);
            score.increaseScore(10);
        }
    }
}
