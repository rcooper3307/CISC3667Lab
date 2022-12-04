using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScores : MonoBehaviour
{
    const int NUM_HIGH_SCORES = 5;
    const string NAME_KEY = "Player";
    const string SCORE_KEY = "Score";

    [SerializeField] string playerName;
    [SerializeField] int playerScore;

    [SerializeField] TextMeshProUGUI[] nameTexts;
    [SerializeField] TextMeshProUGUI[] scoreTexts;
    // Start is called before the first frame update
    void Start()
    {
        //gets the name and score for this current session
        playerName = PersistentData.Instance.GetName();
        playerScore = PersistentData.Instance.GetScore();

        SaveHighScores();
        //1 Player1
        //1 Score1 
        //2 Player2
        //2 Score2 ...etc
        for(int i = 1; i <= NUM_HIGH_SCORES; i++)
        {
            Debug.Log(i + " " + PlayerPrefs.GetString(NAME_KEY + i) + " ");
            Debug.Log(i + " " + PlayerPrefs.GetInt(SCORE_KEY + i) + " ");
        }

        ShowHighScores();
    }

    public void SaveHighScores()
    {
        //1 Player1
        //1 Score1 
        //2 Player2
        //2 Score2 ...etc
        for (int i = 1; i <= NUM_HIGH_SCORES; i++)
        {
            Debug.Log(i + " " + PlayerPrefs.GetString(NAME_KEY + i) + " ");
            Debug.Log(i + " " + PlayerPrefs.GetInt(SCORE_KEY + i) + " ");
        }
        //while i is less than 5, i goes up
        for(int i = 1; i <= NUM_HIGH_SCORES; i++)
        {
            
            string currentNameKey = NAME_KEY + i; //Playeri
            string currentScoreKey = SCORE_KEY + i; //Scorei

            if(PlayerPrefs.HasKey(currentScoreKey)) //if the key scorei exists in player prefs
            {
                int currentScore = PlayerPrefs.GetInt(currentScoreKey); //retrieve the score currently stored in scorei
                if(playerScore > currentScore) //if the playerScore is higher than the one stored in scorei
                {
                    int tempScore = currentScore; //store the scorei in a temp variable
                    string tempName = PlayerPrefs.GetString(currentNameKey); //store the playeri name in a temporary variable

                    PlayerPrefs.SetString(currentNameKey, playerName); //set the name for scorei to the currentplayer's name
                    PlayerPrefs.SetInt(currentScoreKey, playerScore); //set the score for scorei to the currentplayer's score

                    playerName = tempName; //the old variable for the current players name is set to the old scorei player's name
                    playerScore = tempScore; //same with the score
                    //this is so that in the next iteration of the loop it uses the old name and scores as parameters
                }
            }
            else //if playeri does not exist in player prefs
            {
                PlayerPrefs.SetString(currentNameKey, playerName); //set a key in playerprefs for playeri with the value of the current player name
                PlayerPrefs.SetInt(currentScoreKey, playerScore); //set a key in playerprefs for scorei with the value of the current score
                return;
            }
        }
    }
    
    public void ShowHighScores()
    {
        //this just sets 
        for(int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            Debug.Log(i + " ");
            nameTexts[i].text = PlayerPrefs.GetString(NAME_KEY + (i + 1));
            scoreTexts[i].text = PlayerPrefs.GetInt(SCORE_KEY + (i + 1)).ToString();
        }
    }
}
