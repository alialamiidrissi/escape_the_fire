using UnityEngine;
using System.Collections;

public class FireBlastHandler : MonoBehaviour {
    public float speed;
    private ScoreLPManager lifepoints;
	// Use this for initialization
	void Start () {
        lifepoints = FindObjectOfType<ScoreLPManager>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(speed, 0, 0));
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
       if( coll.gameObject.name == "player")
        {
            lifepoints.decreaseLifePoint(20);
            gameObject.SetActive(false);
        }

    }
}
