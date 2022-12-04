using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] public int playerScore;
    [SerializeField] public int playerHealth;
    [SerializeField] public string playerName;

    const int DEFAULT_PLAYER_HEALTH = 10;
    const int STARTING_SCORE = 0;

    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }     
        else
            Destroy(gameObject);
    }
    void Start()
    {
        playerHealth = DEFAULT_PLAYER_HEALTH;
        playerScore = STARTING_SCORE;
        playerName = "";
    }

    public void SetHealth(int health)
    {
        playerHealth = health;
    }
    public void SetScore(int score)
    {
        playerScore = score;
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    public int GetHealth()
    {
        return playerHealth;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public string GetName()
    {
        return playerName;
    }
}
