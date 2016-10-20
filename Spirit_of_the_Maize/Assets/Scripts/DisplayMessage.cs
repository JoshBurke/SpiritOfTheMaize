using UnityEngine;
using System.Collections;

public class DisplayMessage : MonoBehaviour
{
	public bool showText = false;
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
	}

	IEnumerator OnTriggerEnter2D(Collider2D coll)
	{
		Vector3 p = c.WorldToScreenPoint(obj.transform.position);
		x = p.x;
		y = Screen.currentResolution.height - p.y - 200;
		showText = true;
		yield return new WaitForSeconds(time);
		showText = false;
	}

	void OnGUI ()
	{
		Rect textArea = new Rect(x,y,200,200);
		if (showText) {			
			GUI.Label (textArea, message);
		}
	}
}
