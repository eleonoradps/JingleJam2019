using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private float minimum = -6.8F;

    [SerializeField] private float maximum = -2.0F;

    [SerializeField] private float timeToWait = 2.0f;

    [SerializeField] private float timeInterpolater = 0.2f;

    private AudioSource audioSource;
    private AudioClip audioClip;

    // starting value for the Lerp
    static float t = 0.0f;
    static float t2 = 0.0f;

    private Transform transformCanon;

    // Start is called before the first frame update
    void Start()
    {
        transformCanon = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // animate the position of the game object...
        transformCanon.position = new Vector2(transformCanon.position.x, Mathf.Lerp(minimum, maximum, t));

        // .. and increase the t interpolater
        t += timeInterpolater * Time.deltaTime;
        t2 += timeInterpolater * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > timeToWait)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0;
        }

        if (t2 > timeToWait)
        {
            audioSource.Play();//play(sound)
            t2 = 0;
        }
    }
}
