using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformBehaviour : MonoBehaviour
{

    [SerializeField] private float minimum = -14.0F;

    [SerializeField] private float maximum = -2.0F;

    [SerializeField] private float maximum2 = 14.0F;


    // starting value for the Lerp
    static float t = 0.0f;

    private Transform isOK;

    // Start is called before the first frame update
    void Start()
    {
        isOK = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // animate the position of the game object...
        isOK.position = new Vector2(Mathf.Lerp(minimum, maximum, t), isOK.position.y);

        // .. and increase the t interpolater
        t += 0.2f * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 2.0f)
        {
            float temp = maximum;
            maximum = maximum2;
            minimum = temp;
            t = 0;
        }
    }
}