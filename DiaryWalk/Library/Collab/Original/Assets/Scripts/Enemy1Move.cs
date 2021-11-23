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
    public int targetDirection;
    public int tp;
    private float thisTime = 0.0f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        target = Player.GetComponent<Transform>();
    }

    void Update()
    {
        if (anim.GetBool("Chasing"))
            FollowTarget();


        thisTime += Time.deltaTime;
        if (thisTime > 2)
        {
            randomMove();
        }

        if (this.rigid.velocity.x > 0.001f) //실시간으로 애니메이션 속도 최신화
        {
            anim.SetFloat("MoveSpeed", this.rigid.velocity.x * 100);
            spriteRenderer.flipX = false;
        }
        else if (this.rigid.velocity.x < -0.001f)
        {
            anim.SetFloat("MoveSpeed", -this.rigid.velocity.x*100);
            spriteRenderer.flipX = true;

        }
        else
        {
            anim.SetFloat("MoveSpeed", 0);
        }

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

      //  if (Vector2.Distance(transform.position, target.position) > contactDistance && follow)
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime * 0.5f);

            //float distance = Vector3.Distance(target.position, transform.position);

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject==Player)
        {
            anim.SetBool("Chasing", true);
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            anim.SetBool("Chasing", false);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            anim.SetBool("Chasing", false);
        }
    }


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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


    void randomMove()
    {
        nextMove = Random.Range(-1, 2);
        anim.SetFloat("MoveSpeed", nextMove);
        thisTime = 0.0f;
    }

}