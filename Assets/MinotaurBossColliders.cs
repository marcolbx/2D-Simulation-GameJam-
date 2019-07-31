using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurBossColliders : MonoBehaviour
{

    private Collider2D collider;
    public Transform target;
    public Transform minotaur; //follow 
    private Rigidbody2D rb;
    private float timer = 0f;
    private bool playerWasHit = false; 

    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >0.2f && playerWasHit == true)
        {
            rb.velocity = new Vector3(0,0,0);
            playerWasHit = false;
        }

        transform.position = minotaur.position;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Entro");
        if (col.gameObject.tag == "Player")
        {
           rb = col.gameObject.GetComponent<Rigidbody2D>();
            
             timer = 0;
            

            if(target.position.y > transform.position.y && (Mathf.Abs(target.position.y - transform.position.y)) > 0.5f)
        {
            rb.AddForce(target.up * 500f); // Arriba
        }

        else if(target.position.y < transform.position.y && (Mathf.Abs(target.position.y - transform.position.y)) > 0.35f)
        {
            rb.AddForce(target.up * -500f); // Down
        }

        else if(target.position.x > transform.position.x)
        {
            rb.AddForce(target.right * 500f); // Derecha
        }
        else
        {
            rb.AddForce(target.right * -500f);  // Mirror derecha
        } 
             playerWasHit = true;
        }
    }
}
