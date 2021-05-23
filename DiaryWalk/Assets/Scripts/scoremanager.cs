using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoremanager : MonoBehaviour {
    public int diarycount = 0;
    public int keycount = 0;
    public int itemcount=0;
    public float messagealpha = 0;
    public string messagecontents ="";
    public float timer2 = 0.0f;
    public Texture2D diaryimage;
    public Texture2D keyimage;
    public GameObject menuSet;
    public GameObject player;


    public static scoremanager instance; //싱글톤 선언


    void Start()
    {
        GameLoad();

    }


    void Awake() {
    scoremanager.instance = this; //싱글톤 부여
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {   //서브메뉴
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
        }
            
    }

    void FixedUpdate() { //게임 내내 실행되야 하므로 Update에 작성함
        timer2+=Time.deltaTime; //시간이 증가함에 따라 계속 증가
        if(timer2>0.05){ //0.05초가 되면
            minusmessageAlpha(10); //글자 점점 투명하게
            timer2=0; //다시 0으로 초기화(Update는 계속 실행되므로 for이나 while 쓸필요 X)
        }
    }
    public void changecontentsdiaryget() {
        messagecontents=("Diary를 총 " + diarycount.ToString() +"개 획득하였습니다.");
    }
    public void changecontentskeyget(string name) {
        messagecontents=(name+"를 획득하였습니다.");
    }
    public void changecontentskeyuse(string name) {
        messagecontents=(name+"를 사용하였습니다.");
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
        GUIStyle message = new GUIStyle(GUI.skin.label); //message 이름으로 GUI설정값들을 모아놓는 GUIStyle 선언
        message.fontSize = 36;
        message.normal.textColor=new Color(1,1,1,messagealpha);
        GUI.Label (new Rect (0,500,1000,300), messagecontents, message);
    }
    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.Save();


    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        player.transform.position = new Vector3(x, y, 0);

    }

    public void GameExit()
    {
        Application.Quit();
    }
}
