using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAirStrike : MonoBehaviour
{

    private int snowVal = 10;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collider.GetComponent<PlayerMovement>().AddSize(snowVal);
            Destroy(gameObject);
        }
    }
}
