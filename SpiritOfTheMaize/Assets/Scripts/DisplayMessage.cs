using UnityEngine;
using System.Collections;

public class DisplayMessage : MonoBehaviour
{
    private bool showText = false;
    private bool keyPressed = false;
    public GameObject obj;
    public Camera c;
    private float x, y;
    public string message;
    public float time;
    //public float yModifier, xModifier;
    private float timeCount = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && showText)
        {
            keyPressed = true;
        }
        if (keyPressed)
        {
            timeCount += Time.deltaTime;
        }
        if (timeCount > time)
        {
            keyPressed = false;
            timeCount = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Vector3 p = c.WorldToScreenPoint(obj.transform.position-obj.transform.localScale);
        x = p.x;// +xModifier;
        y = p.y;// +yModifier;
        showText = true;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        showText = false;
        keyPressed = false;
    }

    void OnGUI()
    {
        Rect textArea = new Rect(x, y, 200, 200);
        if (showText && keyPressed)
        {
            GUI.Label(textArea, message);
        }
    }
}
