using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SummaryManager : MonoBehaviour
{
    public TextMeshProUGUI strokeLvl1;
    public TextMeshProUGUI strokeLvl2;
    public TextMeshProUGUI strokeTotal;

    public AudioSource audioSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSound.Play();

        int strokes1 = PlayerPrefs.GetInt("Lvl 1", 0);
        strokeLvl1.text = "+ Level 1: " + strokes1;

        int strokes2 = PlayerPrefs.GetInt("Lvl 2 Beta", 0);
        strokeLvl2.text = "+ Level 2: " + strokes2;

        int total = strokes1 + strokes2;
        strokeTotal.text = "+ Total: " + total;
    }
}
