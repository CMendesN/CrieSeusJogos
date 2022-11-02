using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Rigidbody2D rig;
    private BoxCollider2D box;
    private CircleCollider2D circle;
    private Animator anim;
    public float speed;
    private float height;
    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;
    private bool colliding;
    private bool playerDestroyed = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new(speed, rig.velocity.y);
        colliding = Physics2D.Linecast(rightCol.position, leftCol.position);
        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            height = collision.contacts[0].point.y - headPoint.position.y;
            Debug.Log(collision.contacts[0].point.y);
            Debug.Log(headPoint.position.y);
            Debug.Log(height);
            if (height > 0.0119 && !playerDestroyed)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("die");
                box.enabled = false;
                circle.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.33f);
            }
            else
            {
                playerDestroyed = true;
                GameController.instance.GameOver();
                Destroy(collision.gameObject);
            }
        }
    }
}
