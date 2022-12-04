using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Button : MonoBehaviour
{
    [SerializeField] public TMP_InputField playerNameInput;


    public void PlayGame()
    {
        PersistentData.Instance.SetName(playerNameInput.text);
        SceneManager.LoadScene("level1");
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("instructions");

    }

    public void MainMenu()
    {
        PersistentData.Instance.SetScore(0);
        PersistentData.Instance.SetHealth(10);
        SceneManager.LoadScene("menu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("settings");
    }
}
