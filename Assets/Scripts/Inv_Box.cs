using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inv_Box : MonoBehaviour
{

    public int count;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            Inventory._full[count] = false;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {

        }
    }
}
