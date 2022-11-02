using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer render;
    private CircleCollider2D circle;
    public GameObject collected;
    private int score = 1;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag  =="Player")
        {
            render.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);
            GameController.instance.total += score;
            GameController.instance.UpdateScoreText();
            Destroy(gameObject, 0.35f);
        }
        

    }
}
