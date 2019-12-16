using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHorizMove : MonoBehaviour
{
    [SerializeField] private int maxSpeed = 5;

    [SerializeField] private int sizeThreshold = 0;

    [SerializeField] Sprite SmallSprite;

    [SerializeField] Sprite MediumSprite;

    [SerializeField] Sprite LargeSprite;

    private Rigidbody2D rb2d;

    private SpriteRenderer sprite;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        increaseTest();

        if (sizeThreshold <= 10)
        {
            //sprite.color = new Color(255, 0, 0, 255);
            sprite.sprite = SmallSprite;
            maxSpeed = 15;
        }
        else if (sizeThreshold >= 11 && sizeThreshold <= 20)
        {
            //sprite.color = new Color(0, 255, 0, 255);
            sprite.sprite = MediumSprite;
            maxSpeed = 10;
        }
        else if (sizeThreshold >= 21)
        {
            //sprite.color = new Color(0, 0, 255, 255);
            sprite.sprite = LargeSprite;
            maxSpeed = 5;
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 move = new Vector3(x * maxSpeed, rb2d.velocity.y, 0f);
        rb2d.velocity = move;
    }

    void increaseTest()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sizeThreshold += 1;
        }
    }

}
