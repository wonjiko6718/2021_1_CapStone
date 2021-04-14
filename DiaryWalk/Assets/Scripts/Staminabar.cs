using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Staminabar : MonoBehaviour
{
    public float nowstamina = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nowstamina = GameObject.Find("Player").GetComponent<moveing>().stamina;
        this.gameObject.GetComponent<Slider>().value= nowstamina/50;
    }
}
