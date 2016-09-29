using UnityEngine;
using System.Collections;

public class PlayerdiijdycijsoyController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb;
    public LayerMask myLayer;
    private BoxCollider2D myCollider;
    private bool isOnGround, slide;
    private Animator myAnimator;
    public GameManager theGameMangager;

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

        isOnGround = Physics2D.IsTouchingLayers(myCollider, myLayer);
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
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "killBox")
        { //Catcher object at the bottom with Tag killBox
            theGameMangager.RestartGame();
        }
    }
    void UpdateCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().size = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().offset = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.center;
    }

}
