using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    float posY = -4.5f;
    private void Update()
    {
        if (this.transform.position.y <= posY)
        {
            Destroy(gameObject);
        }
    }
}
