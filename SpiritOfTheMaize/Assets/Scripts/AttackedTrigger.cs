using UnityEngine;
using System.Collections;

public class AttackedTrigger : MonoBehaviour {
    public static bool dead = false;
    public static bool destroy = true;

    //to use, make an object with a Collider2D, make it a trigger, and attach this script

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name.Contains("corn"))
        {
            Destroy(coll.gameObject); //destroy bullet
            Destroy(gameObject);//death
        }
    }
}
