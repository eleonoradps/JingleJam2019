using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGifts : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    private bool gift = true;
    private float posXMin = -9f;
    private float posXMax = 9f;
    private int posY = 7;
    private int posZ = 0;


    void Start()
    {
        gift = true;
        StartCoroutine(CoroutineExample());
    }

    IEnumerator CoroutineExample()
    {
        while (gift)
        {
            int prefab_num = Random.Range(0, prefabs.Length);
            float posX = Random.Range(posXMin, posXMax);
            Instantiate(prefabs[prefab_num], new Vector3(posX, posY, posZ), transform.rotation);
            yield return new WaitForSeconds(2.0f);
        }
    }
}
