using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class a_controller : MonoBehaviour {

    //toegang tot het model vanuit anderen die via de controller waardes uit het model nodig hebben
    public static a_model AccessToModel = new a_model();
    //toegang tot de controller vanuit andere klasses
    public static a_controller AccessToController = new a_controller();

    public int PickWord()
    {
        int pick_random_nbr = 0; 
        pick_random_nbr = Random.Range(0, a_model.wordList.Count);
        return pick_random_nbr;
    }

    public void checkCharacter(char a)
    {
        bool charExists = false;
        for (int x = 0; x < AccessToModel.Chosen_word.Length; x++)
        {
            //ff zien of ik hier niet gwn accestomodel kan gebruiken
            if (AccessToModel.Chosen_word[x] == a)
            {
                charExists = true;
                string temp = AccessToModel.GuessedWord.Substring(0, x);
                AccessToModel.GuessedWord = temp + a.ToString() + AccessToModel.GuessedWord.Substring(x + 1, AccessToModel.GuessedWord.Length - x - 1);
            }
        }
        if (!charExists)
        {
            a_controller.AccessToModel.Lives--;
            Debug.Log(a_controller.AccessToModel.Lives);
        }
    }

    //Voeg score toe
    public void AddScore()
    {
            AccessToModel.Score++;
            Debug.Log(AccessToModel.Score.ToString());
    }


    //Stop het spel
    public void EndGame()
    {
        if (a_controller.AccessToModel.Still_alive == false)
        {
            //VOORLOPIG laat een nieuw spel starten(door een scene te laden)
            Application.LoadLevel("scene-one");
        }
    }



}
