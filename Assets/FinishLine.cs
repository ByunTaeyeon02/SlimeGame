using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public SlimeScript slime;
    public bool onPlatform = false;

    void OnCollisionStay2D(Collision2D collision)
    {
        List<Rigidbody2D> bones = slime.bones;
        bool oneOn = false;
        foreach (Rigidbody2D bone in bones)
        {
            if (collision.collider == bone.GetComponent<Collider2D>())
            {
                oneOn = true;
            }
        }
        if (oneOn)
        {
            onPlatform = true;
        } else
        {
            onPlatform = false;
        }
    }
}
