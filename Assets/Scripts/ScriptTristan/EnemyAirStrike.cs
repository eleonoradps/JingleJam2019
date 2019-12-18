using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAirStrike : MonoBehaviour
{

    private int snowVal = 200;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collider.GetComponent<PlayerHorizMove>().GrowSize(snowVal);
            Destroy(gameObject);
        }
    }
}
