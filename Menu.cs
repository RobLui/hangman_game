using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    void OnGUI()
    {
        GUI.backgroundColor = Color.white;
        GUI.contentColor = Color.white;

        GUI.Label(new Rect(100, 100, 200, 200), "You Lose");

        if (GUI.Button(new Rect(
          (Screen.width) / 2 - (Screen.width) / 8,
          (Screen.height) / 3 - (Screen.height) / 6,
          (Screen.width) / 4, (Screen.height) / 12), "Play again") ||
          (Input.GetKey(KeyCode.P)))
        {
            Application.LoadLevel("scene-one");
        }
    }
}