using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftBehaviour : MonoBehaviour
{

	[SerializeField] private int value;
	[SerializeField] private float fallingSpeed;
	[SerializeField] private Rigidbody2D m_body;

	[SerializeField] private float timer = 0.0f;
	[SerializeField] private float timerDuration;

	[SerializeField] private SpriteRenderer m_sprite;

	private bool grounded = false;

	void Start()
    {
		m_body.velocity = new Vector2(0,-fallingSpeed);
    }

    void Update()
    {
		if (grounded)
		{
			timer += Time.deltaTime;
			Color newColor = new Color(1, 1, 1, 1 - (timer / timerDuration));
			m_sprite.color = newColor;
			if (timer >= timerDuration)
			{
				Destroy(gameObject);
			}
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!grounded)
		{
			if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
			{
				m_body.velocity = Vector2.zero;
				grounded = true;
			}
		}

		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
		{		
			collision.GetComponent<PlayerMovement>().AddScore(value);
			Destroy(gameObject);
		}
	}
}
