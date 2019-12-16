using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfGameDisplay : MonoBehaviour
{
    [SerializeField] private float minAngle_ = -27;
    [SerializeField] private float maxAngle_ = 27;

    [SerializeField] private float gameDurationSeconds_ = 600;

    [SerializeField] private float gameTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = 0;
        transform.rotation = Quaternion.Euler(0, 0, minAngle_);
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        float currentValue = Mathf.Lerp(minAngle_, maxAngle_, gameTimer / gameDurationSeconds_);
        transform.rotation = Quaternion.Euler(0, 0, currentValue);
    }


}
