using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurBoss : MonoBehaviour
{

    //Inspector 
    [SerializeField] float Vspeed = 1.5f;
    [SerializeField] float Hspeed = 1.5f;

    //Private
    private Animator animator;
    private Rigidbody2D rb;
    private int facing = 1;
    public int state = 0; //0: Idle, 1: normal ATK, 2: spinAtk, 3: Move
    private float timer = 0;
    private Vector2 velocity;

    //Public
    public AudioSource asHut;
    public AudioSource asDead; 
    public Sprite hurtSprite;
    //Va con asDead
    private bool played = false;
    public int health =22;
    public Collider2D collision;
    public Collider2D normalAtk;
    public Collider2D spinAtk;
    private Transform target;
    private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
      //  rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if(target.position.x < transform.position.x && health>0)
                sp.flipX = true;
                else
                {
                sp.flipX = false;
                }   
        if(health <= 0)
        {
            if(played == false)
            {
            asDead.Play();
            played = true;
            }
            collision.enabled = false;
                
        }
        animator.SetFloat("Health",health);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Sword")
        {
            sp.sprite = hurtSprite;
            asHut.Play();
            health-=1;
        }
    }
}
