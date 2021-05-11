using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    public int nextMove;
    public GameObject Enemy;
    public GameObject Player;
    SpriteRenderer spriteRenderer;
    Transform target;
    float moveSpeed = 3f;
    float contactDistance = 1f;
    bool follow = false;
    string dist = "";
    public int targetDirection;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        float PlayerX = target.transform.position.x; // Player Position X
        float MosterX = this.transform.position.x; // Monster Position X
        float DirCirculate = MosterX-PlayerX; // Moster Postion X - Player Position X
        if(DirCirculate >= 0)
        {
            targetDirection = 0; // Left Direction
        }
        else
        {
            targetDirection = 1; // Right Direction
        }

        if (Vector2.Distance(transform.position, target.position) > contactDistance && follow)
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime * 0.4f);

            float distance = Vector3.Distance(target.position, transform.position);


    }

 /*   private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 moveVelocity = Vector3.zero;
        if (follow)
        {
            if (target.position.x < transform.position.x)
                dist = "Left";
            else if (target.position.x > transform.position.x)
                dist = "Right";
        }
        else
        {
            if (nextMove == -1)
                dist = "Left";
            else if (nextMove == 2)
                dist = "Right";
        }

        if(dist == "Left")
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dist == "Right")
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }*/


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("Chasing");
            follow = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("isWalking");
            follow = false;
            
        }
    }

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


    void Think()
    {
        nextMove = Random.Range(-1, 2);
        anim.SetInteger("MoveSpeed", nextMove);
        Invoke("Think", 3);
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == -1;
    }

}