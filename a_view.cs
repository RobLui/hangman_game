using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class a_view : MonoBehaviour {

    private a_model a = a_controller.AccessToModel;
    private float time = 60;

    // Use this for initialization
    void Start ()
    {
        //Waarde van Chosen_word = random woord
        a.Chosen_word = a_model.wordList[a_controller.AccessToController.PickWord()];
        //Guessed word (aantal streepjes voor het verborgen woord) wordt gelijk gezet aan het random woord
        a.GuessedWord = new string("-"[0], a.Chosen_word.Length);
        //Spiekbriefje voor in de console te kunnen zien wat het woord dat geraden moet worden is
        Debug.Log(a.Chosen_word);
    }

    void Update()
    {
        //De tijd wordt gelijk gesteld aan uren / minuten / seconden, waar we - doen voor elke second die voorbij gaat (aftellen)
        time -= Time.deltaTime;
    }

    private void OnGUI()
    {
        if (time > 0)
        {
        //Show de tijd die je nog over hebt in GUI (unity scherm)
            GUI.Label(new Rect(100, 100, 100, 100), "Je hebt nog " + (int)time + " seconden");
        }
        else
        {
        //Verander het label naar andere text op dezelfde plaats in GUI
            GUI.Label(new Rect(100, 100, 100, 100), "Je tijd is om");
            //waarde van levend/dood wordt op "dood" gezet als de tijd over is
            a.Still_alive = false;
            //stop het spel als de tijd om is ------ NOG AAN TE MAKEN ------
            a_controller.AccessToController.EndGame();
        }

        //Positie van de Positie waar de streepjes van het te raden woord in moeten komen
        Rect BoxPosition = new Rect(500, 50, 200, 50);
        GUI.Box(BoxPosition, a.GuessedWord);

        //Positie van de textField, input die van de user kan komen
        Rect textFieldPosition = new Rect(500, 100, 200, 100);
        a.UserInput = GUI.TextField(textFieldPosition, a.UserInput);

        //Positie van de drukknop
        Rect buttonPosition = new Rect(500, 200, 200, 100);

        //Als het gekozen woord volledig gelijk is aan het te raden woord dan..
        if (a.GuessedWord == a.Chosen_word)
        {
            //Voeg score toe
            a_controller.AccessToController.AddScore();
            //Genereer een nieuw random woord (onderste 2 regels)
            a.Chosen_word = a_model.wordList[a_controller.AccessToController.PickWord()];
            a.GuessedWord = new string("-"[0], a.Chosen_word.Length);
        }

        //Als er op de knop wordt gedrukt dan... (Op de knop staat "Probeer")
        if (GUI.Button(buttonPosition, "Probeer"))
        {
            //Enkel bij invoer van 1 karakter toelating geven om te spelen
            if (a.UserInput.Length == 0 || a.UserInput.Length > 1 )
            {
            //Bij overtreden invoerregel van 1, VOORLOPIG ------- AAN TE PASSEN OP SCHERM ----- deze error te geven
                Debug.Log("Not allowed");
            }
            else
            {
                //de checkCharacter gaan aanspreken om elke karakter in het woord te checken op de invoer, bij dezelfde karakter deze op die plaats zetten
                a_controller.AccessToController.checkCharacter(a.UserInput[0]);
                //Leegmaken van de user input na elke invoer van een letter
                a.UserInput = GUI.TextField(textFieldPosition,"");
                //VOORLOPIGE message die zegt dat de invoer toegelaten is ----- KAN VERWIJDERT WORDEN ------ later
                Debug.Log("Allowed");
            }
        }
    }
}
