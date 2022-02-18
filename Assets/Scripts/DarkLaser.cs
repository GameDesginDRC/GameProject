using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkLaser : MonoBehaviour
{
    private float TimeToDeath;
    // Start is called before the first frame update
    void Start()
    {
        TimeToDeath = Time.time + .7f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > TimeToDeath)
        {
            Destroy(gameObject);
        }
    }
}
