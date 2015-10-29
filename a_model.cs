using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class a_model : MonoBehaviour {

    public static List<string> wordList = new List<string>()
    {
        "aap",
        "banaan",
        "appel",
        "naam",
        "index",
        "controle",
        "game"
    };

    private string userInput = "";
    public string UserInput
    {
        get
        {
            return userInput;
        }

        set
        {
            userInput = value;
        }
    }

    private string guessedWord = "";
    public string GuessedWord
    {
        get
        {
            return guessedWord;
        }

        set
        {
            guessedWord = value;
        }
    }

    private string chosen_word = "";
    public string Chosen_word
    {
        get
        {
            return chosen_word;
        }

        set
        {
            chosen_word = value;
        }
    }

    

    
    private float time = 121;
    public float Time
    {
        get
        {
            return time;
        }

        set
        {
            time = value;
        }
    }

    private int lives = 6;
    public int Lives
    {
        get
        {
            return lives;
        }

        set
        {
            lives = value;
        }
    }

    private int score = -1;
    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    private int topsScore;
    public int TopsScore
    {
        get
        {
            return topsScore;
        }

        set
        {
            topsScore = value;
        }
    }

    private int counter = 0;
    public int Counter
    {
        get
        {
            return counter;
        }

        set
        {
            counter = value;
        }
    }



    private bool still_alive = true;
    public bool Still_alive
    {
        get
        {
            return still_alive;
        }

        set
        {
            still_alive = value;
        }
    }

    private bool isPressed;
    public bool IsPressed
    {
        get
        {
            return isPressed;
        }

        set
        {
            isPressed = value;
        }
    }

}
