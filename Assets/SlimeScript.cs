using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public List<Rigidbody2D> bones = new List<Rigidbody2D>();
    public int health;
    public bool harmable = true;
    public float invinsibleAfterDmgTimer = 2.5f;
    private Coroutine enableHarmableCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        // Clear the list to avoid duplicates if Start() is called multiple times
        bones.Clear();

        // Get all the Rigidbody2D components attached to this GameObject and its children
        Rigidbody2D[] allRigidbodies = GetComponentsInChildren<Rigidbody2D>();

        // Add the Rigidbody2D components to the bones list
        foreach (Rigidbody2D boneRigidbody in allRigidbodies)
        {
            // Exclude the current GameObject's Rigidbody2D to avoid adding it to the list
            if (boneRigidbody != GetComponent<Rigidbody2D>())
            {
                bones.Add(boneRigidbody);
            }
        }

        health = 3;
        /*
        // Print the names of bones in the list
        foreach (Rigidbody2D bone in bones)
        {
            Debug.Log("Bone Name: " + bone.gameObject.name);
        } */
    }

    void Update()
    {
        if (!harmable && enableHarmableCoroutine == null)
        {
            enableHarmableCoroutine = StartCoroutine(EnableHarmableAfterDelay(invinsibleAfterDmgTimer));
        }

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator EnableHarmableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        harmable = true;
        enableHarmableCoroutine = null; // Reset the coroutine reference
    }
}
