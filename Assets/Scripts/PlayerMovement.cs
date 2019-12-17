﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody2D m_body;

	[SerializeField] private Acceleration m_acceleration;
	[SerializeField] private Situation m_situation;

	[SerializeField] private float horizontalTreshold;

	[SerializeField] private float speed;



	private Vector2 left = new Vector2(-1, 0);
	private Vector2 right = new Vector2(1, 0);

	private Vector2 m_velocity;
	private Vector2 maxSpeed;

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

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
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
		switch (m_situation)
		{
			case Situation.Grounded:
				switch (m_acceleration)
				{
					case Acceleration.None:
						break;

					case Acceleration.Left:
						m_body.AddForce(speed * left);
						break;

					case Acceleration.Right:
						m_body.AddForce(speed * right);
						break;
				}
				break;

			case Situation.InAir:

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
}
