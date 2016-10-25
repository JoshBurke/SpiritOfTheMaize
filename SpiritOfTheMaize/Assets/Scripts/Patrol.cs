using UnityEngine;
using System.Collections;

public class Patrol : MonoBehaviour {

	public GameObject patroller;
	private Vector2 start;
	public Vector2 end;
	private float deltaX;
	private float deltaY;
	private float lastX;
	private float lastY;
	public float speed = 2f;
	private Rigidbody2D rb2d;

	void Start () {
		patroller = gameObject;
		start = new Vector2(patroller.transform.position.x,patroller.transform.position.y);
		rb2d = GetComponent<Rigidbody2D>();
		deltaX = Mathf.Abs(end.x - start.x);
		deltaY = Mathf.Abs(end.y - start.y);
		lastX = patroller.transform.position.x;
		lastY = patroller.transform.position.y;
		start.Normalize();
		end.Normalize();
		rb2d.velocity = new Vector2 (end.x * speed, end.y * speed);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Mathf.Abs (patroller.transform.position.x - lastX) >= deltaX || Mathf.Abs (patroller.transform.position.y - lastY) >= deltaY) {
			rb2d.velocity = new Vector2 (-1 * rb2d.velocity.x, -1 * rb2d.velocity.y);
			lastX = patroller.transform.position.x;
			lastY = patroller.transform.position.y;
		}
	}
}
