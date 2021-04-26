using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class diary : MonoBehaviour
{ 
    public bool isdiary = false;
	public int getscore = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag=="Player") {
            //isdiary = true;
            AudioSource diarysounds = GameObject.Find("diarysound").GetComponent<AudioSource>();
            diarysounds.Play();
            this.gameObject.SetActive(false);
            GameObject.Find("MainCamera").GetComponent<scoremanager>().setdiarycounter();
			GameObject.Find("MainCamera").GetComponent<scoremanager>().changecontents(1);
			GameObject.Find("MainCamera").GetComponent<scoremanager>().setmessageAlpha(2);
			GameObject.Find("MainCamera").GetComponent<scoremanager>().setitemcounter();
			Button.instance.ChangeImageToDiary(scoremanager.instance.getitemcounter()-1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
