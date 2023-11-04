using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        // Load the desired scene when the button is clicked
        SceneManager.LoadScene("Tutorial Beta"); // Replace "GameScene" with your actual game scene name
    }
}
