using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb;
    public LayerMask myLayer;
    public float val;
    private bool isOnGround, slide;
    private Animator myAnimator;
    public GameManager theGameMangager;
    private float speedMilestoneCount;
    public float speedIncreaseMilestone;
    public Transform groundCheck;
    public float speedFactor;
    private float hitCount;
    public bool attack;
    public GameObject arrow;

    public GameObject hitBar;
    // Use this for initialization
    void Start()
    {
        print(Screen.width + " " + Screen.height);
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        slide = false;
        speedMilestoneCount = speedIncreaseMilestone;
        hitCount = 0;
    }
    public float HitCount { get; private set; }
    // Update is called once per frame
    void Update()
    {

        isOnGround = Physics2D.OverlapCircle(groundCheck.position, val, myLayer);
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        if (transform.position.y > 0.5)
            arrow.SetActive(true);
        else
            arrow.SetActive(false);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isOnGround && !slide)
            {
                rb.AddForce(transform.up * 8.5f, ForceMode2D.Impulse);
               // rb.AddForce(transform.up * jumpForce);

            }
        }
        slide = Input.GetKey(KeyCode.DownArrow);
        if(Input.GetKeyDown(KeyCode.DownArrow) && !isOnGround)
        {
            rb.AddForce(transform.up * -50);
        }

        bool updated = updatehitCount();
        attack = Input.GetKey(KeyCode.A) && updated;
        UpdateCollider();
        myAnimator.SetFloat("speed", rb.velocity.x);
        myAnimator.SetBool("onGround", isOnGround && isOnGround);
        myAnimator.SetBool("slide", slide);
        myAnimator.SetBool("attack", attack);
        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedFactor;
            moveSpeed *= speedFactor;
        }

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "killBox")
        { //Catcher object at the bottom with Tag killBox

            SceneManager.LoadScene(0);
        }
    }
    void UpdateCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().size = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().offset = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.center;
    }
    public void startHitCounter()
    {
        hitCount = 5;
        hitBar.transform.localScale = new Vector3(5, hitBar.transform.localScale.y, transform.localScale.z);
        hitBar.transform.position = new Vector3(transform.position.x,hitBar.transform.position.y,hitBar.transform.position.z);
        hitBar.SetActive(true);
    }
    bool updatehitCount()
    {
        float count = hitCount - Time.deltaTime;
       if (count > 0)
        {
            hitCount = count;
            hitBar.transform.localScale = new Vector3(count, hitBar.transform.localScale.y, transform.localScale.z);
            hitBar.transform.localPosition = new Vector3(hitBar.transform.localPosition.x-Time.deltaTime / 2f, hitBar.transform.localPosition.y, hitBar.transform.localPosition.z);
            return true;
        }
       else
        {
            hitCount = 0;
            hitBar.SetActive(false);
            return false;
        }
    }

}
