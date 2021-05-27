using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {
    public Sprite newdoorSprite;
    public Sprite olddoorSprite;

    public GameObject InTarget; // In Portal
    public GameObject OutTarget; // out Portal
    
    private GameObject PlayerTarget; // Get Player Object

    private Transform InTarget_Trans;
    private Transform OutTarget_Trans;

    public GameObject needkey; // 문을 여는 데 필요한 열쇠

    SpriteRenderer olddoor;
    // Start is called before the first frame update
    void Start() {
        InTarget_Trans = GetComponent<Transform>();
        OutTarget_Trans = GetComponent<Transform>();

        InTarget = this.gameObject;
        InTarget_Trans = InTarget.transform;
        OutTarget_Trans = OutTarget.transform;
    }
    public static door instance; //싱글톤 선언
    void Awake() {
    door.instance = this; //싱글톤 부여
    }
    // Update is called once per frame
    void Update() {
        
    }
    void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag=="Player") {
            changedoorsprite();
		}
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag=="Player") {
            changedoorspriteback();
		  }
    }

    void changedoorsprite() {
      olddoor = this.gameObject.GetComponent<SpriteRenderer>();
        olddoor.sprite = newdoorSprite;
    }
    void changedoorspriteback() {
      olddoor = this.gameObject.GetComponent<SpriteRenderer>();
        olddoor.sprite = olddoorSprite;
    }
    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E)) // Player Push Portal
        {
            PlayerTarget = other.gameObject; // Get Player
            UsePortal();
        }
    }
    void UsePortal() {
        for(int i=0;i<20;i++){
            if(Inventory.instance.items[i].name==needkey.name){
                PlayerTarget.transform.SetPositionAndRotation(OutTarget_Trans.position,new Quaternion(0.0f,0.0f,0.0f,0.0f));
            }
        }
    }
}
