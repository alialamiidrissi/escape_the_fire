using UnityEngine;
using System.Collections;

public class CoinHandler : MonoBehaviour
{

    // Use this for initialization
    private ScoreLPManager score;
    private PlayerController player;
    void Start()
    {
        score = FindObjectOfType<ScoreLPManager>();
        player = FindObjectOfType<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D coll)

    {
        if (coll.gameObject.name == "player")
        {
            score.increaseScore(10);
            gameObject.SetActive(false);
        }
    }
}
