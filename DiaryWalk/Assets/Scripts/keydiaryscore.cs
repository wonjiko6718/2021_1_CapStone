using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keydiaryscore : MonoBehaviour {
    public static keydiaryscore instance;
    public bool diary1 = false;
    public bool diary2 = false;
    public bool diary3 = false;
    public bool diary4 = false;
    public bool diary5 = false;
    public bool diary6 = false;
    public bool door1key = false;
	public bool door2key = false;
	public bool door3key = false;
	public bool door4key = false;
	public bool studentroomkey = false;
	public bool gyojangsilroomkey = false;
	public bool technicroomkey = false;

    // Start is called before the first frame update
    void Start()
    {
        keydiaryscore.instance=this;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
