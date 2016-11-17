using UnityEngine;
using System.Collections;

public class CornAttack : MonoBehaviour {
    private GameObject a;
    public int attack;//power of the corn;input needed.
    private float speed;//speed of the corn;
    private Vector2 start;
    private bool picked;//whether it is picked up.
    private bool pressed;//whether z is pressed.


	// Use this for initialization
	void Start () {
        a = gameObject;
        start = a.transform.position;
        picked = true;//!!!!!test!!!!!!!
        pressed = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Z))//press z to attack
        {
            pressed = true;
        }
        if (picked && pressed)
        {
            transform.position += new Vector3(10, 0) * Time.deltaTime;
        }
	
	}
}
