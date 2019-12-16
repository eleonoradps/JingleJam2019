using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnowball : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    bool snowBall = true;

    void Start()
    {
        snowBall = true;
    }

    void Update()
    {
        CreateSnowball();
    }

    void CreateSnowball()
    {
        if (snowBall)
        {
            int prefab_num = Random.Range(0, prefabs.Length);
            float posX = Random.Range(-1000, 1000) / 100.0f;
            Instantiate(prefabs[prefab_num], new Vector3(posX, 7, 0), transform.rotation);
        }
    }
}
