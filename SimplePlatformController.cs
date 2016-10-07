using UnityEngine;
using System.Collections;

//A quick rundown of how to use this
//First create an object, doesn't especially matter what
//add a RigidBody2D, a BoxCollider2D, an Animator, and this script
//also add a child camera and a child empty object called specifically "groundCheck"
//Also make sure everything is on layer 'player'
//For the animator, set controller to 'character', 
//update mode to 'animate physics', and culling mode to 'cull update transforms'
//As for the camera, make sure it's Z-cordinate is negative so it's far back enough to actually observe your object
//groundCheck should be positioned below the object proper, it needs to be IN the ground while the object is on it
//Now create some ground to stand on, this works with anything but I suggest you start with a cube
//change the proportions to make a long and thing rectangle to serve as ground
//change it's layer to ground and add a BoxCollider2D


public class SimplePlatformController : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = true;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;

    public bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;

    
    // Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        groundCheck = GameObject.Find("groundCheck").transform;
	}
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if ((Input.GetKeyDown(KeyCode.Space) && grounded))
            jump = true;

	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
