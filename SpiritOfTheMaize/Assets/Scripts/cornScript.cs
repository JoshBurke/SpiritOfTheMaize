using UnityEngine;
using System.Collections;

public class cornScript : MonoBehaviour {

    private GameObject player;
	private EdgeCollider2D[] edges;
    private PickUpCorn playerCornScript;
    private BoxCollider2D playerCollider;
    private BoxCollider2D cornCollider;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
        playerCollider = player.GetComponent<BoxCollider2D>();
		edges = player.GetComponents<EdgeCollider2D> ();
        cornCollider = GetComponent<BoxCollider2D>();
        playerCornScript = player.GetComponent<PickUpCorn>();
	}
	
	// Update is called once per frame
	void Update () {
        if((player.transform.position - transform.position).magnitude < 3)
        {
            if(player.transform.position.y-1 > transform.position.y && !playerCornScript.cornHeld)
            {
                Physics2D.IgnoreCollision(cornCollider, playerCollider, false);
				Physics2D.IgnoreCollision (cornCollider, edges [0], false);
				Physics2D.IgnoreCollision (cornCollider, edges [1], false);
            }
            else
            {
                Physics2D.IgnoreCollision(cornCollider, playerCollider);
				Physics2D.IgnoreCollision (cornCollider, edges [0]);
				Physics2D.IgnoreCollision (cornCollider, edges [1]);
            }
        }

        if (playerCornScript.cornHeld && playerCornScript.cornName.Equals(name))
        {
            cornCollider.enabled = false;
        }
        else
        {
            cornCollider.enabled = true;
        }
	}
}
