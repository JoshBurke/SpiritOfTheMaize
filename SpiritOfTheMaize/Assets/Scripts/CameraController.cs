using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	private GameObject player; //will hold the player object 
    private Vector3 offset; //stores the offset distance between the player and camera

    // Use this for initialization
	void Start()
    {
		player = GameObject.Find ("player"); //finds and stores the object named specifically "player"

		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }

}