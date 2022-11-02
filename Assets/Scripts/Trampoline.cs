using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float jumpForce;
    private Animator anim;
    AudioManager audioManager;
    void Start()
    {
        anim = GetComponent<Animator>();
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("no audiomanager found");

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("jump");
            audioManager.PlaySound("Tramp");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
