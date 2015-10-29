using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class a_view : MonoBehaviour {

    private a_model a = a_controller.AccessToModel;
    // public GUIStyle stylingGUI;
    public GUISkin stylingSkin;

    public void OnGUI()
    {

        //Dient om ons lettertype grootte/kleur etc. te veranderen
        GUI.skin = stylingSkin;

        //De tijd wordt gelijk gesteld aan uren / minuten / seconden, waar we - doen voor elke second die voorbij gaat 
        a_controller.AccessToModel.Time -= Time.deltaTime;

        //********************************** TIJD **************************************//
        //Als de tijd groter is dan 0 dan..
        if (a_controller.AccessToModel.Time > 0)
        {
        //show de tijd die je nog over hebt in GUI (unity scherm)
            GUI.Label(new Rect(200, 100, 200, 100), ((int)a_controller.AccessToModel.Time).ToString());
        }
        else
        {
        //Verander het label naar andere text op dezelfde plaats in GUI
            GUI.Label(new Rect(200, 100, 200, 100), "You lose");
            //waarde van levend/dood wordt op "dood" gezet als de tijd over is
            a.Still_alive = false;
            //Toon het woord dat je moest raden als je dood bent
            GUI.Box(new Rect(750, 500, 300, 50), ("Het woord was " + a_controller.AccessToModel.Chosen_word).ToString());
        }




        //********************************** POSITIES **************************************//

        //Positie van de Positie waar de streepjes van het te raden woord in moeten komen
        Rect BoxPosition = new Rect(500, 100, 200, 50);
        GUI.Box(BoxPosition, a.GuessedWord);
        
        //Positie van de textField, input die van de user kan komen
        Rect textFieldPosition = new Rect(500, 300, 200, 100);
        a.UserInput = GUI.TextField(textFieldPosition, a.UserInput);

        //Positie van de drukknop
        Rect buttonPosition = new Rect(500, 400, 200, 100);





        //********************************** VERGELIJKING **************************************//

        //Als het gekozen woord volledig gelijk is aan het te raden woord dan..
        a_controller.AccessToController.WordIsRight();
        //Zet de waarde van topScore op de effectief hoogste waarde, anders doe niets
        a_controller.AccessToController.UpdateTopScore();

        //Zet het label van Score op de waarde
        GUI.Label(new Rect(200, 300, 200, 100), ("Score: " + a_controller.AccessToModel.Score));

        //Zet het label van TopScore op waarde
        GUI.Label(new Rect(200, 500, 200, 100), ("TopScore: " + a_controller.AccessToModel.TopsScore));





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
        //Als de counter terug naar 0 wordt gezet
        if (a_controller.AccessToModel.Counter == 0)
        {
            //Dan zet je automatisch de knop uit waarmee je een nieuw spel kan starten (dit door deze bool)
            a_controller.AccessToModel.IsPressed = true;
        }
        //Als je dood bent dan
        if (a_controller.AccessToModel.Still_alive == false)
        {
            //Als de knop nog niet ingedrukt is en de tijd kleiner of gelijk aan nul is
            if (!a_controller.AccessToModel.IsPressed || a_controller.AccessToModel.Time <= 0)
            {
                //Laad zowizo de foto van de volledig hangende man omdat je dood bent
                GameObject.FindWithTag("fotos").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("leftleg");

                //instantieer een nieuwe button (enkel hier toepasbaar door GUI laag enkel 1 maal bereikbaar
                if (GUI.Button(new Rect(500, 500, 200, 100), "Play Again"))
                {
                    //Genereer random woord
                    a_controller.AccessToController.GenerateRandomWord();
                    //Zet de counter voor de aanroeping van de foto-elementen terug op 0, zodat terug van hier begonnen kan worden
                    a_controller.AccessToController.CounterZero();
                    //Zet de tijd terug op een de waarde waar je mee begon
                    a_controller.AccessToModel.Time = 121;
                    //Laad een lege afbeelding zodat je terug vanuit geen foto-elementen kan beginnen met het spel
                    GameObject.FindWithTag("fotos").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("");
                    //Zet de waarde van Pressed op true waardoor je er gaat voor zorgen dat de button verdwijnt
                    a_controller.AccessToModel.IsPressed = true;
                }
            }
        }
    }
}
