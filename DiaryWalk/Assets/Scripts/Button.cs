using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Image 선언하기 위해 임포트

public class Button : MonoBehaviour {

    public GameObject[] buttontemp;
    public Image diaryimage;
    public Image keyimage;
    public static Button instance; //싱글톤 선언
    void Awake(){
    Button.instance = this; //싱글톤 부여
        buttontemp = new GameObject[30];
        for(int i=0;i<10;i++) {
        buttontemp[i] = GameObject.Find("Button" + i.ToString()); //Button이라는 이름의 오브젝트들을 찾아서 배열에 넣음
        }
    }
    public void ChangeImageToDiary(int value) {
        buttontemp[value].GetComponent<Image>().sprite=diaryimage.sprite; //배열에 넣은 오브젝트의 이미지 컴포넌트의 스프라이트를 선언한 이미지의 스프라이트로 바꿈
        buttontemp[value].GetComponent<Image>().color=new Color(255,255,255,1);
    }
    public void ChangeImageToKey(int value) {
        buttontemp[value].GetComponent<Image>().sprite=keyimage.sprite;
        buttontemp[value].GetComponent<Image>().color=new Color(255,255,255,1);
    }

    void Update()
    {

    }
}

