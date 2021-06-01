using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    public int nextMove;
    public GameObject Enemy1;
    public GameObject Player;
    SpriteRenderer spriteRenderer;
    Transform target;
    float moveSpeed = 3f;
    float contactDistance = 1f;
    bool follow = false;
    public int targetDirection;
    private Vector3 movement;
    public int tp;

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
        float DirCirculate = MosterX - PlayerX; // Moster Postion X - Player Position X
        if (DirCirculate >= 0)
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

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("Chasing");
            follow = true;
            if (targetDirection == 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (targetDirection == 1)
            {
                spriteRenderer.flipX = false;
            }
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

    private Vector3 getPosition()
    {
        int tp = Random.Range(0, 4);
        return new Vector3(12, (tp * 12 - 4), 0);
    }

    void teleport()
    {
        transform.position = getPosition();
    }

    void OnBecameInvisible()
    {
        if(enabled == true)
        {
            Invoke("teleport", 10f);
        }
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