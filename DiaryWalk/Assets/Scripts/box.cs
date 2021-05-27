using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class box : MonoBehaviour {
    public GameObject [] boxitems = new GameObject[10];
    public bool isbox = false;
    public bool boxused = false;
    public GameObject thisGO;
    //public static box instance; //싱글톤 선언
    // Start is called before the first frame update
    void Start()
    {
        //box.instance = this; //싱글톤 부여
        if (this.gameObject.name=="1층박스")
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
        for(int i=0;i<10;i++) {
            if(boxitems[i]!=null){
                GameObject.Find("Player").GetComponent<Inventory>().inventoryadd(boxitems[i]);
                if(boxitems[i].name.Contains("열쇠")) {
                    keycounter();
                    Button.instance.ChangeImageToKey(scoremanager.instance.getitemcounter()-1);
                }else if(boxitems[i].name.Contains("다이어리")) {
                    keycounter();
                    Button.instance.ChangeImageToDiary(scoremanager.instance.getitemcounter()-1);
                }
            }
        }
	}

    public void boxinteract() {
        if (isbox==true) {
            if (boxused==false) {
                keysound();
                keyGUI();
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
		GameObject.Find("MainCamera").GetComponent<scoremanager>().changecontentskeyget("상자에서 물품(을)");
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
