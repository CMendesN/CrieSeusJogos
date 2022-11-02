using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLv : MonoBehaviour
{
    public string proximo;
    public GameObject fruits;
    public BoxCollider2D box;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }

    public void Nextlv(string lv)
    {
        SceneManager.LoadScene(lv);
    }
}
