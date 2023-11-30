using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public float delayBeforeLoad = 0.1f;
    public AudioSource audioSound;

    public void OnStartButtonClick()
    {
        PlaySoundAndLoadScene("Lvl 1");
    }

    public void OnTutorialButtonClick()
    {
        PlaySoundAndLoadScene("Tutorial");
    }

    public void OnReturnButtonClick()
    {
        PlaySoundAndLoadScene("TitleScreen");
    }

    public void OnHighscoreClick()
    {
        PlaySoundAndLoadScene("Highscore");
    }

    public void OnCreditClick()
    {
        PlaySoundAndLoadScene("Credits");
    }

    private void PlaySoundAndLoadScene(string sceneName)
    {
        Invoke("LoadScene", delayBeforeLoad);
        audioSound.Play();
        SceneManager.LoadScene(sceneName);
    }

    private void LoadScene()
    {
        
    }
}
