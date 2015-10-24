using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class hangMan : MonoBehaviour {
    public GameObject image;
    private int counter = 0;
    public Sprite[] een = new Sprite[6];

    void OnGUI()
    {
        GUI.contentColor = Color.white;

        if (GUI.Button(new Rect((Screen.width) / 2 - (Screen.width) / 8,
          (Screen.height) / 3 - (Screen.height) / 6,
          (Screen.width) / 4, (Screen.height) / 12), "Ophangen"))
        {
            counter++;
           

           
            }

        switch (counter)
        {
            case 0:
                image.GetComponent<SpriteRenderer>().sprite = een[0];
                break;
            case 1:
                image.GetComponent<SpriteRenderer>().sprite = een[1];
                break;
            case 2:
                image.GetComponent<SpriteRenderer>().sprite = een[2];
                break;
            case 3:
                image.GetComponent<SpriteRenderer>().sprite = een[3];
                break;
            case 4:
                image.GetComponent<SpriteRenderer>().sprite = een[4];
                break;
            case 5:
                image.GetComponent<SpriteRenderer>().sprite = een[5];
                break;
            case 6:
                image.GetComponent<SpriteRenderer>().sprite = een[6];
                break;

        }
    }
}
    
