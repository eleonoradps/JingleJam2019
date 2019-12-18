using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody2D m_body;

	[SerializeField] private Acceleration m_acceleration;
	[SerializeField] private Situation m_situation;

	[SerializeField] private float horizontalTreshold;

	[SerializeField] private float speed;
	[SerializeField] private float airSpeedRatio;

	private Vector2 left = new Vector2(-1, 0);
	private Vector2 right = new Vector2(1, 0);

	private int score;
	[SerializeField] private float size;

	[SerializeField] private int min;
	[SerializeField] private int max;


	[SerializeField] private float divider = 40;
	[SerializeField] private float scaller = 1;

	[SerializeField] private int thresholdMedium = 10;
	[SerializeField] private int thresholdBig = 11;
	[SerializeField] private int thresholdTooBig = 30;

	[SerializeField] private Sprite SmallSprite;
	[SerializeField] private Sprite MediumSprite;
	[SerializeField] private Sprite BigSprite;
	[SerializeField] private Sprite TooBigSprite;

	[SerializeField] private TextMeshProUGUI textGiftCounter;

	[SerializeField] GameObject prefabSnowball;
	[SerializeField] Transform snowballSpawnPoint;
	private SpriteRenderer sprite;

	private float snowballSpeed = 10;

	private float currentSpeed;


	[SerializeField] private float speedMedium;
	[SerializeField] private float speedBig;
	[SerializeField] private float speedTooBig;

	[SerializeField] private CircleCollider2D m_collider;

	private Size m_size = Size.Small;

	private float collSmall = 1;
	private float collMedium = 0.65f;
	private float collBig = 0.35f;
	private float collTooBig = 0.3f;

	[SerializeField] private GameObject spriteHolder;

	private enum Acceleration
	{
		None,
		Left,
		Right
	}

	private enum Situation
	{
		Grounded,
		InAir
	}

	private enum Size
	{
		Small,
		Medium,
		Big,
		Toobig
	}

	private void Start()
	{
		currentSpeed = speed;
		sprite = GetComponentInChildren<SpriteRenderer>();
		sprite.sprite = SmallSprite;
	}

	void Update()
    {
		float horizontal = Input.GetAxis("Horizontal");
		if (Mathf.Abs(horizontal) < horizontalTreshold)
		{
			m_acceleration = Acceleration.None;
		}
		else
		{
			if (horizontal < 0)
			{
				m_acceleration = Acceleration.Left;
			}
			else
			{
				m_acceleration = Acceleration.Right;
			}
		}
    }

	private void FixedUpdate()
	{
		switch (m_size)
		{
			case Size.Small:
				currentSpeed = speed;
				break;

			case Size.Medium:
				currentSpeed = speedMedium;
				break;

			case Size.Big:
				currentSpeed = speedBig;
				break;

			case Size.Toobig:
				currentSpeed = speedTooBig;
				break;
		}

		switch (m_situation)
		{
			case Situation.Grounded:
				switch (m_acceleration)
				{
					case Acceleration.None:
						break;

					case Acceleration.Left:
						m_body.AddForce(currentSpeed * left);
						break;

					case Acceleration.Right:
						m_body.AddForce(currentSpeed * right);
						break;
				}
				break;

			case Situation.InAir:
				switch (m_acceleration)
				{
					case Acceleration.None:
						break;

					case Acceleration.Left:
						m_body.AddForce(currentSpeed * airSpeedRatio * left);
						break;

					case Acceleration.Right:
						m_body.AddForce(currentSpeed * airSpeedRatio * right);
						break;
				}
				break;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{

		switch (m_situation)
		{
			case Situation.Grounded:
				m_situation = Situation.InAir;
				break;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		switch (m_situation)
		{
			case Situation.InAir:
				m_situation = Situation.Grounded;
				break;
		}
	}

	public void AddScore(int value)
	{
		score += value;
	}

	public void AddSize(float value)
	{
		size += value;
		if (size <= min)
		{
			size = min;
		}

		if (size >= max)
		{
			size = max;
		}

		scaller = 1+size/divider;
		transform.localScale = Vector3.one * scaller;

		checkSize();
	}

	void checkSize()
	{
		if (size <= thresholdMedium)
		{
			sprite.sprite = SmallSprite;
			m_size = Size.Small;
			spriteHolder.transform.localScale = Vector3.one * collSmall;
		}
		else if (size <= thresholdBig)
		{
			sprite.sprite = MediumSprite;
			m_size = Size.Medium;
			spriteHolder.transform.localScale = Vector3.one * collMedium;
		}
		else if (size <= thresholdTooBig)
		{
			sprite.sprite = BigSprite;
			m_size = Size.Big;
			spriteHolder.transform.localScale = Vector3.one * collBig;
		}
		else
		{
			sprite.sprite = TooBigSprite;
			m_size = Size.Toobig;
			spriteHolder.transform.localScale = Vector3.one * collTooBig;
		}
	}
}
