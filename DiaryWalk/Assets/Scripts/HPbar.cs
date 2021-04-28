using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public float nowhp = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nowhp = GameObject.Find("Player").GetComponent<moveing>().Hp;
        this.gameObject.GetComponent<Slider>().value= nowhp/100;
    }
}
