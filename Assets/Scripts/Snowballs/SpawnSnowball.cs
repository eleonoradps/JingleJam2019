using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnowball : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    private bool snowBall = true;
    private float posXMin = -1000f;
    private float posXMax = 1000f;
    private float posXDivision = 100f;
    private int posY = 7;
    private int posZ = 0;

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
            float posX = Random.Range(posXMin, posXMax) / posXDivision;
            Instantiate(prefabs[prefab_num], new Vector3(posX, posY, posZ), transform.rotation);
        }
    }
}
