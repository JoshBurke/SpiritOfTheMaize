using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {


    private AudioSource jumpSound;
    private SimplePlatformController controller;

	// Use this for initialization
	void Start () {
        jumpSound = GetComponent<AudioSource>();
        controller = GetComponent<SimplePlatformController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (controller.isJumping())
        {
            jumpSound.PlayOneShot(jumpSound.clip);
        }
	}
}
