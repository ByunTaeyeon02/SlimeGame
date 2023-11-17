using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public SlimeScript slime;
    public bool onPlatform = false;

    //fix finish line bug to make sure they are both on the line at the same time
    void OnCollisionStay2D(Collision2D collision)
    {
        List<Rigidbody2D> bones = slime.bones;
        foreach (Rigidbody2D bone in bones)
        {
            if (collision.collider == bone.GetComponent<Collider2D>())
            {
                onPlatform = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        onPlatform = false;
    }
}
