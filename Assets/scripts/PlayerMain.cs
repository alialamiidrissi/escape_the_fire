using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour {
    private Animator myAnim;
    public GameObject tutorial;
    private float startTime;
    public GameObject hitBar;
    public bool startwaitCount;
    public float waitCount;
    private float hitCount;
    private bool hitActive;
	// Use this for initialization
	void Start () {
        myAnim = GetComponent<Animator>();
        startTime = Time.time-30;
        hitCount = 2;
        startwaitCount = false;
        waitCount = 2.5f;
        hitActive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (myAnim.enabled)
        {   if(Input.GetKey(KeyCode.A))
                hitActive = updatehitCount();
            if(!hitActive && !startwaitCount)
            {
                startwaitCount = true;
                waitCount = 2.5f;
            }
            float tmp = waitCount - Time.deltaTime;
            waitCount = tmp > 0 ? tmp : 0;
            if (!hitActive && waitCount <= 0)
            {
                startHitCounter();
                startwaitCount = false;
            }
            float diff = Time.time - startTime;
            if (Input.GetKeyDown(KeyCode.UpArrow))
                startTime = Time.time;
            if (Input.GetKeyDown(KeyCode.DownArrow) && diff < 1.75)
                startTime = Time.time - 1.75f;
            bool jump = diff < 2;
            myAnim.SetBool("onGround", !jump );
            myAnim.SetBool("slide", Input.GetKey(KeyCode.DownArrow)&& !jump);
            myAnim.SetBool("attack", Input.GetKey(KeyCode.A)&& hitActive);
            myAnim.SetFloat("speed", 100);
            myAnim.SetBool("hitMode", hitCount > 0);
        }

	}
   public void startTutorial()
    {
        myAnim.enabled = true;
        tutorial.SetActive(true);
        hitBar.SetActive(true);
    }
    public void startHitCounter()
    {
        hitCount = 2;
        hitBar.transform.localScale = new Vector3(6, hitBar.transform.localScale.y, transform.localScale.z);
        hitActive = true;
        hitBar.transform.position = new Vector3(transform.position.x, hitBar.transform.position.y, hitBar.transform.position.z);
        hitBar.SetActive(true);
    }
    bool updatehitCount()
    {
        float count = hitCount - Time.deltaTime;
        if (count > 0)
        {
            hitCount = count;
            hitBar.transform.localScale = new Vector3(count * (6f / 2f), hitBar.transform.localScale.y, transform.localScale.z);
            hitBar.transform.localPosition = new Vector3(hitBar.transform.localPosition.x - Time.deltaTime*(6f/2f)/2f, hitBar.transform.localPosition.y, hitBar.transform.localPosition.z);
            return true;
        }
        else
        {
            hitCount = 0;
            hitBar.SetActive(false);
            hitActive = false;
            return false;
        }
    }
}
