using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerController : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 direction;
    private float speed = 3f;

    private int gift;
    [SerializeField] private TextMeshProUGUI textGiftCounter;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(direction.x * speed, body.velocity.y);
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
    }

    public void AddGift(int value)
    {
        gift += value;
        textGiftCounter.text = gift.ToString();
    }
}
