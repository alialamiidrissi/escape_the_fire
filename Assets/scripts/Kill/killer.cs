using UnityEngine;
using System.Collections;

public class killer : MonoBehaviour {
    private CameraController cameraD;
    public float translate; 

	// Use this for initialization
	void Start () {
        cameraD = FindObjectOfType<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {    
        if (coll.gameObject.name == "player")
        {
            cameraD.shift += translate * Time.deltaTime;
            cameraD.transform.position = new Vector3(cameraD.transform.position.x + translate * Time.deltaTime, cameraD.transform.position.y, cameraD.transform.position.z);
        }

    }
}
