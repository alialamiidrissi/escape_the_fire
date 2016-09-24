using UnityEngine;
using System.Collections;

public class CoinHandler : MonoBehaviour
{

    // Use this for initialization
    private scoreLPManager score;
    void Start()
    {
        score = FindObjectOfType<scoreLPManager>();
    }
    void OnCollisionEnter2D(Collision2D coll)

    {
       /* if (score == null)
            print("l9wada");
            */
        if (coll.gameObject.name == "player")
        {
            gameObject.SetActive(false);
            score.increaseScore(10);
        }
    }
}
