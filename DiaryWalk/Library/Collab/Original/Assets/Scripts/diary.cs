using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class diary : MonoBehaviour {

    public string itemName = "";
    public string itemDescription = "";
    public bool isdiary = false;
	public int getscore = 1;
    public GameObject Camera;
    public GameObject Player;

    void Start() {
    }
   
    void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag=="Player") {
            //isdiary = true;
            diarysound();
            diarycounter();
            this.gameObject.SetActive(false);
			diaryGUI();
			Button.instance.ChangeImageToDiary(scoremanager.instance.getitemcounter()-1);
            diaryactive();
            toinventory();
        }
    }
    void diarysound() {
        AudioSource diarysounds = GameObject.Find("diarysound").GetComponent<AudioSource>();
        diarysounds.Play();
    }
    void diarycounter() {
        Camera.GetComponent<scoremanager>().setdiarycounter();
        Camera.GetComponent<scoremanager>().setitemcounter();
    }
    void diaryGUI() {
        Camera.GetComponent<scoremanager>().changecontentsdiaryget();
        Camera.GetComponent<scoremanager>().setmessageAlpha(2);
    }
    void diaryactive() {
        if(this.gameObject.name=="diary1") { //먹은 열쇠 이름이 기술실 열쇠라면 기술실열쇠 true
            keydiaryscore.instance.diary1 =true;
        }
    }
    void toinventory() {
		Player.GetComponent<Inventory>().inventoryadd(this.gameObject);
	}
    // Update is called once per frame
    void Update() {
        
    }
}
