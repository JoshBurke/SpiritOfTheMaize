using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public enum state { Active, Inactive, Used, Locked };

    public state status;

    public checkpointHandler ch;

    public Sprite[] sprites;

    void Start()
    {
        ch = GameObject.Find("CheckPoint Handler").GetComponent<checkpointHandler>();
    }
    void Update()
    {
        changeLook();
    }

    //This updates how the checkpoint looks depending on its status.
    void changeLook()
    {   
        if(status == state.Inactive)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (status == state.Active)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if (status == state.Used)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (status == state.Locked)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            ch.updateCheckpoints(this.gameObject);
            changeLook();
        }
    }
}
