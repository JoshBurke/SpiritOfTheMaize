using UnityEngine;
using System.Collections;


public class Respawn : MonoBehaviour {

    public Vector2 spawnPoint;
    public int deathCounter = 0;

    void OnTriggerEnter2D(Collider2D coll)
    {
        coll.gameObject.transform.position = spawnPoint; //resets position
        coll.gameObject.transform.localRotation = Quaternion.identity; //resets rotation
                                                                       //in case it was rotating for some strange reason, lock your damn z rotation in your rigidbody
        deathCounter++; 
    }
}
