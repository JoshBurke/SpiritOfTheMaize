using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {


    private AudioSource jumpSound;
    private SimplePlatformController controller;
    private bool oneSoundPerJump; // guys, one play per jump, can't simply check the status of jumping

	// Use this for initialization
	void Start () {
        jumpSound = GetComponent<AudioSource>();
        controller = GetComponent<SimplePlatformController>();
        oneSoundPerJump = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (oneSoundPerJump)
        {
            if (!controller.isJumping())
                oneSoundPerJump = false;
        }
        else if (controller.isJumping())
        {
            jumpSound.PlayOneShot(jumpSound.clip);
            oneSoundPerJump = true;
        }
	}
}
