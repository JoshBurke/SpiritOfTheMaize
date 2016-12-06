using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {

	public float windForce; //how hard wind blows, must be set
	public Vector2 windDirection; //what direction the wind blows, must be set
    public bool noGliding;


	// Use this for initialization
	void Start () {
		windDirection.Normalize(); //converts vector magnitude to 1, keeps direction but not length basically;
	}

	void OnTriggerStay2D(Collider2D coll) {
        if (noGliding)
        {
            if(coll.gameObject.name.Equals("player"))
                coll.attachedRigidbody.AddForce(windForce * windDirection);
        }
		else if (coll.gameObject.name.Equals ("player")&&coll.gameObject.GetComponent<SimplePlatformController>().isGliding()==true) {
			coll.attachedRigidbody.AddForce (windForce * windDirection);
		}
	}
}
