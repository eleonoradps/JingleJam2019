using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{

    [SerializeField] float speedY = 5f;
    Rigidbody2D body;
    float posY = -4.5f;

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
}
