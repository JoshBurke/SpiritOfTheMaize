using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {

	//this is a placeholder for when we had pickups of some sort later
	//also for fun
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
	}
}
