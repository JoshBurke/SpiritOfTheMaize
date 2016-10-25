using UnityEngine;
using System.Collections;

public class DisplayMessage : MonoBehaviour
{
	private bool showText = false;
	private bool keyPressed = false;
	public GameObject obj;
	public Camera c;
	private float x, y;
	public string message;
	public float time;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.E) && showText) {
			keyPressed = true;
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			keyPressed = false;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		Vector3 p = c.WorldToScreenPoint (obj.transform.position);
		x = p.x;
		y = Screen.currentResolution.height - p.y - 200;
		showText = true;
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		showText = false;
		keyPressed = false;
	}

	void OnGUI ()
	{
		Rect textArea = new Rect(x,y,200,200);
		if (showText && keyPressed) {
			GUI.Label (textArea, message);
		}
	}
}
