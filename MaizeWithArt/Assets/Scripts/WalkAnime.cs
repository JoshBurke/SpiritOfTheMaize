using UnityEngine;
using System.Collections;

public class WalkAnime : MonoBehaviour {
    public float Speed;
    public float Speed2;
    public bool Jumping;
    private Rigidbody2D rb2d;
    public Animator animator;
    // Use this for initialization
    void Start () {
        Speed = 0f;
        Speed2 = 0f;
        Jumping = false;
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        Speed = Mathf.Abs(rb2d.velocity.x);
        Speed2 = rb2d.velocity.y;
        if (Mathf.Abs(Speed2) > 0.5) { Jumping = true; }
        animator.SetFloat("Speed", Speed);
        animator.SetFloat("Speed2", Speed2);
        animator.SetBool("Jumping", Jumping);
    }
}
