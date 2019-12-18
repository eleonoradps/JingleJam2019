using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformBehaviour : MonoBehaviour
{
    [SerializeField] private float minimum = -14.0F;

    [SerializeField] private float maximum = -2.0F;

    [SerializeField] private float maximum2 = 14.0F;

    [SerializeField] private float timeToWait = 2.0f;

    [SerializeField] private float timeInterpolater = 0.2f;

    private int layerEnemy = 14;

    // starting value for the Lerp
    static float t = 0.0f;

    private Transform platformTransform;

    // Start is called before the first frame update
    void Start()
    {
        platformTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // animate the position of the game object...
        platformTransform.position = new Vector2(Mathf.Lerp(minimum, maximum, t), platformTransform.position.y);

        // .. and increase the t interpolater
        t += timeInterpolater * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > timeToWait)
        {
            float temp = maximum;
            maximum = maximum2;
            minimum = temp;
            t = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("SnowBullet"))
        {
            col.gameObject.layer = layerEnemy;
            col.gameObject.GetComponent<Rigidbody2D>().velocity *= -1;
        }
    }


}