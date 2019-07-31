using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplayPosition : MonoBehaviour
{

    public MinotaurBoss minotaur;
    public Sprite[] sprites;

    private SpriteRenderer spriteR;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = minotaur.transform.position + new Vector3(0.5f,1.7f,0f);
        if(minotaur.health == 21)
        spriteR.sprite = sprites[1];
        if(minotaur.health == 20)
        spriteR.sprite = sprites[2];
        if(minotaur.health == 19)
        spriteR.sprite = sprites[3];
        if(minotaur.health == 18)
        spriteR.sprite = sprites[4];
        if(minotaur.health == 17)
        spriteR.sprite = sprites[5];
        if(minotaur.health == 16)
        spriteR.sprite = sprites[6];
        if(minotaur.health == 15)
        spriteR.sprite = sprites[7];
        if(minotaur.health == 14)
        spriteR.sprite = sprites[8];
        if(minotaur.health == 13)
        spriteR.sprite = sprites[9];
        if(minotaur.health == 12)
        spriteR.sprite = sprites[10];
        if(minotaur.health == 11)
        spriteR.sprite = sprites[11];
        if(minotaur.health == 10)
        spriteR.sprite = sprites[12];
        if(minotaur.health == 9)
        spriteR.sprite = sprites[13];
        if(minotaur.health == 8)
        spriteR.sprite = sprites[14];
        if(minotaur.health == 7)
        spriteR.sprite = sprites[15];
        if(minotaur.health == 6)
        spriteR.sprite = sprites[16];
        if(minotaur.health == 5)
        spriteR.sprite = sprites[17];
        if(minotaur.health == 4)
        spriteR.sprite = sprites[18];
        if(minotaur.health == 3)
        spriteR.sprite = sprites[19];
        if(minotaur.health == 2)
        spriteR.sprite = sprites[20];
        if(minotaur.health == 1)
        spriteR.sprite = sprites[21];
        if(minotaur.health <= 0)
        spriteR.sprite = sprites[22];

    }
}
