using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGifts : MonoBehaviour
{
    [SerializeField] private int giftVal = 1;
    [SerializeField] float speedY = -5f;
    private SpriteRenderer spriteRenderer;
    Rigidbody2D body;
    float posY = -4.0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(0, speedY);
    }

    private void Update()
    {
        if (this.transform.position.y <= posY)
        {
            body.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
            collider.GetComponent<PlayerHorizMove>().CollectGift(giftVal);
        }
    }
}
