using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreScript : MonoBehaviour
{
    public TextMeshProUGUI strokeLvl1;
    public TextMeshProUGUI strokeLvl2;
    public TextMeshProUGUI strokeLvl3;

    void Start()
    {
        int strokes1 = PlayerPrefs.GetInt("Lvl 1 Lowest", 0);
        if (strokes1 > 0)
        {
            strokeLvl1.text = "+ Level 1: " + strokes1;
        }
        else
        {
            strokeLvl1.text = "+ Level 1: N/A";
        }

        int strokes2 = PlayerPrefs.GetInt("Lvl 2 Beta Lowest", 0);
        if (strokes2 > 0)
        {
            strokeLvl2.text = "+ Level 2: " + strokes2;
        } else
        {
            strokeLvl2.text = "+ Level 2: N/A";
        }

        int strokes3 = PlayerPrefs.GetInt("Lvl 3 Beta Lowest", 0);
        if (strokes3 > 0)
        {
            strokeLvl3.text = "+ Level 3: " + strokes3;
        }
        else
        {
            strokeLvl3.text = "+ Level 3: N/A";
        }
    }
}
