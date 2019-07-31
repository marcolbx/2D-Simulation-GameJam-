using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveler : MonoBehaviour
{

    private SpriteRenderer spr;
    private Transform target;

    private float timer = 0.0f;

    public Sprite [] sprites;
    public DialogueTrigger dialogueTrigger;
    public GameObject canvasObject;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer> ();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector2.Distance(target.position,transform.position) < 1.4f)
        {
            timer += Time.deltaTime;
            canvasObject.GetComponent<Canvas>().enabled = true;
            if(timer>4f)
            {
            
            dialogueTrigger.TriggerDialogue();
            
                
                timer = 0;
            }
            
            
        }
        else
        {
            canvasObject.GetComponent<Canvas>().enabled = false;
        }
                
                
        if(target.position.y > transform.position.y && (Mathf.Abs(target.position.y - transform.position.y)) > 0.5f)
        {
            spr.sprite = sprites[1]; // Arriba
        }

        else if(target.position.y < transform.position.y && (Mathf.Abs(target.position.y - transform.position.y)) > 0.35f)
        {
            spr.sprite = sprites[2]; // Down
        }

        else if(target.position.x > transform.position.x)
        {
            spr.sprite = sprites[0]; // Derecha
            spr.flipX = false;
        }
        else
        {
            spr.sprite = sprites[0];  // Mirror derecha
                spr.flipX = true;
        } 
    }
}
