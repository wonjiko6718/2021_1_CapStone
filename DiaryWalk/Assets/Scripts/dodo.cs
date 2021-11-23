using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodo : MonoBehaviour
{
    public GameObject InTarget; // In Portal
    public GameObject OutTarget; // out Portal
    
    private GameObject PlayerTarget; // Get Player Object

    private Transform InTarget_Trans;
    private Transform OutTarget_Trans;

    // Start is called before the first frame update
    void Start()
    {
        InTarget_Trans = GetComponent<Transform>();
        OutTarget_Trans = GetComponent<Transform>();

        InTarget = this.gameObject;
        InTarget_Trans = InTarget.transform;
        OutTarget_Trans = OutTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && Input.GetKey(KeyCode.UpArrow)) // Player Push Portal
        {
            PlayerTarget = other.gameObject; // Get Player
            UsePortal();
        }
    }
    void UsePortal()
    {
        PlayerTarget.transform.SetPositionAndRotation(OutTarget_Trans.position,new Quaternion(0.0f,0.0f,0.0f,0.0f));
    }

}
