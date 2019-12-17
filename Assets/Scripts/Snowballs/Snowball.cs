using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{

    [SerializeField] float speedY = 5f;
    Rigidbody2D body;
    float posY = -4.5f;
    private int snowVal = 1;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(0, speedY);
    }
    private void Update()
    {
        if (this.transform.position.y <= posY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collider.GetComponent<PlayerHorizMove>().GrowSize(snowVal);
            Destroy(gameObject);
        }
    }
}
