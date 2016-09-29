using UnityEngine;
using System.Collections;

public class killer : MonoBehaviour {
    private CameraController camera;
    public float translate; 

	// Use this for initialization
	void Start () {
        camera = FindObjectOfType<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        //if (collider.gameObject.name == "player"){
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collider.bounds.center;

            bool left = contactPoint.x < center.x;
            bool top = contactPoint.y > center.y;

           // if(!top && left){
            print("in");
                camera.shift += translate * Time.deltaTime;
                camera.transform.position = new Vector3(camera.transform.position.x + translate * Time.deltaTime, camera.transform.position.y, camera.transform.position.z);
            //}
        //}
    }
}
