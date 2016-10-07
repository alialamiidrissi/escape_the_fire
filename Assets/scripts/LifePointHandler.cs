using UnityEngine;
using System.Collections;

public class LifePointHandler : MonoBehaviour {

    // Use this for initialization
    private ScoreLPManager lifePoints;
    void Start()
    {
        lifePoints = FindObjectOfType<ScoreLPManager>();
    }
    void OnTriggerEnter2D(Collider2D coll)

    {
        if (coll.gameObject.name == "player")
        {
            gameObject.SetActive(false);
            lifePoints.increaseLifePoints(10);
        }
    }
}
