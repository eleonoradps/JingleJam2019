using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFall : MonoBehaviour
{

	[SerializeField] private GameObject snowball;
	[SerializeField] private float fallSpeed;
	[SerializeField] private float oscSpeed;
	[SerializeField] private float oscRange;
	[SerializeField] private Rigidbody2D m_body;
	[SerializeField] private int value;

	// Start is called before the first frame update
	void Start()
    {
		m_body.velocity = new Vector2(0, -fallSpeed);
    }

    // Update is called once per frame
    void Update()
    {
		snowball.transform.localPosition = new Vector2(oscRange * Mathf.Sin(Time.time * oscSpeed), 0);;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			Destroy(gameObject);
		}

		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			collision.GetComponent<PlayerMovement>().AddSize(value);
			Destroy(gameObject);
		}
	}
}
