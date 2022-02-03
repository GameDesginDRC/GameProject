using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Gen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            UseShieldGen();
        }
    }
    void UseShieldGen()
    {
        GenBar.shield = true;
        GenBar.start1 = true;
        Destroy(gameObject);
    }
}
