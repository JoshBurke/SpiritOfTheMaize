using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {

	public Vector2 startingPos = new Vector2(0,0);
    //to use, make an object with a Collider2D, make it a trigger, and attach this script
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name.Equals("player")) {
            GameObject.Find("CheckPoint Handler").GetComponent<checkpointHandler>().respawn();
        }
		
	}
}
