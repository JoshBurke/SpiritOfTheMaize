using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

	private GameObject patroller; //holds the object doing the patrolling

	public bool returnTrip; //whether or not the patroller returns along it's original path or resets after moving along it's path, must be input

	private Vector2 start; //starting location, ripped from patroller's location in Unity
	public Vector2 end; //change in xy position from starting location, must be input

	private Vector2 patrolVelocity; //holds the patroller's current velocity
	public float speed; //speed, self explanatory, must be input

	private float deltaX; //xy distances from start to end
	private float deltaY;

	private float lastX; //hold the xy of either start or end, whichever was visited last
	private float lastY;

	private Rigidbody2D rb2d; //don't forgot to add a rigidbody2d to the patroller for this

	void Start () {
            patroller = gameObject; //patroller = the object this script is attached to
            rb2d = GetComponent<Rigidbody2D>();

            start = new Vector2(patroller.transform.position.x, patroller.transform.position.y); //start is patroller's current position

            deltaX = Mathf.Abs(end.x);
            deltaY = Mathf.Abs(end.y);

            lastX = patroller.transform.position.x;
            lastY = patroller.transform.position.y;

            end.Normalize(); // normalize the end vector

            patrolVelocity = new Vector2(end.x * speed, end.y * speed);
            rb2d.velocity = patrolVelocity;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Mathf.Abs(patroller.transform.position.x - lastX) >= deltaX && Mathf.Abs(patroller.transform.position.y - lastY) >= deltaY) {
			rb2d.velocity = new Vector2 (0f, 0f); 
			if (returnTrip) {
				patrolVelocity = new Vector2 (-1 * patrolVelocity.x, -1 * patrolVelocity.y); //reverses direction
				rb2d.velocity = patrolVelocity; //applies the reversal
				lastX = patroller.transform.position.x;
				lastY = patroller.transform.position.y;
			} else {
				patroller.transform.position = new Vector2 (lastX, lastY); //resets position
				rb2d.velocity = new Vector2 (end.x * speed, end.y * speed); //original velocity
			}
		}
		
	}
}
