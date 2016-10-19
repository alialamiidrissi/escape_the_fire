using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private bool updated;
    public float jumpForce;
    public float initHitCount;
    private Rigidbody2D rb;
    public LayerMask myLayer;
    public float val;
    public UIManager ui;
    private bool isOnGround, slide;
    public float timeElapsed;
    public const float limit = 1f;
    private Animator myAnimator;
    public GameManager theGameMangager;
    private float speedMilestoneCount;
    public float speedIncreaseMilestone;
    public Transform groundCheck;
    public float speedFactor;
    private float hitCount;
    public bool attack;
    public GameObject arrow;
    public GameObject gameOver;
    private bool doubleJump;
    private SpriteRenderer playerColor;
    Color start = new Color(1, 1, 1, 1);
    Color end = new Color(1, 120f / 255f, 120f / 255f, 1);
    public GameObject hitBar;
    public ScoreLPManager score;
    // Use this for initialization
    void Start()
    {
        //print(Screen.width + " " + Screen.height);
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        slide = false;
        speedMilestoneCount = speedIncreaseMilestone;
        hitCount = 0;
        doubleJump = false;
        playerColor = gameObject.GetComponent<SpriteRenderer>();
        timeElapsed = 1f;
        updated = false;

    }
    public float HitCount { get; private set; }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ui.pauseGame();
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, val, myLayer);
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        if (isOnGround)
            doubleJump = false;
        if (transform.position.y > 0.5)
            arrow.SetActive(true);
        else
            arrow.SetActive(false);

        ChangeColor();
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!slide)
            {
                if (isOnGround)
                {
                    rb.AddForce(transform.up * 8.5f, ForceMode2D.Impulse);
                    // rb.AddForce(transform.up * jumpForce);


                }
                else if (!doubleJump)
                {
                    rb.AddForce(transform.up * 3.5f, ForceMode2D.Impulse);
                    doubleJump = true;
                }
            }
        }
        slide = Input.GetKey(KeyCode.DownArrow);
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isOnGround)
        {
            rb.AddForce(transform.up * -50);
        }
        bool key = Input.GetKey(KeyCode.A);
        if(key)
            updated = updatehitCount();
        attack = Input.GetKey(KeyCode.A) && updated;
        UpdateCollider();
        myAnimator.SetBool("downPressed", Input.GetKeyDown(KeyCode.DownArrow));
        myAnimator.SetFloat("speed", rb.velocity.x);
        myAnimator.SetBool("onGround", isOnGround && isOnGround);
        myAnimator.SetBool("slide", slide);
        myAnimator.SetBool("attack", attack);
        myAnimator.SetBool("hitMode", hitCount>0);
        if (transform.position.x > speedMilestoneCount )
        {   if (score.Score < 380 && moveSpeed > 10.5)
                speedMilestoneCount = transform.position.x;
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedFactor;
            moveSpeed *= speedFactor;
        }

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "killBox")
        { //Catcher object at the bottom with Tag killBox
            string reason = null;
            if (coll.gameObject.name == "killLeft")
                reason = "You got caught by the fire !";
            else
                reason = "You fall into a ditch !";
            Utilities.pauseOrDie(gameObject, gameOver, reason);

        }
    }
    void UpdateCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().size = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().offset = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.center;
    }
    public void startHitCounter()
    {
        hitCount = initHitCount;
        hitBar.transform.localScale = new Vector3(5, hitBar.transform.localScale.y, transform.localScale.z);
        hitBar.transform.position = new Vector3(transform.position.x, hitBar.transform.position.y, hitBar.transform.position.z);
        hitBar.SetActive(true);
    }
    bool updatehitCount()
    {
        float count = hitCount - Time.deltaTime;
        if (count > 0)
        {
            hitCount = count;
            float d = Time.deltaTime * 5f / initHitCount;
            hitBar.transform.localScale = new Vector3(count* 5f / initHitCount, hitBar.transform.localScale.y, transform.localScale.z);
            hitBar.transform.localPosition = new Vector3(hitBar.transform.localPosition.x - d/2f, hitBar.transform.localPosition.y, hitBar.transform.localPosition.z);
            return true;
        }
        else
        {
            hitCount = 0;
            hitBar.SetActive(false);
            return false;
        }
    }
    private void ChangeColor()
    {
        if (timeElapsed < limit)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed < limit / 2)
            {
                float t = 2 * timeElapsed / (limit);
                playerColor.color = Color.Lerp(start, end, t);
            }
            else
            {

                float t = 2 * timeElapsed / limit - 1f;
                playerColor.color = Color.Lerp(end, start, t);
            }

        }

    }
}
