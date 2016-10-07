using UnityEngine;
using System.Collections;

public class CameraControllerAlt : MonoBehaviour
{
    private PlayerController player;
    public float shift;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(new Vector3((player.moveSpeed * Time.deltaTime), 0, 0));

    }
}
