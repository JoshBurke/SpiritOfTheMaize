using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

	//don't forgot to add a rigidbody2d to the patroller

	private GameObject patroller; //holds the object doing the patrolling

	private Vector2 start;
	public Vector2 end;

	public float speed; //speed, self explanatory

	private float deltaX; //xy distances from start to end
	private float deltaY;

	private float lastX; //hold the xy of either start or end, whichever was visited last
	private float lastY;

	private Rigidbody2D rb2d;

	void Start () {
		patroller = gameObject; //patroller = the object this script is attached to
		start = new Vector2(patroller.transform.position.x,patroller.transform.position.y); //start is patroller's current position
		rb2d = GetComponent<Rigidbody2D>();
		deltaX = Mathf.Abs(end.x - start.x);
		deltaY = Mathf.Abs(end.y - start.y);
		lastX = patroller.transform.position.x;
		lastY = patroller.transform.position.y;
		start.Normalize(); //super secret tech, convets a vector2D to have magnitude 1, but keep it's proportions
		end.Normalize(); //so it can be used to direct but not effect the speed
		rb2d.velocity = new Vector2 (end.x * speed, end.y * speed);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Mathf.Abs (patroller.transform.position.x - lastX) >= deltaX || Mathf.Abs (patroller.transform.position.y - lastY) >= deltaY) {
			rb2d.velocity = new Vector2 (-1 * rb2d.velocity.x, -1 * rb2d.velocity.y); //reverses direction

			lastX = patroller.transform.position.x;
			lastY = patroller.transform.position.y;
		}
	}
}
