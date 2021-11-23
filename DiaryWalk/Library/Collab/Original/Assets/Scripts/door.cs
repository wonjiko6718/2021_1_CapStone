using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject Player;

    public Sprite newdoorSprite;
    public Sprite olddoorSprite;

    public GameObject InTarget; // In Portal
    public GameObject OutTarget; // out Portal

    public GameObject PlayerTarget; // Get Player Object

    public Transform InTarget_Trans;
    public Transform OutTarget_Trans;

    public GameObject needkey; // 문을 여는 데 필요한 열쇠

    SpriteRenderer olddoor;
    public bool mCanUsePortal = false;
    // Start is called before the first frame update
    void Start()
    {
        InTarget_Trans = GetComponent<Transform>();
        OutTarget_Trans = GetComponent<Transform>();

        InTarget = this.gameObject;
        InTarget_Trans = InTarget.transform;
        OutTarget_Trans = OutTarget.transform;
    }
    void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            changedoorsprite();
            isCanUsePortal();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            changedoorspriteback();
            mCanUsePortal = false;
        }
    }

    void changedoorsprite()
    {
        olddoor = this.gameObject.GetComponent<SpriteRenderer>();
        olddoor.sprite = newdoorSprite;
    }
    void changedoorspriteback()
    {
        olddoor = this.gameObject.GetComponent<SpriteRenderer>();
        olddoor.sprite = olddoorSprite;
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == Player && Input.GetKeyDown(KeyCode.E) && mCanUsePortal) // Player Push Portal
        {
            PlayerTarget = other.gameObject; // Get Player
            UsePortal();
        }
    }
    void UsePortal()
    {
        if (mCanUsePortal)
        {
            PlayerTarget.transform.SetPositionAndRotation(OutTarget_Trans.position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)); //위치 변경
        }
    }
    void isCanUsePortal()
    {
        for (int i = 0; i < 20; i++)
        {
            if (Player.GetComponent<Inventory>().items[i] != null)
            {
                if (Player.GetComponent<Inventory>().items[i].name == needkey.name)
                { //맞는 열쇠가 존재 시
                    mCanUsePortal = true;
                }
                else
                {
                    mCanUsePortal = false;
                }
            }
        }

    }
}
