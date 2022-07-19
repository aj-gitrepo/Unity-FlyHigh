using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0, 1)] float movementFactor;
    [SerializeField] float period = 2f;
    void Start()
    {
        startingPosition = transform.position; //position of the obj at start
    }

    void Update()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2; //2pi
        float rawSinWave = Mathf.Sin(cycles * tau); //angle in radians //generates value from -1 to 1
        Debug.Log(rawSinWave);
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}

// Movement Vetor - 8, 0, 0
// Movement Factor - slider
