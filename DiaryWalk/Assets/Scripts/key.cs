using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class key: MonoBehaviour {

	public GameObject Camera;
	public bool iskey = false;
	public int getscore = 1;

	void Start() {

	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag=="Player") {
			keysound();
			this.gameObject.SetActive(false); //닿으면 비활성화
			keycounter();
			keyGUI();
			Button.instance.ChangeImageToKey(scoremanager.instance.getitemcounter()-1);
			keyactive();
			toinventory();
		}
	}
	void keysound() {
		AudioSource keysounds = GameObject.Find("keysound").GetComponent<AudioSource>();
        keysounds.Play();
	}
	void keycounter() {
		Camera.GetComponent<scoremanager>().setkeycounter();
		Camera.GetComponent<scoremanager>().setitemcounter();
	}
	void keyGUI() {
		Camera.GetComponent<scoremanager>().changecontentskeyget(this.gameObject.name);
		Camera.GetComponent<scoremanager>().setmessageAlpha(2);
	}
	void keyactive() {
		if(this.gameObject.name=="기술실열쇠") { //먹은 열쇠 이름이 기술실 열쇠라면 기술실열쇠 true
			keydiaryscore.instance.technicroomkey =true;
		}
		if(this.gameObject.name=="교장실열쇠") { //먹은 열쇠 이름이 기술실 열쇠라면 기술실열쇠 true
			keydiaryscore.instance.gyojangsilroomkey =true;
		}
	}
	void toinventory() {
		GameObject.Find("Player").GetComponent<Inventory>().inventoryadd(this.gameObject);
	}
	// Update is called once per frame
    void Update() {
        
    }
}
