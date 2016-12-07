using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    [HideInInspector]public bool facingRight = true;

    Animator anim;
    private Rigidbody2D rb2d;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (rb2d.velocity.Equals(new Vector2(0, 0)))
            anim.SetInteger("State", 1);
        else if (rb2d.gameObject.GetComponent<SimplePlatformController>().isFalling()==true)
            anim.SetInteger("State", 4);
        else 
            anim.SetInteger("State", 2);
    }
}
