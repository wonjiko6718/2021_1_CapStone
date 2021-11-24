using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject menuSet;
    public GameObject player;
    public static string[] itemname = new string[30];
    public static int nownum;
    bool activemenuset = false;
    // Start is called before the first frame update
    void Start()
    {
        //GameLoad();
        if (nownum == 0)
        {
            GameStart();
        }
        if (nownum == 1)
        {
            GameLoad();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            activemenuset = !activemenuset;
            menuSet.SetActive(activemenuset);
        }
    }
    public void GameStart()
    {
        
        for(int i=0;i<20;i++) {
            PlayerPrefs.SetString("Inventory"+i, ""); //인벤토리 초기화
            
        }
    }
    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        for (int i = 0; i < 20; i++)
        {

            itemname[i] = Inventory.instance.items[i].gameObject.name;
            if (itemname[i] != "")
            {
                PlayerPrefs.SetString("Inventory" + i, itemname[i]);
            }
        }

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

        string[] s = new string[20];
        for (int j = 0; j < 20; j++)
        {
            s[j] = PlayerPrefs.GetString("Inventory" + j);
            GameObject.Find("Player").GetComponent<Inventory>().inventoryadd(GameObject.Find(s[j]));
            if (s[j].Contains("다이어리"))
            {
                GameObject.Find("MainCamera").GetComponent<scoremanager>().setdiarycounter();
                GameObject.Find("MainCamera").GetComponent<scoremanager>().setitemcounter();
                Button.instance.ChangeImageToDiary(scoremanager.instance.getitemcounter() - 1);
                GameObject.Find(s[j]).gameObject.SetActive(false);
            }
            else if (s[j].Contains("열쇠"))
            {
                GameObject.Find("MainCamera").GetComponent<scoremanager>().setkeycounter();
                GameObject.Find("MainCamera").GetComponent<scoremanager>().setitemcounter();
                Button.instance.ChangeImageToKey(scoremanager.instance.getitemcounter() - 1);
                GameObject.Find(s[j]).gameObject.SetActive(false);
            }
        }

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Title");
    }
    public void GameContinue()
    {
        menuSet.SetActive(false);

    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
