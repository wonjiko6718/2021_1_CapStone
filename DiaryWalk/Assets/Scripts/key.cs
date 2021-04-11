using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class key: MonoBehaviour {
	
	public bool iskey = false;
	public int getscore = 1;

	void start(){
	}
	
	void OnTriggerEnter2D (Collider2D other) { //출돌감지 Collider 사용할 때 이름도 이렇게 지어줘야 함 ㅄ유니티
		if (other.gameObject.tag=="Player") { //닿은 오브젝트의 태그가 Player라면
			//iskey = true;
			AudioSource keysounds = GameObject.Find("keysound").GetComponent<AudioSource>();
            keysounds.Play();
			this.gameObject.SetActive(false); //닿으면 비활성화
			GameObject.Find("MainCamera").GetComponent<scoremanager>().setkeycounter();
			GameObject.Find("MainCamera").GetComponent<scoremanager>().changecontents(2);
			GameObject.Find("MainCamera").GetComponent<scoremanager>().setmessageAlpha(2);
			GameObject.Find("MainCamera").GetComponent<scoremanager>().setitemcounter();
			Button.instance.ChangeImageToKey(scoremanager.instance.getitemcounter()-1);
		}
            
	}

}
