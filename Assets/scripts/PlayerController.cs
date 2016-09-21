using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb;
    public LayerMask myLayer;
    private BoxCollider2D myCollider;
    private bool isOnGround, slide,jump;
    private Animator myAnimator;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        slide = false;
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        isOnGround = Physics2D.IsTouchingLayers(myCollider, myLayer);
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        print(isOnGround);
        if (isOnGround)
            jump = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround && !slide)
            {
                rb.AddForce(transform.up * jumpForce);
                jump = true;
            }
        }
        slide = Input.GetKey(KeyCode.V);
          UpdateCollider(-1f);
        print("jump: " + jump);
        myAnimator.SetFloat("speed",rb.velocity.x);
        myAnimator.SetBool("onGround", isOnGround);
        myAnimator.SetBool("slide",slide);

    }
    void OnCollisionEnter2D(Collision2D coll)
    {

    }
    void UpdateCollider(float add)
    {
        gameObject.GetComponent<BoxCollider2D>().size = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        // gameObject.GetComponent<BoxCollider2D>().size = new Vector2(gameObject.GetComponent<BoxCollider2D>().size.x, gameObject.GetComponent<BoxCollider2D>().size.x + add);
        gameObject.GetComponent<BoxCollider2D>().offset= gameObject.GetComponent<SpriteRenderer>().sprite.bounds.center;
    }

}
