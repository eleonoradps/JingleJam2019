using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSpawn : MonoBehaviour
{
	[SerializeField] GameObject[] prefabs;
	private bool snowBall = true;
	[SerializeField] private float posXMin = -10f;
	[SerializeField] private float posXMax = 10f;
	private int posY = 10;
	private int posZ = 0;

	private float spawnTimer;
	[SerializeField] private float spawnRate;

	void Start()
	{
		snowBall = true;
	}

	void Update()
	{
		if (spawnTimer < spawnRate)
		{
			spawnTimer += Time.deltaTime;
		}
		else
		{
			spawnTimer = 0;
			CreateSnowball();
		}
	}

	void CreateSnowball()
	{
		if (snowBall)
		{
			int prefab_num = Random.Range(0, prefabs.Length);
			float posX = Random.Range(posXMin, posXMax);
			Instantiate(prefabs[prefab_num], new Vector3(posX, posY, posZ), transform.rotation);
		}
	}
}
