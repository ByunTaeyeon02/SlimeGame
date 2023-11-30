using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image purpleHeart1, purpleHeart2, purpleHeart3;
    public Image orangeHeart1, orangeHeart2, orangeHeart3;
    public int purpleHealth;
    public int orangeHealth;

    // Update is called once per frame
    void LateUpdate()
    {
        // Disable all hearts by default
        purpleHeart1.gameObject.SetActive(false);
        purpleHeart2.gameObject.SetActive(false);
        purpleHeart3.gameObject.SetActive(false);

        // Enable hearts based on orangeHealth value
        if (purpleHealth >= 1) purpleHeart1.gameObject.SetActive(true);
        if (purpleHealth >= 2) purpleHeart2.gameObject.SetActive(true);
        if (purpleHealth >= 3) purpleHeart3.gameObject.SetActive(true);

        // Disable all hearts by default
        orangeHeart1.gameObject.SetActive(false);
        orangeHeart2.gameObject.SetActive(false);
        orangeHeart3.gameObject.SetActive(false);

        // Enable hearts based on orangeHealth value
        if (orangeHealth >= 1) orangeHeart1.gameObject.SetActive(true);
        if (orangeHealth >= 2) orangeHeart2.gameObject.SetActive(true);
        if (orangeHealth >= 3) orangeHeart3.gameObject.SetActive(true);
    }
}
