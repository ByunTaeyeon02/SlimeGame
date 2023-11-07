using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotTouch : MonoBehaviour
{
    public SlimeScript slime1;
    public SlimeScript slime2;
    public int damageAmount = 1;

    void OnCollisionStay2D(Collision2D collision)
    {
        List<Rigidbody2D> bones = slime1.bones;
        foreach (Rigidbody2D bone in bones)
        {
            if (collision.collider == bone.GetComponent<Collider2D>())
            {
                Debug.Log("Colided");
                if (slime1.harmable)
                {
                    slime1.health -= damageAmount;
                    slime1.harmable = false;
                }
            }
        }

        List<Rigidbody2D> bones2 = slime2.bones;
        foreach (Rigidbody2D bone in bones2)
        {
            if (collision.collider == bone.GetComponent<Collider2D>())
            {
                Debug.Log("Colided");
                if (slime2.harmable)
                {
                    slime2.health -= damageAmount;
                    slime2.harmable = false;
                }
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        List<Rigidbody2D> bones = slime1.bones;
        foreach (Rigidbody2D bone in bones)
        {
            if (collision.collider == bone.GetComponent<Collider2D>())
            {
                Debug.Log("Colided");
                if (slime1.harmable)
                {
                    slime1.health -= damageAmount;
                    slime1.harmable = false;
                }
            }
        }

        List<Rigidbody2D> bones2 = slime2.bones;
        foreach (Rigidbody2D bone in bones2)
        {
            if (collision.collider == bone.GetComponent<Collider2D>())
            {
                Debug.Log("Colided");
                if (slime2.harmable)
                {
                    slime2.health -= damageAmount;
                    slime2.harmable = false;
                }
            }
        }
    }
}
