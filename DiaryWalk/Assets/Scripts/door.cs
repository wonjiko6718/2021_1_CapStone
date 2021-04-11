using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {
    public Sprite newdoorSprite;
    public Sprite olddoorSprite;
    SpriteRenderer olddoor;
    // Start is called before the first frame update
    void Start() {
        
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
}
