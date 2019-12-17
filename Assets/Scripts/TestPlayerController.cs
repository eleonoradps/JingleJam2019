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
    [SerializeField] private float snowballSpeed = 10;

    private int gift; // à ajouter dans le player controller de Tristan
    [SerializeField] private TextMeshProUGUI textGiftCounter; // à ajouter dans le player controller de Tristan

    [SerializeField] GameObject prefabSnowball;
    [SerializeField] Transform snowballSpawnPoint;
    
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

        if(Input.GetAxis("Fire1") > 0.1f)
        {
            GameObject snowball = Instantiate(prefabSnowball, snowballSpawnPoint);
            snowball.transform.parent = null;

            snowball.GetComponent<Rigidbody2D>().velocity = Vector2.up * snowballSpeed;
            Destroy(snowball, 1);
        }

    }

    public void AddGift(int value) // à ajouter dans le player controller de Tristan
    {
        gift += value;
        textGiftCounter.text = gift.ToString();
    }
}
