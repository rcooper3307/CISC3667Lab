using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] int health;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] int SCORE_TO_ADVANCE = 0;
    [SerializeField] int balloonCount;
    [SerializeField] int balloons_timed_out = 0;
    const int DEFAULT_POINTS = 1;
    const int DEFAULT_DAMAGE = 1;
    const int DEATH = 0;
    [SerializeField] int level;
    // Start is called before the first frame update
    void Start()
    {
        score = PersistentData.Instance.GetScore();
        health = PersistentData.Instance.GetHealth();
        level = SceneManager.GetActiveScene().buildIndex;
        scoreText.text = "Score: " + score;
        levelText.text = "Level: " + level;
        healthText.text = "Health: " + health;
        balloonCount = GameObject.FindGameObjectsWithTag("Balloon").Length;
        SCORE_TO_ADVANCE = balloonCount;
    }

    // Update is called once per frame
    void Update()
    {
        balloonCount = GameObject.FindGameObjectsWithTag("Balloon").Length;
        //if all the balloons pop and any of them timed out, then you are guided to the score screen
        if ((balloonCount == 0) && (balloons_timed_out > 0))
            Score();
        //if all the balloons pop in a level and none have timed out, move to the next level
        if ((balloonCount <= 0) && (balloons_timed_out == 0) && (level < 3))
            AdvanceLevel();
        //if you beat the final level, go to the score screen
        if ((balloonCount <= 0) && (balloons_timed_out == 0) && (level == 3))
        {
            AddPoints(health);
            Score();
        }
    
    }
    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        PersistentData.Instance.SetScore(score);
        DisplayScore();
        


    }
    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }
    //this tracks how many balloons have timed out
    public void BalloonTimedOut()
    {
        balloons_timed_out++;
    }

    public void Damage(int damageTaken)
    {
        health -= damageTaken;
        PersistentData.Instance.SetHealth(health);
        DisplayHealth();
        if (health <= DEATH)
            Score();
    }
    public void Damage()
    {
        Damage(DEFAULT_DAMAGE);
    }

    public void Score()
    {
        SceneManager.LoadScene("score");
    }
    public void AdvanceLevel()
    {
        SceneManager.LoadScene(level + 1);
    }

    public void DisplayScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void DisplayHealth()
    {
        healthText.text = "Health: " + health;
    }
}
