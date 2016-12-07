using UnityEngine;
using System.Collections;

public class PickUpCorn : MonoBehaviour {

    private GameObject[] corn;
    private Transform cornTransform;
    private Vector2 distanceToClosestCorn;
    private GameObject cornToPickUp;
    public string cornName;
    private Rigidbody2D cornBody;
    public bool cornHeld = false;
    private float timeLastHeld = 0;
    private float coolDown = 0.5F; //This is the cooldown time in seconds between being able to pick up a thrown kernel.

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && Time.time - timeLastHeld > coolDown)
        {
            distanceToClosestCorn = new Vector2(3, 3);
            corn = GameObject.FindGameObjectsWithTag("corn");
            foreach (GameObject kernel in corn)
            {
                cornTransform = kernel.GetComponent<Transform>();
                if ((transform.position - cornTransform.position).magnitude < 3 && (transform.position - cornTransform.position).magnitude < distanceToClosestCorn.magnitude)
                {
                    cornToPickUp = kernel;
                    distanceToClosestCorn = (transform.position - cornTransform.position);
                }
            }
			if(distanceToClosestCorn.magnitude < 3){
            cornToPickUp.transform.position = transform.position;
            cornBody = cornToPickUp.GetComponent<Rigidbody2D>();
            cornName = cornToPickUp.name;
				cornHeld = true;}
        }
	}

     void FixedUpdate()
    {
        if (cornHeld)
        {
            cornToPickUp.transform.position = transform.position;
            cornBody.Sleep();
            timeLastHeld = Time.time;
        }
        //else
        //{
        //    cornBody.WakeUp();
        //}
        if (Input.GetButtonDown("Fire1") && cornHeld)
        {
            //cornBody.AddForce(Vector2.right*10);
            cornHeld = false;
        }
    }
}
