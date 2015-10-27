using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class a_view : MonoBehaviour {

    private a_model a = a_controller.AccessToModel;
    private GUIStyle fontSize;

    void Start()
    {
        fontSize = new GUIStyle();
        fontSize.fontSize = 40;
    }


    private void OnGUI()
    {
        //De tijd wordt gelijk gesteld aan uren / minuten / seconden, waar we - doen voor elke second die voorbij gaat (aftellen)
        a_controller.AccessToModel.Time -= Time.deltaTime;
        //********************************** TIJD **************************************//
        //Als de tijd groter is dan 0 dan..
        if (a_controller.AccessToModel.Time > 0)
        {
        //show de tijd die je nog over hebt in GUI (unity scherm)
            GUI.Label(new Rect(100, 100, 200, 200), "Je hebt nog " + (int)a_controller.AccessToModel.Time + " seconden");
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

        //********************************** POSITIE BOXEN **************************************//

        //Positie van de Positie waar de streepjes van het te raden woord in moeten komen
        Rect BoxPosition = new Rect(500, 50, 200, 50);
        GUI.Box(BoxPosition, a.GuessedWord, fontSize);
        
        //Positie van de textField, input die van de user kan komen
        Rect textFieldPosition = new Rect(500, 100, 200, 100);
        a.UserInput = GUI.TextField(textFieldPosition, a.UserInput);

        //Positie van de drukknop
        Rect buttonPosition = new Rect(500, 200, 200, 100);

        //********************************** VERGELIJKING **************************************//

        //Als het gekozen woord volledig gelijk is aan het te raden woord dan..
        //if (a.GuessedWord == a.Chosen_word)
        //{
        //    //Voeg score toe
        //    a_controller.AccessToController.AddScore();
        //    //Genereer een nieuw random woord
        //    a_controller.AccessToController.GenerateRandomWord();
        //}
        a_controller.AccessToController.WordIsRight();

        GUI.Label(new Rect(50, 100, 200, 200), "Score" + a_controller.AccessToModel.Score);


        //********************************** BUTTON **************************************//

        //Als er op de knop wordt gedrukt dan... (Op de knop staat "Probeer")
        if (GUI.Button(buttonPosition, "Probeer"))
        {
            a_controller.AccessToController.CheckForLives();
            //Enkel bij invoer van 1 karakter toelating geven om te spelen
            if (a.UserInput.Length == 0 || a.UserInput.Length > 1 )
            {
                //Spawnt een foto die hangende man laat zien
                a_controller.AccessToController.SpawnFoto();
                a_controller.AccessToModel.Lives--;
            }
            else
            {
                //de checkCharacter gaan aanspreken om elke karakter in het woord te checken op de invoer, bij dezelfde karakter deze op die plaats zetten
                a_controller.AccessToController.checkCharacter(a.UserInput[0]);
                //Leegmaken van de user input na elke invoer van een letter
                a.UserInput = GUI.TextField(textFieldPosition,"");
            }
        }
    }

}
