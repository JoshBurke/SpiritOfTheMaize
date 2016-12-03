using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{

    public Texture backgroundTexture;

    void OnGUI()
    {
        //Display our Background Texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
        
    }
}
