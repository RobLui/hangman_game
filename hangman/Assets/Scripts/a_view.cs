﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class a_view : MonoBehaviour {

    private a_model a = a_controller.AccessToModel;
    // public GUIStyle stylingGUI;
    public GUISkin stylingSkin;

    public void OnGUI()
    {
        GUI.skin = stylingSkin;


        //De tijd wordt gelijk gesteld aan uren / minuten / seconden, waar we - doen voor elke second die voorbij gaat 
        a_controller.AccessToModel.Time -= Time.deltaTime;

        //********************************** TIJD **************************************//
        //Als de tijd groter is dan 0 dan..
        if (a_controller.AccessToModel.Time > 0)
        {
        //show de tijd die je nog over hebt in GUI (unity scherm)
            GUI.Label(new Rect(100, 100, 200, 200), ((int)a_controller.AccessToModel.Time).ToString());
        }
        else
        {
        //Verander het label naar andere text op dezelfde plaats in GUI
            GUI.Label(new Rect(100, 100, 100, 100), "Je tijd is om, you lose");
            //waarde van levend/dood wordt op "dood" gezet als de tijd over is
            a.Still_alive = false;
        }




        //********************************** POSITIE BOXEN **************************************//

        //Positie van de Positie waar de streepjes van het te raden woord in moeten komen
        Rect BoxPosition = new Rect(500, 50, 200, 50);
        GUI.Box(BoxPosition, a.GuessedWord);
        
        //Positie van de textField, input die van de user kan komen
        Rect textFieldPosition = new Rect(500, 100, 200, 100);
        a.UserInput = GUI.TextField(textFieldPosition, a.UserInput);





        //********************************** VERGELIJKING **************************************//

        //Als het gekozen woord volledig gelijk is aan het te raden woord dan..
        a_controller.AccessToController.WordIsRight();

        //Zet het label van score op de waardes
        GUI.Label(new Rect(900, 100, 200, 200), ("Score: " + a_controller.AccessToModel.Score));

        //Handel topscore af
        a_controller.AccessToController.UpdateTopScore();
        GUI.Label(new Rect(900, 300, 200, 200), ("TopScore: " + a_controller.AccessToModel.TopsScore));




        //********************************** BUTTON **************************************//

        //Positie van de drukknop
        Rect buttonPosition = new Rect(500, 200, 200, 100);

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

        if (a_controller.AccessToModel.Still_alive == false)
        {
            if (!a_controller.AccessToModel.IsPressed)
            {
                //instantieer een nieuwe button (enkel hier toepasbaar door GUI laag enkel 1 maal bereikbaar
                if (GUI.Button(new Rect(300, 200, 200, 100), "Play Again"))
                {
                    a_controller.AccessToController.GenerateRandomWord();
                    a_controller.AccessToController.CounterZero();
                    a_controller.AccessToModel.Time = 61;
                    GameObject.FindWithTag("fotos").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("");
                    a_controller.AccessToModel.IsPressed = true;
                }
            }
        }
    }
}
