using UnityEngine;
using System.Collections;

public class PlayerTankController : MonoBehaviour {
    private Tank _tank;
	// Use this for initialization
	void Start ()
    {
	
	}

    private void Awake()
    {
        _tank = GetComponent<Tank>();
    }

	// Update is called once per frame
	void Update ()
    {
        float tankRotate = Input.GetAxis("Horizontal");
        float acceleration = Input.GetAxis("Vertical");

        _tank.Drive(acceleration);

	}
}
