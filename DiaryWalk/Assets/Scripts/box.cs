using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class box : MonoBehaviour {
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public bool isbox = false;
    public bool boxused = false;
    public string keyname = "";
    public GameObject thisGO;
    //public static box instance; //싱글톤 선언
    // Start is called before the first frame update
    void Start()
    {
        //box.instance = this; //싱글톤 부여
        if (this.gameObject.name=="1층박스")
        keyname="학생회실 열쇠";
        thisGO = GameObject.Find(this.gameObject.name);
    }
   
    void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag=="Player") {
            isbox = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag=="Player") {
            isbox = false;
		  }
    }
    void toinventory() {
		GameObject.Find("Player").GetComponent<Inventory>().inventoryadd(item1); //아직 첫번째 아이템 넘기는 것만 구현 None이 아닐시 다음것도 넘기도록 if문 구현예정
	}

    public void boxinteract() {
        if (isbox==true) {
            if (boxused==false) {
                keysound();
                keycounter();
                keyGUI();
                Button.instance.ChangeImageToKey(scoremanager.instance.getitemcounter()-1);
                keyactive();
                toinventory();
                boxused=true;
            }

        }

    }
    void keysound() {
    AudioSource keysounds = GameObject.Find("keysound").GetComponent<AudioSource>();
    keysounds.Play();
    }
    void keycounter() {
		GameObject.Find("MainCamera").GetComponent<scoremanager>().setkeycounter();
		GameObject.Find("MainCamera").GetComponent<scoremanager>().setitemcounter();
	}
    void keyGUI() {
		GameObject.Find("MainCamera").GetComponent<scoremanager>().changecontentskeyget("상자에서 "+keyname);
        GameObject.Find("MainCamera").GetComponent<scoremanager>().setmessageAlpha(2);
	}
    void keyactive() {
        if(this.gameObject.name=="1층박스"){
            keydiaryscore.instance.studentroomkey=true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E)) {
            boxinteract();
        }

    }
}
