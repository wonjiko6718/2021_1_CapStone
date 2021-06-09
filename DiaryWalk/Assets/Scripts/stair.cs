using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stair : MonoBehaviour
{
    public Sprite newdoorSprite;
    public Sprite olddoorSprite;
    public GameObject InTarget; // In Portal
    public GameObject OutTarget; // out Portal
    
    public GameObject PlayerTarget; // Get Player Object

    public Transform InTarget_Trans;
    public Transform OutTarget_Trans;

    SpriteRenderer olddoor;
    // Start is called before the first frame update
    void Start()
    {
        InTarget_Trans = GetComponent<Transform>();
        OutTarget_Trans = GetComponent<Transform>();

        InTarget = this.gameObject;
        InTarget_Trans = InTarget.transform;
        OutTarget_Trans = OutTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E)) // Player Push Portal
        {
            PlayerTarget = other.gameObject; // Get Player
            PlayerTarget.transform.SetPositionAndRotation(OutTarget_Trans.position,new Quaternion(0.0f,0.0f,0.0f,0.0f));
        }
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
