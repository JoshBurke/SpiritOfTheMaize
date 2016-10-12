using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D coll)
    {
        coll.gameObject.transform.position = new Vector2(0, 1);
        coll.gameObject.transform.localRotation = Quaternion.identity;
    }

}
