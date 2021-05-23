using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject [] items = new GameObject[20];
    public int count = 0;
    public static Inventory instance;

    void Start() {
        Inventory.instance=this;
    }

    // Update is called once per frame
    void Update() {
        
    }
    public void inventoryadd(GameObject a) {
        items[count] = a;
        count+=1;
    }
}
