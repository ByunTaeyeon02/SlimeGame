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
    public HeartManager heartIcons;
    public TextMeshProUGUI strokeText;

    public FinishLine slime1Finish;
    public FinishLine slime2Finish;

    public AudioSource popSoundEffect;

    private void Start()
    {
        gameOverPopup.SetActive(false);
        settingsPopup.SetActive(false);
        isSettingsOpen = false;
        isPaused = false;
    }

    void Update()
    {
        heartIcons.purpleHealth = slime1.health;
        heartIcons.orangeHealth = slime2.health;

        if (slime1.GetComponent<FlingSlimeSimplify>().parNum == 1)
        {
            strokeText.text = "Stroke: " + slime1.GetComponent<FlingSlimeSimplify>().parNum;
        } else
        {
            strokeText.text = "Strokes: " + slime1.GetComponent<FlingSlimeSimplify>().parNum;
        }

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

            PlayerPrefs.SetInt(currentSceneName, slime1.GetComponent<FlingSlimeSimplify>().parNum);
            PlayerPrefs.Save();

            if (String.Compare(currentSceneName, "Lvl 1") == 0)
            {
                SceneManager.LoadScene("Lvl 2 Beta");
            } else if (String.Compare(currentSceneName, "Lvl 2 Beta") == 0)
            {
                SceneManager.LoadScene("Summary");
            }
            else
            {
                SceneManager.LoadScene("TitleScreen");
            }
        }
    }

    public void ToggleSettings()
    {
        playSound();
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
        playSound();
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
        playSound();
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void toMenu()
    {
        playSound();
        SceneManager.LoadScene("TitleScreen");
    }

    public void playSound()
    {
        popSoundEffect.Play();
    }
}
