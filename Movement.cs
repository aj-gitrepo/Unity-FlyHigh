using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime); 
            // Vector3 - shorthand for(0, 1, 0) - (x, y, z) //relative to the inclination(axis) of the obj //Vector2 for 2d
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotation Left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotation Right");
        }
    }
}

// changing mass of Rocket in RigidBody to 0.2 before adding main thrust then changing to 1
