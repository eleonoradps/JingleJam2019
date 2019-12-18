using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PereNoel : MonoBehaviour
{


	[SerializeField] private float lowerMotionRange;
	[SerializeField] private float higherMotionRange;

	[SerializeField] private float motionSpeed;
	[SerializeField] private float oscSpeed;
	[SerializeField] private float oscRange;

	private float initialHeight;

	private Rigidbody2D m_body;

	private Vector3 right = new Vector3(1, 0, 0);
	private Vector3 goingRight = new Vector3(1, 1, 1);
	private Vector3 goingLeft = new Vector3(-1, 1, 1);

	private SpriteRenderer m_sprite;

	private float blinkDelay = 0.1f;
	private float blinkDelayTimer = 0.0f;


	[SerializeField] private bool blinking = false;
	private bool blinkState = false;
	private float blinkDurationTimer;
	private float currentBlinkDuration;

	[SerializeField] private float blinkHitDuration;

	private Color baseColor;
	[SerializeField] private Color blinkColor;


	void Start()
    {
		m_sprite = GetComponent<SpriteRenderer>();
		m_body = GetComponent<Rigidbody2D>();
		initialHeight = transform.position.y;
		m_body.velocity = - motionSpeed * right;
		transform.localScale = goingLeft;
		baseColor = m_sprite.color;
	}


    void Update()
    {
		if (transform.position.x < lowerMotionRange)
		{
			m_body.velocity = motionSpeed * right;
			transform.localScale = goingRight;
		}

		if (transform.position.x > higherMotionRange)
		{
			m_body.velocity = - motionSpeed * right;
			transform.localScale = goingLeft;
		}

		float osc = Mathf.Sin(Time.time * oscSpeed) * oscRange;
		transform.position = new Vector3(transform.position.x, initialHeight + osc, 0);


		if (blinking)
		{
			if (blinkDurationTimer <= currentBlinkDuration)
				blinkDurationTimer += Time.deltaTime;
			else
			{
				blinkDurationTimer = 0;
				blinking = false;
				blinkState = false;
				m_sprite.color = baseColor;
			}

			if (blinkDelayTimer < blinkDelay)
				blinkDelayTimer += Time.deltaTime;
			else
			{
				blinkDelayTimer = 0;
				if (blinkState)
				{
					blinkState = false;
					m_sprite.color = baseColor;
				}
				else
				{
					blinkState = true;
					m_sprite.color = blinkColor;
				}
			}
		}
	}

	private void GetHit()
	{
		currentBlinkDuration = blinkHitDuration;
		blinking = true;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("SnowBullet"))
		{
			GetHit();
			Destroy(collision.gameObject);
		}
	}
}
