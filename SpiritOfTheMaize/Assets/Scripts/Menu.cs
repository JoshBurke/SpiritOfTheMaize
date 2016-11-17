using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    public Texture backgroundTexture;
    public GUIStyle random1; //adds a texture to the button

    public float guiPlacementX1;
    public float guiPlacementX2;
    public float guiPlacementY1;
    public float guiPlacementY2; //These maniuplate the positions of the buttons if not using GUI outline

    void OnGUI()
    {
        //Display our Background Texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        //DIsplays our Buttons (With GUI Outline)
        if (GUI.Button(new Rect(Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * .5f, Screen.height * .1f), "Play Game"))
        {
            Application.LoadLevel("Game");
            print("Clicked Play");
        }

        if (GUI.Button(new Rect(Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .5f, Screen.height * .1f), "Options"))
        {
            Application.LoadLevel("Options");
            print("Clicked Options");
        }

        //DIsplays our Buttons (Without GUI Outline)
        /* if (GUI.Button(new Rect(Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * .5f, Screen.height * .1f), "", random1))
         {
             print("Clicked Play Game");
         }

         if (GUI.Button(new Rect(Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .5f, Screen.height * .1f), "Options"))
         {
             print("Clicked Options");
         } */
    }
}
