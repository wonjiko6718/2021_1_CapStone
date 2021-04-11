using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rumor : MonoBehaviour
{
    private Transform rumorTrans;
    private Rigidbody2D rumorRigid2D;
    private BoxCollider2D rumorCol2D;
    private GameObject rumorTarget;

    private float rumorMoveSpeed = 10.0f;
    private bool canJump = true;
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rumorTrans = GetComponent<Transform>();
        rumorRigid2D = GetComponent<Rigidbody2D>();
        rumorCol2D = GetComponent<BoxCollider2D>();

        rumorTrans.localScale = new Vector3(1f,1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        RumorMove();
        if(rumorCol2D.isTrigger == true) // attatch to player
        {
            rumorTrans.position = rumorTarget.GetComponent<Transform>().position;
        }
    }
    void RumorMove()
    {
        if(canJump == true)
        {
            StartCoroutine(RumorJumpDelay());
        }
        if(canMove == true)
        {
            StartCoroutine(RumorMoveDelay());
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player On rumor");
            rumorCol2D.isTrigger = true;
            rumorTarget = other.gameObject; // target to player
        }
    }
    IEnumerator RumorJumpDelay()
    {
        canJump = false;
        rumorRigid2D.AddForce(new Vector2(0.0f,300.0f));
        yield return new WaitForSeconds(1.5f); // RumorJumpDelay
        canJump = true;
        
    }
    IEnumerator RumorMoveDelay()
    {
        canMove = false;
        int rumorMoveDirection = Random.Range(-1,2); // -1,0,1 <- rumor move Direction
        if(rumorMoveDirection == -1)
        {
            rumorTrans.localScale = new Vector3(1f,1f,1f);
        }
        else if (rumorMoveDirection == 1)
        {
            rumorTrans.localScale = new Vector3(1f,1f,1f);
        }
        rumorRigid2D.AddForce(new Vector2(rumorMoveDirection * rumorMoveSpeed,0.0f)); // move
        yield return new WaitForSeconds(1.5f);
        canMove = true;
    }
}