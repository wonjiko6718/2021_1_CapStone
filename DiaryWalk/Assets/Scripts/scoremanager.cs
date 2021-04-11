using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoremanager : MonoBehaviour {
    public int diarycount = 0;
    public int keycount = 0;
    public int itemcount=0;
    public float messagealpha = 0;
    public string messagecontents ="";
    public float timer2 = 0.0f;
    public Texture2D diaryimage;
    public Texture2D keyimage;

    public static scoremanager instance; //싱글톤 선언
    void Awake() {
    scoremanager.instance = this; //싱글톤 부여
    }

    void FixedUpdate() { //게임 내내 실행되야 하므로 Update에 작성함
        timer2+=Time.deltaTime; //시간이 증가함에 따라 계속 증가
        if(timer2>0.05){ //0.05초가 되면
            minusmessageAlpha(10); //글자 점점 투명하게
            timer2=0; //다시 0으로 초기화(Update는 계속 실행되므로 for이나 while 쓸필요 X)
        }
    }

    public void changecontents(int value) {
        if (value ==1) {
            messagecontents=("Diary를 총 " + diarycount.ToString() +"개 획득하였습니다.");
        }
        if (value ==2) {
            messagecontents=("열쇠를 획득하였습니다.");
        }
        if (value ==3) {
            messagecontents=("열쇠를 사용하였습니다.");
        }

    }

    public void setmessageAlpha(int value) {
        messagealpha = value;
    }
    public void minusmessageAlpha(float value) {
        messagealpha -= value/200;
    }

    public void setdiarycounter() {
        diarycount+=1;
    }
    public int getdiarycounter() {
        return diarycount;
    }
    public void setkeycounter() {
        keycount+=1;
    }
    public int getkeycounter() {
        return keycount;
    }
    public void setitemcounter() {
        itemcount+=1;
    }
    public int getitemcounter() {
        return itemcount;
    }

    void OnGUI() {
        GUIStyle message = new GUIStyle(GUI.skin.label);
        message.fontSize = 36;
        message.normal.textColor=new Color(1,1,1,messagealpha);
        GUILayout.Label(messagecontents,message);
    }
}
