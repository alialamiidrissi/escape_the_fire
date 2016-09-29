using UnityEngine;
using System.Collections;

public class FirePlaceHandler : MonoBehaviour
{

    private PlayerController player;
    public float malusPerSecond;
    private ScoreLPManager lifePoints;
    // Use this for initialization
    void Start()
    {
        lifePoints = FindObjectOfType<ScoreLPManager>();
        player = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (gameObject.GetComponent<SpriteRenderer>().sprite.bounds.Intersects(player.gameObject.GetComponent<BoxCollider2D>().bounds))
          //  lifePoints.decreaseLifePoint(malusPerSecond * Time.deltaTime);

    }
    void OnTriggerEnter2D()
    {
        lifePoints.decreaseLifePoint(malusPerSecond * Time.deltaTime);
    }
}