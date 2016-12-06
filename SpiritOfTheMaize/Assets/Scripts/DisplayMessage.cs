using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayMessage : MonoBehaviour
{
	private bool showText = false;
	//private bool keyPressed = false;
	private bool timerEnabled = false;
	public float time;
	public Text t;
	private float timeCount = 0;

	// Use this for initialization
	void Start()
	{
		t.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (showText)
		{
			t.enabled = true;
			timerEnabled = true;
		}
		if (timerEnabled)
		{
			timeCount += Time.deltaTime;
		}
		if (timeCount > time)
		{
			//keyPressed = false;
			t.enabled = false;
			timerEnabled = false;
			timeCount = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		showText = true;
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		showText = false;
	}
}