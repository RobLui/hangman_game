using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    public void OnGUI()
    {
        GUI.backgroundColor = Color.white;
        GUI.contentColor = Color.white;

        if (GUI.Button(new Rect(
          (Screen.width) / 2 - (Screen.width) / 8,
          (Screen.height) / 3 - (Screen.height) / 6,
          (Screen.width) / 4, (Screen.height) / 12), "Start") ||
          (Input.GetKey(KeyCode.P)))
        {
            Application.LoadLevel("scene-one");
        }
    }
}