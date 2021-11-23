using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject menuSet;
    public GameObject player;
    public static int nownum;
    // Start is called before the first frame update
    void Start() {
        //GameLoad();
        if(nownum==1){
            GameLoad();
        }
    }

    // Update is called once per frame
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

    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.Save();


    }

    public void GameLoad()
    {
        /*
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;
            */
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        player.transform.position = new Vector3(x, y, 1);

    }
    public void MainMenu() {
        SceneManager.LoadScene("Title");
    }
    public void GameContinue() {
        menuSet.SetActive(false);

    }
    public void GameQuit() {
        Application.Quit();
    }
}
