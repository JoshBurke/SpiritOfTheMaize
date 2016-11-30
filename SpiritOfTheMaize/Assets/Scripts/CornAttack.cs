using UnityEngine;
using System.Collections;

public class CornAttack : MonoBehaviour {
    private GameObject a;
    private Vector2 start;
    private bool picked;//whether it is picked up.
    private bool pressed;//whether z is pressed.
    public int velocity;
    private bool right;


	// Use this for initialization
	void Start () {
        Pick otherScript = GetComponent<Pick>();
        SimplePlatformController otherScript2 = GetComponent<SimplePlatformController>();
        picked = otherScript.picked;
        right = otherScript2.facingRight;
        a = gameObject;
        start = a.transform.position;
        pressed = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Z))//press z to attack
        {
            pressed = true;
        }
        if (picked && pressed&&right)
        {
            transform.position += new Vector3(velocity, 0) * Time.deltaTime;
        }
        if (picked && pressed && !right)
        {
            transform.position += new Vector3(-velocity, 0) * Time.deltaTime;
        }

    }
}
