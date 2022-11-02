using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    private bool sentidoDir = true;
    public float speed;
    private float timer;
    public float moveTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sentidoDir)
        {
            // se verdade vai para direta
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            // se verdade vai para esquerda
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        timer += Time.deltaTime;
        if(timer >= moveTime)
        {
            CountDown();
        }
        
    }
    void CountDown()
    {
        sentidoDir = !sentidoDir;
        timer = 0f;
    }
}
