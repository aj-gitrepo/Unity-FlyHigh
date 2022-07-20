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
        //comparing to 0 may not be accurate in float, so using the smallest float in Unity given by Mathf.Epsilon
        if(period <= Mathf.Epsilon) return; //to prevent NaN Error 
        const float tau = Mathf.PI * 2; //2pialue of 6.283
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(cycles * tau); //angle in radians //generates value from -1 to 1
        
        movementFactor = (rawSinWave + 1) / 2f; //(rawSinWave + 1) gives 0 - 2, divide by 2 gives 0 - 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}

// Movement Vetor - 8, 0, 0
// Movement Factor - slider
