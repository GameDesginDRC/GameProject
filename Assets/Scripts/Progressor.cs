using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progressor : MonoBehaviour
{
    public static bool next = false;
    public static int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame

    // Basically, give each monster a count of 1. When all the monsters have been defeated, and a designated count number has been reached, then we can go to next scene.
    void Update()
    {
        if (count == 10)
        {
            next = true;
        }
    }
}
