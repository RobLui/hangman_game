using UnityEngine;
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
        GenerateRandomWord();
    }

    //Genereer een random woord om te raden
    public void GenerateRandomWord() 
    {
        //Waarde van Chosen_word = random woord
        AccessToModel.Chosen_word = a_model.wordList[PickWord()];
        //Guessed word (aantal streepjes voor het verborgen woord) wordt gelijk gezet aan het random woord
        AccessToModel.GuessedWord = new string("-"[0], AccessToModel.Chosen_word.Length);
        //Spiekbriefje voor in de console te kunnen zien wat het woord dat geraden moet worden is
        Debug.Log(AccessToModel.Chosen_word);
    }

    //Genereer een random woord op basis van de lijst grootte
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
        if (AccessToModel.IsPressed)
        {
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
                AccessToModel.Lives--;

                //Laat nieuw deel van de man zien
                a_controller.AccessToController.SpawnFoto();
            }
        }
    }

    //Voeg score toe
    public int AddScore()
    {
            //Tel een punt bij
            AccessToModel.Score++;
            
            //Return de waarde die Score op na toevoeging heeft
            return AccessToModel.Score;
    }

    //Spawn foto van hangende man
    public void SpawnFoto()
    {
        switch (a_controller.AccessToModel.Counter)
        {
            case 0:
                GameObject.FindWithTag("fotos").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hung1");
                break;
            case 1:
                GameObject.FindWithTag("fotos").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("hung2");
                break;
            case 2:
                GameObject.FindWithTag("fotos").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("shirt");
                break;
            case 3:
                GameObject.FindWithTag("fotos").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("rightarm");
                break;
            case 4:
                GameObject.FindWithTag("fotos").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("leftarm");
                break;
            case 5:
                GameObject.FindWithTag("fotos").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("rightleg");
                break;
            case 6:
                GameObject.FindWithTag("fotos").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("leftleg");
                a_controller.AccessToModel.IsPressed = false;
                a_controller.AccessToModel.Time = 0;
                break;
        }
        AccessToModel.Counter++;
    }

    //Check of er nog voldoende levens zijn om verder te spelen
    public void CheckForLives()
    {
        if (AccessToModel.Lives < 0)
        {
            //Zet still_alive op vals
            AccessToModel.Still_alive = false;
        }
    }

    //Als het woord gelijk is aan het gezochte woord voeg dan score toe
    public void WordIsRight()
    {
        //Vergelijk het ingevoerde woord met het te raden woord
        if (AccessToModel.GuessedWord == AccessToModel.Chosen_word)
        {
            //Voeg score toe
            AddScore();
            //Genereer een nieuw random woord
            GenerateRandomWord();
        }
    }

    //Reset de counter naar 0
    public void CounterZero()
    {
        //Zet de waarde van counter op 0, zorgt ervoor dat de foto's terug van 0 beginnen
        a_controller.AccessToModel.Counter = 0;
        //Score wordt gereset
        a_controller.AccessToModel.Score = 0;
    }

    //topScore gelijk zetten aan score wanneer hoger dan huidige score
    public void UpdateTopScore()
    {
        if(AccessToModel.Score >= AccessToModel.TopsScore)
        {
            AccessToModel.TopsScore = AccessToModel.Score;
        }
    }
}
