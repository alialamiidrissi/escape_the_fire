using UnityEngine;
using System.Collections;

public class PowerUpHandler : MonoBehaviour
{
    // Use this for initialization
    private CameraController cameraD;
    void Start()
    {
        cameraD = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D coll)

    {
        if (coll.gameObject.name == "player")
        {
            gameObject.SetActive(false);
            cameraD.shiftRight(2.5f);
        }
    }
}
