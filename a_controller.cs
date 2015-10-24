﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class a_controller : MonoBehaviour {

    //Toegang tot het model vanuit anderen die via de controller waardes uit het model nodig hebben
    public static a_model AccessToModel = new a_model();
    //Toegang tot de controller vanuit andere klasses
    public static a_controller AccessToController = new a_controller();

    // Initialisatie
    void Start()
    {
        //Bij het starten van het spel creëer een woord om te raden
<<<<<<< HEAD
        GenerateRandomWord();
=======
        a_controller.AccessToController.GenerateRandomWord();
>>>>>>> 3f8468330cc43fdfceb795367c9d23609d64b211
    }

    void Update()
    {
        //De tijd wordt gelijk gesteld aan uren / minuten / seconden, waar we - doen voor elke second die voorbij gaat (aftellen)
<<<<<<< HEAD
        AccessToModel.Time -= Time.deltaTime;
=======
        a_controller.AccessToModel.Time -= Time.deltaTime;
>>>>>>> 3f8468330cc43fdfceb795367c9d23609d64b211
    }

    //Genereer een random woord om te raden
    public void GenerateRandomWord()
    {
        //Waarde van Chosen_word = random woord
        AccessToModel.Chosen_word = a_model.wordList[PickWord()];
        //Guessed word (aantal streepjes voor het verborgen woord) wordt gelijk gezet aan het random woord
        AccessToModel.GuessedWord = new string("-"[0], AccessToModel.Chosen_word.Length);
        //Spiekbriefje voor in de console te kunnen zien wat het woord dat geraden moet worden is ----DIT MAG LATER VERWIJDERD WORDEN----
        Debug.Log(AccessToModel.Chosen_word);
    }

    public int PickWord()
    {
        //Beginwaarde op 0
        int pick_random_nbr = 0;
        //Geef een random nummer terug die tussen de 0 en het de maximale hoeveelheid woorden in de List ligt
        pick_random_nbr = Random.Range(0, a_model.wordList.Count);
        //Geef dit nummer terug
        return pick_random_nbr;
    }

    //Check of het ingevoerde karakter in het te raden woord zit
    public void checkCharacter(char a)
    {
        //Bij oproepen functie is de karakter nog niet bestaande (hier vertrekken we van)
        bool charExists = false;
        
        //Loopen door elke letter van het gekozen woord
        for (int x = 0; x < AccessToModel.Chosen_word.Length; x++)
        {
            //Als karakter a gelijk is aan een letter in het woord dan..
            if (AccessToModel.Chosen_word[x] == a)
            {
                //Zetten we karakter bestaat op true
                charExists = true;
                //Gaan we een tijdelijke string aanmaken die het woord splitst en de letter op de plaats zet waar hij zijn gelijke letter terugvind
                string temp = AccessToModel.GuessedWord.Substring(0, x);
                //Zet guessedWord gelijk aan de toegevoegde letter (op de plaats waar hij vandaan komt) en voeg de rest van de letters weer toe als "-" in het woord
                AccessToModel.GuessedWord = temp + a.ToString() + AccessToModel.GuessedWord.Substring(x + 1, AccessToModel.GuessedWord.Length - x - 1);
            }
        }
        // Foute letter geraden = Als de karakter niet bestaat in het te zoeken woord dan..
        if (!charExists)
        {
            //Verwijder een leven
<<<<<<< HEAD
            AccessToModel.Lives--;
            //Laat ----VOORLOPIG---- de levens zien die nog over zijn in de console ----DIT MOET NOG AANGEPAST WORDEN----
            Debug.Log(AccessToModel.Lives);
=======
            a_controller.AccessToModel.Lives--;
            //Laat ----VOORLOPIG---- de levens zien die nog over zijn in de console ----DIT MOET NOG AANGEPAST WORDEN----
            Debug.Log(a_controller.AccessToModel.Lives);
>>>>>>> 3f8468330cc43fdfceb795367c9d23609d64b211
        }
    }

    //Voeg score toe
    public void AddScore()
    {
            //Tel een punt bij
            AccessToModel.Score++;
            //Laat voorlopig de score die je haalt in de console zien ----DIT MOET NOG AANGEPAST WORDEN----
            Debug.Log(AccessToModel.Score.ToString());
    }

    //Stop het spel
    public void EndGame()
    {
        //Als de bool still_alive false is dan ... 
<<<<<<< HEAD
        if (AccessToModel.Still_alive == false)
=======
        if (a_controller.AccessToModel.Still_alive == false)
>>>>>>> 3f8468330cc43fdfceb795367c9d23609d64b211
        {
            //laat een nieuw spel starten(door een scene te laden) ----DIT MOET NOG AANGEPAST WORDEN----
            Application.LoadLevel("scene-one");
        }
    }
}
