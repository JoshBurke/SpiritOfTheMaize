using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public enum state { Active, Inactive, Used, Locked };

    public state status;

    public checkpointHandler ch;

    public Sprite[] sprites;
    Animator anim;

    void Start()
    {
        ch = GameObject.Find("CheckPoint Handler").GetComponent<checkpointHandler>();
        anim = GetComponent<Animator>();
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
            anim.SetInteger("State", 0);
        }
        else if (status == state.Active)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            anim.SetInteger("State", 1);
        }
        else if (status == state.Used)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[2];
            anim.SetInteger("State", 2);
        }
        else if (status == state.Locked)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[3];
            anim.SetInteger("State", 2);
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
