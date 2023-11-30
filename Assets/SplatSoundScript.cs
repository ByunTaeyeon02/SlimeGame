using System.Collections;
using UnityEngine;

public class SplatSoundScript : MonoBehaviour
{
    public SlimeScript slime;
    //public AudioClip collisionSoundClip;
    //public AudioSource audioSource;
    public float minCollisionVelocity = 8f;

    public bool soundable = true;
    public float soundAfterDmgTimer = 0.75f;
    private Coroutine enableHarmableCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag != "Slime" && soundable)
        {
            // Check the relative velocity of the collision
            if (slime.bones[6].velocity.magnitude > minCollisionVelocity && GetComponent<AudioSource>() != null)
            {
                // Play the sound
                //AudioSource.PlayClipAtPoint(collisionSoundClip, transform.position);
                GetComponent<AudioSource>().Play();
                Debug.Log("play sound");
            }
            else
            {
                Debug.Log(slime.bones[6].velocity.magnitude);
            }
        }

    }

    void Update()
    {
        if (!soundable && enableHarmableCoroutine == null)
        {
            enableHarmableCoroutine = StartCoroutine(EnableHarmableAfterDelay(soundAfterDmgTimer));
        }
    }

    IEnumerator EnableHarmableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        soundable = true;
        enableHarmableCoroutine = null; // Reset the coroutine reference
    }
}
