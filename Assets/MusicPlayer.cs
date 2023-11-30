using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;

    private void Awake()
    {
        if (instance == null)
        {
            // If the instance is null, set it to this object
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this object
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Play the audio
        GetComponent<AudioSource>().Play();
    }
}