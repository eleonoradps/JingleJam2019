using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGifts : MonoBehaviour
{
    [SerializeField] private int value = 1;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
            collider.GetComponent<TestPlayerController>().AddGift(value);
        }

    }

    
}
