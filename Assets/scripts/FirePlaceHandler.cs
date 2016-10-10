using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FirePlaceHandler : MonoBehaviour
{

    private PlayerController player;
    public float malusPerSecond;
    private ScoreLPManager lifePoints;
    private Image fireDanger;
    // Use this for initialization
    void Start()
    {
        lifePoints = FindObjectOfType<ScoreLPManager>();
        player = FindObjectOfType<PlayerController>();
        fireDanger = GameObject.Find("FireDanger").gameObject.GetComponent<Image>();

    }
    void Update()
    {
        float distance = transform.position.x - player.gameObject.transform.position.x;
        if (distance < -1.5f || distance > 15)
            fireDanger.enabled = (false);
        else
            fireDanger.enabled = true;

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "player")
        {
            lifePoints.decreaseLifePoint(malusPerSecond * Time.deltaTime);
            player.timeElapsed = player.timeElapsed >= PlayerController.limit ? 0 : player.timeElapsed;
            fireDanger.enabled = (true);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        fireDanger.enabled = (false);
    }

}