using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRobot : MonoBehaviour
{
    // health
    public float health = 10;

    // for movement
    public float speed = .5f;

    public float flipEveryXSecs = 1f;
    public float nextFlip = 0f;

    public bool isPaused = false;
    public bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    void InvokeFlip() {
        if (movingRight)
        {
            // flip left
            transform.rotation = Quaternion.Euler(0, 0, 0);
            movingRight = false;
        }
        else {
            // flip right
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            movingRight = true;
        }

        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        // move right and left
        if (!isPaused)
        {
            Vector3 HorzVector = new Vector3(5, 0.0f, 0.0f);
            transform.Translate(HorzVector * Time.deltaTime);
        }

        // pause for 2 seconds
        if (Time.time > nextFlip)
        {
            isPaused = true;
            Invoke("InvokeFlip", 2);
            nextFlip = Time.time + 2 + flipEveryXSecs;
        }
    }

    
}
