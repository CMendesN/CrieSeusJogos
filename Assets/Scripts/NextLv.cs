using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLv : MonoBehaviour
{
    AudioManager audioManager;
    public string sound;
    public GameObject fruits;
    public BoxCollider2D box;

    void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("no audiomanager found");

        }
        audioManager.PlaySound(sound);



    }
    private void Update()
    {
        if (!fruits)
        {
            box.enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioManager.StopSound(sound);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
}
