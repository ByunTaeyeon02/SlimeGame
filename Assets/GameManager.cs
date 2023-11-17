using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPopup;
    public GameObject settingsPopup;
    public TextMeshProUGUI pauseButtonText;
    private bool isPaused;
    private bool isSettingsOpen;
    public SlimeScript slime1;
    public SlimeScript slime2;
    public TextMeshProUGUI heartsText;
    public TextMeshProUGUI strokeText;

    public FinishLine slime1Finish;
    public FinishLine slime2Finish;

    private void Start()
    {
        gameOverPopup.SetActive(false);
        settingsPopup.SetActive(false);
        isSettingsOpen = false;
        isPaused = false;
    }

    void Update()
    {
        heartsText.text = "Slime1 Hearts: " + slime1.health + "\nSlime2 Hearts: " + slime2.health;

        strokeText.text = "Stroke: " + slime1.GetComponent<FlingSlimeSimplify>().parNum;

        if (!isPaused)
        {
            pauseButtonText.text = "PAUSE";
        } else
        {
            pauseButtonText.text = "UNPAUSE";
        }

        // Check if the slime's health is less than or equal to 0
        if (slime1.health <= 0 || slime2.health <= 0)
        {
            gameOverPopup.SetActive(true);
        }

        if (slime1Finish.onPlatform && slime2Finish.onPlatform)
        {
            Debug.Log(strokeText.text);
            string currentSceneName = SceneManager.GetActiveScene().name;
            Debug.Log(currentSceneName);
            if (String.Compare(currentSceneName, "Tutorial Beta") == 0)
            {
                SceneManager.LoadScene("Lvl1 Beta");
            } else
            {
                SceneManager.LoadScene("Title");
            }
        }
    }

    public void ToggleSettings()
    {
        if (isSettingsOpen)
        {
            settingsPopup.SetActive(false);
        } else
        {
            settingsPopup.SetActive(true);
        }
        isSettingsOpen = !isSettingsOpen;
    }

    public void TogglePause()
    {   
        if (isPaused)
        {
            Time.timeScale = 1f;
        } else
        {
            Time.timeScale = 0f;
        }
        isPaused = !isPaused;
    }

    public void ResetSlimes()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void toMenu()
    {
        SceneManager.LoadScene("Title");
    }

}
