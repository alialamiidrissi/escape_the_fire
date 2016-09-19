using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb;
    public LayerMask myLayer;
    private BoxCollider2D myCollider;
    private bool isOnGround;
    private Animator myAnimator;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.IsTouchingLayers(myCollider, myLayer);
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                rb.AddForce(transform.up * jumpForce);
            }
        }
        myAnimator.SetFloat("speed",rb.velocity.x);
        myAnimator.SetBool("onGround", isOnGround);

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        print(coll.gameObject.name);

    }

}
