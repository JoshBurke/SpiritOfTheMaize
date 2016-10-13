using UnityEngine;
using System.Collections;

public class DisplayMessage : MonoBehaviour
{
	public bool showText = false;
	public Rect textArea = new Rect (0, 0, Screen.width, Screen.height);
	public string message;
	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.E)) {
			showText = !showText;
		}
	}

	void OnGUI ()
	{
		GUIStyle center = GUI.skin.GetStyle ("Label");
		center.alignment = TextAnchor.MiddleCenter;
		if (showText) {			
			GUI.Label (textArea, message, center);
		}
	}
}
