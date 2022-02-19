using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour
{

    [SerializeField] string Level1;
    [SerializeField] string Level2;
    // public static means that we can use this variable in other scripts

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    // When clicking escape, resets to original scene. Can modify to make a pop up but the script is here
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            TV_Counter.countertv++;
            SceneManager.LoadScene(Level1);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene(Level2);
        }
    }
}
