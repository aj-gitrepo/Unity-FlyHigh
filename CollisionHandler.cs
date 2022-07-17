using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag) 
        {
            case "Friendly":
                Debug.Log("This thing is Friendly");
                break;
            case "Finish":
                Debug.Log("Reached Finish Pad! Completed level");
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("Fuel Obtained");
                break;
            default:

                Debug.Log("Sorry, you got busted!");
                StartCrashSequence(); 
                break;
        }
    }

    void StartSuccessSequence()
    {
        // todo add SFX upon crash
        // todo add particle effect upon crash
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        // todo add SFX upon crash
        // todo add particle effect upon crash
        GetComponent<Movement>().enabled = false; //to cease control from user
        Invoke("ReloadLevel", levelLoadDelay); //(function name, secs) //invoke function after 1 sec
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings) 
        {
            nextSceneIndex = 0; //if it is the last scene go to the first scene
        }
        SceneManager.LoadScene(nextSceneIndex); 
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex); 
        //Scene in index 0, can also use namespace or index number
    }

}
