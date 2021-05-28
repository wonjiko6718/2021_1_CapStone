using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveing : MonoBehaviour
{
    float h;
    public float Hp = 100.0f;
    public float stamina = 50.0f;
    float Recoverystamina = 0;
    bool canWalk = true;
    bool playerHit = false;
    bool playerHit2 = false;
    bool isground = false;
    float noJump = 0;
    bool canjump = true;
    bool cancrouch = true;
    int playerHitStack = 0;
    float runspeed = 5;
    float jumpPower = 5f;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator ani;
    Transform PlayerTrans;
    CapsuleCollider2D PlayerCC2D;
   


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        PlayerTrans = GetComponent<Transform>();
        PlayerCC2D = GetComponent<CapsuleCollider2D>();
        Debug.Log("GameStart for test");
    }
    
    void Update()
    {
        playerDie();
        Jump();
        crouch();
        Ani();
    }
    
    void FixedUpdate()
    {        
        Move();
        staminaGauge();

        if(Mathf.Abs(rigid.velocity.x) > 0 || Mathf.Abs(rigid.velocity.y) > 0)
        {
            Recoverystamina=0;
        }

        if(Input.GetKey(KeyCode.LeftShift) && stamina > 0 && Mathf.Abs(rigid.velocity.x) > 0)
        {
            stamina -= 0.4f;
            Debug.Log(stamina);
        }

        else
        {
            Recovery();
        }
    }
     
    // collider Trigger method
    void OnTriggerStay2D(Collider2D other)
    {
        
        //적에게 닿았을때 
        if(other.gameObject.tag == "Enemy" && playerHit == false && Mathf.Abs(this.gameObject.transform.position.x - other.gameObject.transform.position.x) <= 1.75) 
        {
            OnDamaged(other.transform.position);
            Debug.Log("Hit!");
            Hp -= 5;
            Debug.Log(Hp);
            playerHitStack +=1;
            StartCoroutine(PlayerHitDelay());
            if(playerHitStack >= 3)
            {
                Object.Destroy(other.gameObject);
                playerHitStack = 0;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Hit" && playerHit2 == false)
        {
            OnDamaged(other.transform.position);
            Debug.Log("Hit!");
            Hp -= 20;
            Debug.Log(Hp);
            //Destroy(other.gameObject);
            StartCoroutine(PlayerHitDelay2());
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform")
        {
            cancrouch = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Platform")
        {
            cancrouch = false;
        }
    }

    void OnDamaged(Vector2 targetPos) // 넉백과 피격시 캐릭터 무적
    {
        gameObject.layer = 11;
        spriteRenderer.color = new Color(1,1,1,0.4f);
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc,1) * 2 , ForceMode2D.Impulse);
        ani.SetTrigger("doDamaged");
        Invoke("OffDamaged", 0.5f);
    }

    void OffDamaged() // 넉백 후 원상태
    {
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1,1,1,1);
    }

    IEnumerator PlayerHitDelay()
    {
        playerHit = true;
        yield return new WaitForSeconds(0.5f);
        playerHit = false;
    }

    IEnumerator PlayerHitDelay2()
    {
        playerHit2 = true;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(10.0f);
        Time.timeScale = 1f;
        playerHit2 = false;   
    }

    void Jump() // 점프 
    {
        if (Input.GetButtonDown("Jump") && !ani.GetBool("isjumping") && canjump == true && stamina >0.1) 
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            ani.SetBool("isjumping", true);
            cancrouch = false;
            ani.SetBool("isCrouch", false);
        }
    }
    
    void Ani() // 애니메이션 
    {
        if(Mathf.Abs(rigid.velocity.x) < 0.3) {
        ani.SetBool("isWalk", false);
        }
        else 
        {
        ani.SetBool("isWalk", true);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && stamina >0) 
        {
            ani.SetBool("isRunning", true);
            ani.SetBool("isWalk", false);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            ani.SetBool("isRunning", false);
            ani.SetBool("isWalk", true);
        }
        

        if(rigid.velocity.y == 0) 
        {  
            ani.SetBool("isjumping", false);         
        }
    }

    void Move() // 걷기 , 뛰기, 좌우 반전
    {
        //Move by control 플레이어 이동 
        float h = Input.GetAxisRaw("Horizontal");
        if(canWalk == true)
        {
            rigid.velocity = new Vector2(h * runspeed , rigid.velocity.y);
            if(Input.GetKey(KeyCode.LeftShift) && stamina > 0) // 뛰기
            {
                if(rigid.velocity.y != 0) // 공중 행동중일 경우
                {
                    ani.SetBool("isRunning",false); // 달리기 애니메이션 무시
                }
                else // 공중 행동이 종료되었을 경우
                {
                    ani.SetBool("isRunning", true); // 달리기 애니메이션 재생
                }
            runspeed = 5;
            cancrouch = false; // 달리는 동안 앉기 무시
            }
            else 
            {
            runspeed = 2;
            cancrouch = true; // 달리기 종료 시 앉기 가능 설정
            }
        }
        if (Input.GetButton("Horizontal")) // 좌우 반전 
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

    }

    void crouch() // 앉기
    {        
        if(Input.GetButtonDown("Crouch") && cancrouch == true) 
        {
            rigid.velocity = new Vector2(0.0f,0.0f);
            gameObject.transform.position -= new Vector3(0, 0.8f ,0);
            PlayerCC2D.size = new Vector3(0.6f,0f,2.0f);
            canjump = false;
            canWalk = false;
            ani.SetBool("isCrouch", true);
        }

        else if(Input.GetButtonUp("Crouch") && cancrouch == true)
        {
            gameObject.transform.position += new Vector3(0, 0.6f ,0);
            canWalk = true;
            canjump = true;
            PlayerCC2D.size = new Vector3(0.6f,2.0f,2.0f);
            ani.SetBool("isCrouch", false);
        }
    }

    void playerDie()
    {
        if (Hp == 0)
        {
            gameObject.SetActive(false);
            Debug.Log("죽었습니다.");
        }
    }

    void staminaGauge()
    {
        if (stamina <= 0)
        {
            stamina = 0;
        }
        if (stamina >= 50)
        {
            stamina = 50;
        }
    }

    void Recovery()
    {
        if (stamina >= 50)
        {
            Recoverystamina = 0; // 스태미나 50이상일때 회복 시간이 흐르지 않음 
            return;
        }
        Recoverystamina += Time.fixedDeltaTime; // 회복시간 누적
        if(Recoverystamina > 3)
        {
            stamina += 0.2f; // 회복시간이 3초를 넘어갈때마다 0.2씩 회복
            Debug.Log(stamina);  
        }
        
        if (stamina <= 50)
        {
            runspeed = 2;
        }

        if (stamina >= 50 && Input.GetButtonDown("Jump") && !ani.GetBool("isjumping") && canjump == true)
        {
            canjump = true;
        }    
 
    }

  
}