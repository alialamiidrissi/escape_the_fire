using UnityEngine;
using System.Collections;

public class FirePlaceHandler : MonoBehaviour
{

    private PlayerController player;
    public float malusPerSecond;
    private scoreLPManager lifePoints;
    // Use this for initialization
    void Start()
    {
        lifePoints = FindObjectOfType<scoreLPManager>();
        player = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<SpriteRenderer>().sprite.bounds.Intersects(player.gameObject.GetComponent<BoxCollider2D>().bounds))
            lifePoints.decreaseLifePoint(malusPerSecond * Time.deltaTime);

    }

}