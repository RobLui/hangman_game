using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class a_view : MonoBehaviour {

    private a_model a = a_controller.AccessToModel;
    private float time = 60;

    public Sprite myImage;

    // Use this for initialization
    void Start ()
    {
        a.Chosen_word = a_model.wordList[a_controller.AccessToController.PickWord()];
        a.GuessedWord = new string("-"[0], a.Chosen_word.Length);
        Debug.Log(a.Chosen_word);
        myImage = Resources.Load<Sprite>("a");
    }

    void Update()
    {
        time -= Time.deltaTime;
    }

    private void OnGUI()
    {
        if (time > 0)
        {
            GUI.Label(new Rect(100, 100, 100, 100), "Je hebt nog " + (int)time + " seconden");
        }
        else
        {
            GUI.Label(new Rect(100, 100, 100, 100), "Je tijd is om");
            a.Still_alive = false;
            a_controller.AccessToController.EndGame();
        }

        Rect BoxPosition = new Rect(500, 50, 200, 50);
        GUI.Box(BoxPosition, a.GuessedWord);

        Rect textFieldPosition = new Rect(500, 100, 200, 100);
        a.UserInput = GUI.TextField(textFieldPosition, a.UserInput);

        Rect buttonPosition = new Rect(500, 200, 200, 100);

        if (GUI.Button(buttonPosition, "Probeer"))
        {
            if (a.GuessedWord == a.Chosen_word)
            {
                a_controller.AccessToController.AddScore();
                a_controller.AccessToController.PickWord();
            }
            if (a.UserInput.Length == 0 || a.UserInput.Length > 1 )
            {
                Debug.Log("Not allowed");
            }
            else
            {
                a_controller.AccessToController.checkCharacter(a.UserInput[0]);
                a.UserInput = GUI.TextField(textFieldPosition,"");
                Debug.Log("Allowed");
            }
        }
    }
}
