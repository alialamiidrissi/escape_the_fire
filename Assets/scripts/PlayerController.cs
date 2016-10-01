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
    private BoxCollider2D myCollider;
    private bool isOnGround, slide;
    private Animator myAnimator;
    public GameManager theGameMangager;
    public Transform groundCheck;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        slide = false;
    }

    // Update is called once per frame
    void Update()
    {

        isOnGround = Physics2D.OverlapCircle(groundCheck.position, val, myLayer);
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround && !slide)
            {
                rb.AddForce(transform.up * jumpForce);

            }
        }
        slide = Input.GetKey(KeyCode.V);
        UpdateCollider();
        myAnimator.SetFloat("speed", rb.velocity.x);
        myAnimator.SetBool("onGround", isOnGround);
        myAnimator.SetBool("slide", slide);

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

}
