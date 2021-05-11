using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void StartGame() {
        gamemanager.nownum=0;
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadGame() {
        gamemanager.nownum=1;
        SceneManager.LoadScene("SampleScene");
        //DontDestroyOnLoad(LoadObject);
    }
    public void ExitGame() {
        Application.Quit();
    }
}
