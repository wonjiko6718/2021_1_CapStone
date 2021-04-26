using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    public int nextMove;
    public GameObject Enemy;
    public GameObject Player;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("Think", 3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
    
     }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            anim.SetTrigger("Screaming");
            Destroy(gameObject,.60f);
    }

    void Think()
    {
        nextMove = Random.Range(-1 , 2);

        anim.SetInteger("MoveSpeed", nextMove);
        Invoke("Think", 3);
        if(nextMove != 0)
        spriteRenderer.flipX = nextMove == -1;
    }

}