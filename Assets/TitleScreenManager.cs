using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public float delayBeforeLoad = 0.1f;
    public AudioSource audioSound;

    public void OnStartButtonClick()
    {
        PlaySoundAndLoadScene("Lvl 1");
        Debug.Log("Load Lvl1");
    }

    public void OnTutorialButtonClick()
    {
        PlaySoundAndLoadScene("Tutorial");
        Debug.Log("Load Tutorial");
    }

    public void OnReturnButtonClick()
    {
        PlaySoundAndLoadScene("TitleScreen");
        Debug.Log("Load Title");
    }

    private void PlaySoundAndLoadScene(string sceneName)
    {
        Invoke("LoadScene", delayBeforeLoad);
        audioSound.Play();
        SceneManager.LoadScene(sceneName);
    }

    private void LoadScene()
    {
        // Do nothing here, as the scene loading is invoked with a delay
    }
}
