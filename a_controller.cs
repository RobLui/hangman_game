using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class a_controller : MonoBehaviour {

    //Toegang tot het model vanuit anderen die via de controller waardes uit het model nodig hebben
    public static a_model AccessToModel = new a_model();
    //Toegang tot de controller vanuit andere klasses
    public static a_controller AccessToController = new a_controller();

    public static a_view AccesToView = new a_view();

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
            AccessToModel.Lives--;

            //Show een foto dat iem ophangt
            a_controller.AccessToController.SpawnFoto();

            //Laat ----VOORLOPIG---- de levens zien die nog over zijn in de console ----DIT MOET NOG AANGEPAST WORDEN----
            Debug.Log(AccessToModel.Lives);
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
        if (AccessToModel.Still_alive == false)
        {
            //laat een nieuw spel starten(door een scene te laden) ----DIT MOET NOG AANGEPAST WORDEN----
            Application.LoadLevel("scene-one");
        }
    }

    //Als er iets fout is moet er een nieuw lichaamsdeel verschijnen ----DIT NOG LATEN VERSCHIJNEN-----
    //ipv in Unity foto's te laten ophalen , puur door code proberen

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
                break;
        }
        AccessToModel.Counter++;
    }
}
