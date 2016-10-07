using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireBlastHandler : MonoBehaviour
{
    public float speed;
    private ScoreLPManager lifepoints;
    private PlayerController player;
    private Image fireDanger;
    // Use this for initialization
    void Start()
    {
        lifepoints = FindObjectOfType<ScoreLPManager>();
        player = FindObjectOfType<PlayerController>();
        fireDanger = GameObject.Find("FireBlastDanger").gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        print(UIManager.paused);
        if (!UIManager.paused)
            transform.Translate(new Vector3(speed, 0, 0));
        float distance = transform.position.x - player.gameObject.transform.position.x;
        if (distance < -1.5f || distance > 20)
            fireDanger.enabled = (false);
        else
            fireDanger.enabled = true;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "player")
        {
            lifepoints.decreaseLifePoint(20);
            //player.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400f));
            gameObject.SetActive(false);


        }

    }
}
