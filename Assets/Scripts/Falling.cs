using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public float time;
    private TargetJoint2D target;
    private BoxCollider2D boxCool;
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxCool = GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", time);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
    void Fall()
    {
        target.enabled = false;
        boxCool.isTrigger = true;
    }
}
