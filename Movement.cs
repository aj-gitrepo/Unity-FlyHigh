using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000;
    [SerializeField] float rotationThrust = 100f;
    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        // audioSource.enabled = false;
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
            if(!audioSource.isPlaying) 
            {
                audioSource.Play();
            }
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime); 
            // Vector3 - shorthand for(0, 1, 0) - (x, y, z) //relative to the inclination(axis) of the obj //Vector2 for 2d
        } 
        else 
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust); 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust); //-ve direction
        }
    }

   void ApplyRotation(float rotationThisFrame)
  {
    //freezing rotation so we can manually rotate (incase if hit by an obj freezing the natural physics roation on collision)
    rb.freezeRotation = true; 
    transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime); //shorthand for (0,0,1)
    rb.freezeRotation = false; //unfreeze after manual rotation so the physics system can take over

    // applying the constrains again
    rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
  }
}

// changing mass of Rocket in RigidBody to 0.2 before adding main thrust then changing to 1
// set rotationThrust to 100

// select the line of code to create a method and hit Ctrl + .
// to rename - select -> F2

// to apply changes to the prefab obj select the obj in the inspctor pane select overrides -> Apply all

// Under Rigid Body -> Constrains 
// - freezePosition check z //such that it does not go beyond 
// - freezeRotation check x and y //roation only along z
// - drag - 0.25 

// change gravity - project Settings -> Physics -> set y as -4 (lesser gravity than earth)
