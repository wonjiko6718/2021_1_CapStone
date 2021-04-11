using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport: MonoBehaviour
{
    public GameObject targetobject;

    public GameObject ToObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            targetobject = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && Input.GetKey(KeyCode.UpArrow))
        {
            StartCoroutine(TeleportRoutine());
        }
    }

    IEnumerator TeleportRoutine()
    {
        yield return null;
        targetobject.transform.position = ToObj.transform.position;
    }
}
