using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
    public GameObject InventoryPanel;
    bool activeinventory = false;

    private void Start() {
        InventoryPanel.SetActive(activeinventory);
        }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            activeinventory = !activeinventory;
            InventoryPanel.SetActive(activeinventory);
        }
    }


}

