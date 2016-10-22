using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {

    //to use, make an object with a boxCollider2D, make it a trigger, and attach this script

    void OnTriggerEnter2D(Collider2D coll)
    {
        coll.gameObject.transform.position = new Vector2(-15, 0); //resets position
        coll.gameObject.transform.localRotation = Quaternion.identity; //resets rotation
    }

}
