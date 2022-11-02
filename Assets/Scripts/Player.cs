using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
    private Rigidbody2D rig;
    private Animator anim;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("no audiomanager found");

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (anim.GetBool("Move"))
        {
            
        }
        Jump();
    }
    void Move(){
        Vector3 movement = new(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += Speed * Time.deltaTime * movement;
        if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("Move", true);
            transform.eulerAngles = new(0f, 180f, 0f);
        }
        if (Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("Move", true);
            transform.eulerAngles = new(0f, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") == 0f) anim.SetBool("Move", false);
    }
    void Jump(){
        if(Input.GetButtonDown("Jump") ){
            if(!isJumping){
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("Jump", true);
            }
            else{
                if(doubleJump){
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
            
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            isJumping = false;
            anim.SetBool("Jump", false);
        }
        if (collision.gameObject.tag == "Spike")
        {
            audioManager.PlaySound("Impaled");
            audioManager.PlaySound("Death1");
            GameController.instance.GameOver();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Saw"))
        {
            audioManager.PlaySound("Death2");
            GameController.instance.GameOver();
            Destroy(gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            isJumping = true;
        }
    }

}   
