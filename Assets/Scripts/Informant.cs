using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informant : MonoBehaviour
{
    public static bool bought_shield;
    public static bool bought_gun;
    public static bool bought_pot;
    public static bool bought_sword;
    public static bool bought_RL;
    public static bool bought_LaserGun;
    public GameObject FloatingTextPrefab;
    public GameObject FloatingTextPrefab2;
    public GameObject FloatingTextPrefab3;
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
    // Make sure first works fine wouldn't objects not be destroyed if first != 0
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
            Destroy(obj, 5);
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
            Destroy(obj, 5);
           }  
        if (bought_pot)
         {
               if (first != 0)
               {
                    Destroy(obj);
               }
               bought_pot = false;
               obj = Instantiate(FloatingTextPrefab3, transform.position + newvec, Quaternion.identity, transform);
                first++;
                Destroy(obj, 5);
           }
        }
    }
