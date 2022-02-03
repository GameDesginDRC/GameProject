using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inv_Box : MonoBehaviour
{
    private Inventory inv;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            inv._full[count] = false;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {

        }
    }
}
