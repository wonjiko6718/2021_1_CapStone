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
    public GameObject Blood;

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
        {
            anim.SetTrigger("Screaming");
                        
            AudioSource enemysounds = GameObject.Find("enemysound").GetComponent<AudioSource>();
            enemysounds.Play();
            StartCoroutine(motionBombStart());

        }
    }

    void Think()
    {
        nextMove = Random.Range(-1 , 2);

        anim.SetInteger("MoveSpeed", nextMove);
        Invoke("Think", 3);
        if(nextMove != 0)
        spriteRenderer.flipX = nextMove == -1;
    }
    IEnumerator motionBombStart()
    {
        yield return new WaitForSeconds(0.5f); //0.5초 후 타격이펙트 생성
        this.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0); //잠시 투명
        Instantiate(Blood, this.transform.position, this.transform.rotation); //타격이펙트 소환

        yield return new WaitForSeconds(0.5f); //0.5초 대기
        Destroy(this); //자신을 Destroy하여 메모리 확보
    }


}