using UnityEngine;
using System.Collections;
/**
 * to use, attach this file to the scene changing object
 */
public class ChangeScene : MonoBehaviour {
	public string nextLevel;
    void OnTriggerEnter2D(Collider2D coll)
    {
        // if the collider is touched by player
        if (coll.gameObject.name.Equals("player"))
        {
            // load scene 2
            Application.LoadLevel(nextLevel);
        }

    }
}
