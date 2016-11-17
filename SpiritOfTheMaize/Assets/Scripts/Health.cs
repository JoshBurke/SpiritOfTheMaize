using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    private GameObject a;
    public int hp;




    // Use this for initialization
    void Start()
    {
        a = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0)
        {
            Destroy(a);
        }
    }
}
