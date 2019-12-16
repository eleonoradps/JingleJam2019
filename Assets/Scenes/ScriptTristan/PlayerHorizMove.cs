using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHorizMove : MonoBehaviour
{
    [SerializeField] private int maxSpeed = 15;

    private Vector2 Velocity;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(x * maxSpeed, rb2d.velocity.y, 0f);
        rb2d.velocity = move;
    }
}
