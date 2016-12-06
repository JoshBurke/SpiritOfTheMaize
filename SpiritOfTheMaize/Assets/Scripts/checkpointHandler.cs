using UnityEngine;
using System.Collections;

public class checkpointHandler : MonoBehaviour {

     public GameObject player;
     public GameObject spawn;

    int index; // Number of checkpoints

    public enum Mode //Determines whether the checkpoint is locked or not
    {
        Regular, Locked, Ordered
    }
    public Mode mode;

    public GameObject[] checkpoints;

    
    // Use this for initialization
	void Start () {
        if (mode != Mode.Ordered)
            checkpoints = GameObject.FindGameObjectsWithTag("checkpoint");
        else
            Debug.LogWarning("Make Sure you filled the checkpoint array in the correct order");
        spawn = GameObject.Find("Spawn Point");
        player = GameObject.Find("player");
	}

    // update check points
    public void updateCheckpoints(GameObject currentCheck) { //Is called everytime a checkpoint is entered
        if (mode == Mode.Regular) {
            foreach (GameObject cp in checkpoints)
            {

                if (cp.GetComponent<Checkpoint>().status != Checkpoint.state.Inactive)
                {
                    cp.GetComponent<Checkpoint>().status = Checkpoint.state.Used;
                }
            }
            currentCheck.GetComponent<Checkpoint>().status = Checkpoint.state.Active;

        }

        else if (mode == Mode.Locked && currentCheck.GetComponent<Checkpoint>().status != Checkpoint.state.Locked) //Makes a game with checkpoints that can only be used once
        {
            foreach (GameObject cp in checkpoints)
            {

                if (cp != currentCheck &&  cp.GetComponent<Checkpoint>().status != Checkpoint.state.Inactive)
                {
                    cp.GetComponent<Checkpoint>().status = Checkpoint.state.Locked;
                }
            }

            currentCheck.GetComponent<Checkpoint>().status = Checkpoint.state.Active;
        }

        else if (mode == Mode.Ordered && index<checkpoints.Length && currentCheck == checkpoints[index])//For a game with ordered checkpoints
        {

            foreach (GameObject cp in checkpoints)
            {
                if (cp.GetComponent<Checkpoint>().status != Checkpoint.state.Inactive)
                {
                    cp.GetComponent<Checkpoint>().status = Checkpoint.state.Locked;
                }
            }

            currentCheck.GetComponent<Checkpoint>().status = Checkpoint.state.Active;
            index++; //Increases the index of the ordered checkpoints each time.
                     //The point of an ordered checkpoint system is to
                     //Force the player to go through locked checkpoints
                     //In a specific order
        }


    }

     public void respawn()
    {
        foreach (GameObject cp in checkpoints)
            {
                if (cp.GetComponent<Checkpoint>().status == Checkpoint.state.Active)
                {
                    player.transform.position = cp.transform.position;
                    return;
                }
            }
        player.transform.position = spawn.transform.position;
    }
}
