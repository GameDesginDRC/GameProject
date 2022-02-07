using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informant : MonoBehaviour
{
    public static bool bought_shield;
    public static bool bought_gun;
    public GameObject FloatingTextPrefab;
    public GameObject FloatingTextPrefab2;
    private Vector3 newvec;
    private GameObject obj;
    private int first;
    // Start is called before the first frame update
    void Start()
    {
        first = 0;
        newvec = new Vector3(-1.0f, 10.0f, 0);
        bought_shield = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bought_shield)
        {
            if (first != 0)
            {
                Destroy(obj);
            }
            bought_shield = false;
            obj = Instantiate(FloatingTextPrefab, transform.position + newvec, Quaternion.identity, transform);
            first++;
           // Destroy(obj, 8);
        }
        if (bought_gun)
        {
            if (first != 0)
            {
                Destroy(obj);
            }
            bought_gun = false;
            obj = Instantiate(FloatingTextPrefab2, transform.position + newvec, Quaternion.identity, transform);
            first++;
         //   Destroy(obj, 8);
           }
        }
    }
