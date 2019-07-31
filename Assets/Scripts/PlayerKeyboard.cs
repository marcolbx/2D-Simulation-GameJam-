using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboard : MonoBehaviour
{
    //Inspector 
    [SerializeField] float Vspeed = 1.5f;
    [SerializeField] float Hspeed = 1.5f;

    //Private
     Animator animator;
     private SpriteRenderer spr;
     private Sprite [] sprites;
     private float timer = 0;

     //Public
     public Collider2D collision;
     public Collider2D swordCollider; //ATK
     public GameObject sword;
     public AudioSource asGrab;
     public AudioClip collectible;
     private bool played = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer> ();
        sprites = Resources.LoadAll<Sprite> ("RobinHood");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 0.25f){
        swordCollider.enabled = false;
        sword.GetComponent<Collider2D>().enabled = false; 
        sword.transform.position = this.transform.position;
        }

        if (Input.GetKey("up"))
        {
            //print("up arrow key is held down");
             // Move the object forward along its z axis 1 unit/second.
            transform.Translate(Vector3.up * Time.deltaTime * Vspeed, Space.World);

            animator.SetInteger("Vertical", 1);
            animator.SetInteger("Idle Direction", 2);
            
        }

        else if (Input.GetKey("down"))
        {
           // print("down arrow key is held down");
            // Move the object upward in world space 1 unit/second.
            transform.Translate(Vector3.down * Time.deltaTime * Vspeed, Space.World);

            animator.SetInteger("Vertical",-1);
            animator.SetInteger("Idle Direction", 4);
        }

        else if (Input.GetKey("right"))
        {
           // print("right arrow key is held down");
            // Move the object upward in world space 1 unit/second.
            transform.Translate(Vector3.right * Time.deltaTime * Hspeed, Space.World);

            animator.SetInteger("Horizontal",1);
            animator.SetInteger("Idle Direction", 1);
            if (Input.GetKey(KeyCode.Space)){
                print("Space key is held down");
                animator.SetTrigger("Attack");
            }

           // animator.ResetTrigger("Attack");
        }

        else if (Input.GetKey("left"))
        {
           // print("left arrow key is held down");
            // Move the object upward in world space 1 unit/second.
            transform.Translate(Vector3.left * Time.deltaTime * Hspeed, Space.World);

            animator.SetInteger("Horizontal",-1);
            animator.SetInteger("Idle Direction", 3);
        }

        else
        {
            animator.SetInteger("Vertical",0);
            animator.SetInteger("Horizontal",0);

            if(Input.GetKey(KeyCode.Space))
            {
                timer = 0;
                sword.transform.position = this.transform.position;
                swordCollider.offset = new Vector2(0f, 0f);
                
                animator.SetTrigger("Attack");
                
                if(animator.GetInteger("Idle Direction") == 1){  
                    sword.transform.position = this.transform.position + new Vector3(0.90f,0f,0f);      
                    sword.GetComponent<Collider2D>().enabled = true;  
              //  swordCollider.transform.position = this.transform.position;
               // swordCollider.offset = swordCollider.offset + new Vector2(0.4f, 0f);
                //swordCollider.enabled = true;
                }

                if(animator.GetInteger("Idle Direction") == 2){ 
                sword.transform.position = this.transform.position + new Vector3(0f,0.90f,0f);  
                sword.GetComponent<Collider2D>().enabled = true;             
               // swordCollider.transform.position = this.transform.position;
               // swordCollider.offset = swordCollider.offset + new Vector2(0f, 0.4f);
               // swordCollider.enabled = true;
                }

                if(animator.GetInteger("Idle Direction") == 3){            
                    sword.transform.position = this.transform.position + new Vector3(-0.90f,0f,0f);   
                    sword.GetComponent<Collider2D>().enabled = true; 
              //  swordCollider.transform.position = this.transform.position;
               // swordCollider.offset = swordCollider.offset + new Vector2(-0.4f, 0f);
               // swordCollider.enabled = true;
                }

                if(animator.GetInteger("Idle Direction") == 4){         
                    sword.transform.position = this.transform.position + new Vector3(0f,-0.90f,0f);  
                    sword.GetComponent<Collider2D>().enabled = true;     
              //  swordCollider.transform.position = this.transform.position;
              //  swordCollider.offset = swordCollider.offset + new Vector2(0f, -0.4f);
              //  swordCollider.enabled = true;
                }

            }
        }

       

        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "CollectibleBanana")
        {
            asGrab.PlayOneShot(collectible, 0.7F);
        }
    }
}
