using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowShooter : MonoBehaviour
{
	[SerializeField] private GameObject snowball;

	[SerializeField] private float snowballSpeed;


	[SerializeField] private float shootCooldown;
	private float cooldownTimer = 0.0f;
	private bool shootReady = true;

	[SerializeField] private PlayerMovement m_player;

    void Update()
    {

		if (cooldownTimer <= shootCooldown && !shootReady)
		{
			cooldownTimer += Time.deltaTime;
		}
		else
		{
			shootReady = true;
		}

		if (Input.GetAxis("Fire1") > 0.1f && shootReady && m_player.HaveMass())
		{
			m_player.LoseMass();
			shootReady = false;
			cooldownTimer = 0;
			GameObject shotSnowball = Instantiate(snowball, transform.position, Quaternion.identity);
			shotSnowball.transform.parent = null;
			shotSnowball.transform.localScale = Vector3.one;

			shotSnowball.GetComponent<Rigidbody2D>().velocity = Vector2.up * snowballSpeed;
			Destroy(shotSnowball, 2);
		}
	}
}
