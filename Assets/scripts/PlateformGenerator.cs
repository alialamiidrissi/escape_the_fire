using UnityEngine;
using System.Collections;

public class PlateformGenerator : MonoBehaviour {
    public GameObject plateform;
    public Transform genPoint;
    private float platformWidth;
    public ObjectPool plateform_pool;
    // Use this for initialization
    public float gap;
	void Start () {
        platformWidth = plateform.GetComponent<BoxCollider2D>().size.x*3;
        Instantiate(plateform, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x < genPoint.position.x){
            float x = transform.position.x + platformWidth + gap;
            transform.position = new Vector3(x,plateform.transform.position.y, transform.position.z);
            if (plateform_pool == null)
                print("fault");
            GameObject obj = plateform_pool.getObject();
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);
        }
    }
}
