using UnityEngine;
using System.Collections;

public class AttackHandler : MonoBehaviour {

    private PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D coll)

    {
        if (coll.gameObject.name == "player")
        {
            player.startHitCounter();
            gameObject.SetActive(false);
        }
    }
}
