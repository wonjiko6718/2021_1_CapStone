using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class itemdescription : MonoBehaviour {
    public GameObject description;
    public GameObject descText;
    bool activedescription = false;

    public void Start() {
        description.SetActive(activedescription);
        descText.GetComponent<Text>().color=Color.white;
        }
    public void Update() {
    }
    public void descUI() {
        string str = this.gameObject.name;
        string str2 = Regex.Replace(str, @"\D", ""); //button 0에서 0을 추출
        string itemname = GameObject.Find("Player").GetComponent<Inventory>().items[int.Parse(str2)].name;
            activedescription = !activedescription;
            description.SetActive(activedescription);
            if(itemname.Contains("열쇠")) {
                descText.GetComponent<Text>().text=itemname;
                descText.GetComponent<Text>().text+="입니다";
            }else if(itemname.Contains("다이어리")) {
                descText.GetComponent<Text>().text=itemname;
                descText.GetComponent<Text>().text+="입니다";
            }
    }


}

