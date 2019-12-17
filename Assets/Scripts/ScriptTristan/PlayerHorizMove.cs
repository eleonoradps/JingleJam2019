using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHorizMove : MonoBehaviour
{
    [SerializeField] private int maxSpeed = 15;

    [SerializeField] private int sizeValue = 0;

    [SerializeField] private int threshold1 = 10;

    [SerializeField] private int threshold2Min = 11;

    [SerializeField] private int threshold2Max = 20;

    [SerializeField] private int threshold3Min = 21;

    [SerializeField] private int threshold3Max = 30;

    [SerializeField] private int threshold4 = 31;

    [SerializeField] private Sprite SmallSprite;

    [SerializeField] private Sprite MediumSprite;

    [SerializeField] private Sprite LargeSprite;

    [SerializeField] private Sprite SnowmanSprite;

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
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 move = new Vector2(x * maxSpeed, rb2d.velocity.y);
        rb2d.velocity = move;
    }

    void increaseTest()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sizeValue += 1;

            if (sizeValue <= threshold1)
            {
                //sprite.color = new Color(255, 0, 0, 255);
                sprite.sprite = SmallSprite;
                maxSpeed = 15;
            }
            else if (sizeValue >= threshold2Min && sizeValue <= threshold2Max)
            {
                //sprite.color = new Color(0, 255, 0, 255);
                sprite.sprite = MediumSprite;
                maxSpeed = 10;
            }
            else if (sizeValue >= threshold3Min && sizeValue <= threshold3Max)
            {
                //sprite.color = new Color(0, 0, 255, 255);
                sprite.sprite = LargeSprite;
                maxSpeed = 5;
            }
            else if (sizeValue >= threshold4)
            {
                sprite.sprite = SnowmanSprite;
                maxSpeed = 1;
            }
        }
    }
}
