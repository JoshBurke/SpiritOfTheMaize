﻿using UnityEngine;
using System.Collections;

public class SimplePlatformController : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false; //set to true to make the player jump

    public float moveForce = 365f; //how fast the player accelerates
    public float maxSpeed = 5f; //how fast player can move
    public float jumpForce = 750f; //how high player can jump
    private Transform groundCheck; //you must have a child transform to the gameObject 
	//named specifically groundCheck that is positioned slightly below the object's boxCollider
	Animator anim;
    public bool grounded = false;
    private Rigidbody2D rb2d;

    
    // Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
		groundCheck = transform.Find ("groundCheck");
	}
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        //sees if any part of a line between the player and groundCheck is on the ground layer

		anim.SetInteger ("State", 1);

		if (Mathf.Abs (rb2d.velocity.x) > 0) {
			anim.SetInteger ("State", 2);
		}

		if (!grounded) {
			anim.SetInteger ("State", 4);
		}
			
        if ((Input.GetKeyDown(KeyCode.Space) && grounded))
            jump = true;

	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce); //actually moves the player

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y); //caps player speed

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
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

    public void Reset()
    {
        gameObject.transform.position = new Vector2(0, 1);
    }

    /**
     * This method is for use in the PlayerSounds script
     * -Josh
     **/
    public bool isJumping()
    {
        if (jump) return true;
        else return false;
    }
}
