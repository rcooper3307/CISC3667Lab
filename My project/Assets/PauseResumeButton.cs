using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResumeButton : MonoBehaviour
{
    [SerializeField] GameObject[] pauseObjects;
    [SerializeField] GameObject[] resumeObjects;
    // Start is called before the first frame update
    void Start()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("Pause");
        resumeObjects = GameObject.FindGameObjectsWithTag("Resume");
        //pause objects only are revealed when the game is paused, so at the start of the game they are hidden
        foreach (GameObject g in pauseObjects)
            g.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;

        //when the game is paused, objects with the pause tag are made visible and objects with the resume tag are hidden
        foreach (GameObject g in pauseObjects)
            g.SetActive(true);
        foreach (GameObject g in resumeObjects)
            g.SetActive(false);
    }
    
    public void Resume()
    {
        Time.timeScale = 1.0f;

        //when the game is resumed, objects with the resume tag are made visible and objects with the pause tag are hidden
        foreach (GameObject g in pauseObjects)
            g.SetActive(false);
        foreach (GameObject g in resumeObjects)
            g.SetActive(true);
    }

}
