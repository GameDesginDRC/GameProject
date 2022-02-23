using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    public bool dst = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dst)
        {
            Destroy(GetComponent<Transform>().GetChild(0).gameObject);
            dst = false;
          /*  foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
                dst = false;
                break;
            }*/
            
        }
    }
}
