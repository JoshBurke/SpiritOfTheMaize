using UnityEngine;
using System.Collections;

public class Pick : MonoBehaviour {
    public bool picked;
    private GameObject a;
    private GameObject b;
    public int error;

	// Use this for initialization
	void Start () {
        picked = false;
        a = gameObject;
        SimplePlatformController otherScript = GetComponent<SimplePlatformController>();
        b = otherScript.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        //press x to pick up;
        if ((Mathf.Abs(b.transform.position.x - a.transform.position.x) < error)&& (Input.GetKey(KeyCode.X)))
        {
            picked = true;
        }
        if (picked)
        {
            a.transform.position = b.transform.position;//move with the player
        }
    }
}
