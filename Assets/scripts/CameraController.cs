using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public PlayerController player;

    private Vector3 lastpos;
    private float dx;
    public float shift;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        lastpos = player.transform.position;

	}
	
	// Update is called once per frame
	void Update () {

        dx = player.transform.position.x - lastpos.x;
        transform.position = new Vector3(transform.position.x + dx, transform.position.y, transform.position.z);
        lastpos = player.transform.position;

    }
}
