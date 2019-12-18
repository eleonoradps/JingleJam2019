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
	private float time;

	private int min = 0;
	private int max = 360;

	// Start is called before the first frame update
	void Start()
    {
		m_body.velocity = new Vector2(0, -fallSpeed);
		time += Random.Range(min, max);
    }

    // Update is called once per frame
    void Update()
    {
		time += Time.deltaTime;
		snowball.transform.localPosition = new Vector2(oscRange * Mathf.Sin(time * oscSpeed), 0);;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			Destroy(gameObject);
		}

		if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			collision.GetComponentInParent<PlayerMovement>().AddSize(value);
			Destroy(gameObject);
		}
	}
}
