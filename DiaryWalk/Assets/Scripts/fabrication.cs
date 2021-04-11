using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabrication : MonoBehaviour
{
    private Transform fabricationTransform;
    private Rigidbody2D fabricationRigid2D;
    private BoxCollider2D fabricationBoxCollider2D;
    private SpriteRenderer fabricationSpriteRenderer;
    private int SpawnCount = 0;
    private bool canSpawn = false;

    public Sprite[] fabricationSaveSprite;
    public GameObject fabricationSpawnedRumor;

    // Start is called before the first frame update
    void Start()
    {
        fabricationTransform = GetComponent<Transform>();
        fabricationRigid2D = GetComponent<Rigidbody2D>();
        fabricationBoxCollider2D = GetComponent<BoxCollider2D>();
        fabricationSpriteRenderer = GetComponent<SpriteRenderer>();
        fabricationTransform.localScale = new Vector3(2,2,2);
        fabricationBoxCollider2D.size = new Vector2(4.0f,6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(canSpawn == true && SpawnCount <= 2)
        {
            StartCoroutine(SpawnRumorDelay());
        }
        if(SpawnCount == 3)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canSpawn = true;
        }
    }
    IEnumerator SpawnRumorDelay()
    {
        canSpawn = false;
        fabricationSpriteRenderer.sprite = fabricationSaveSprite[1];
        GameObject spawningRumor = Instantiate(fabricationSpawnedRumor,transform.position,Quaternion.identity);
        SpawnCount ++;
        yield return new WaitForSeconds(1.5f);
        canSpawn = true;
    }
}