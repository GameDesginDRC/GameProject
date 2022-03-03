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
    public static bool bought_grenade;
    public GameObject Shield;
    public GameObject Gun;
    public GameObject Health;
    public GameObject Rocket;
    public GameObject Laser;
    public GameObject Grenade;
    public GameObject Sword;
    public GameObject intro;
    private Vector3 newvec;
    private GameObject obj;
    private int first;
    public float x;
    public float y;
    // Start is called before the first frame update
    void Start()
    {
        first = 0;
        newvec = new Vector3(x, y, 0);
        bought_shield = false;
        obj = Instantiate(intro, transform.position + newvec, Quaternion.identity, transform);
    }

    // Update is called once per frame
    // Make sure first works fine wouldn't objects not be destroyed if first != 0
    void Update()
    {
        if (bought_shield)
        {
            // if (first != 0)
            // {
            //     Destroy(obj);
            // }
            Destroy(obj);
            bought_shield = false;
            obj = Instantiate(Shield, transform.position + newvec, Quaternion.identity, transform);
            first++;
        }
        if (bought_gun)
        {
            // if (first != 0)
            // {
            //     Destroy(obj);
            // }
            Destroy(obj);
            bought_gun = false;
            obj = Instantiate(Gun, transform.position + newvec, Quaternion.identity, transform);
            first++;
           }  
        if (bought_pot)
         {
            // if (first != 0)
            // {
            //     Destroy(obj);
            // }
            Destroy(obj);
            bought_pot = false;
            obj = Instantiate(Health, transform.position + newvec, Quaternion.identity, transform);
            first++;

           }
        if (bought_RL)
        {
            // if (first != 0)
            // {
            //     Destroy(obj);
            // }
            Destroy(obj);
            bought_RL = false;
            obj = Instantiate(Rocket, transform.position + newvec, Quaternion.identity, transform);
            first++;
        }
        if (bought_LaserGun)
            {
            // if (first != 0)
            // {
            //     Destroy(obj);
            // }
            Destroy(obj);
            bought_LaserGun = false;
            obj = Instantiate(Laser, transform.position + newvec, Quaternion.identity, transform);
            first++;
        }

        if (bought_grenade)
        {
            // if (first != 0)
            // {
            //     Destroy(obj);
            // }
            Destroy(obj);
            bought_grenade = false;
            obj = Instantiate(Grenade, transform.position + newvec, Quaternion.identity, transform);
            first++;
            }
        if (bought_sword)
        {
            // if (first != 0)
            // {
            //     Destroy(obj);
            // }
            Destroy(obj);
            bought_sword = false;
            obj = Instantiate(Sword, transform.position + newvec, Quaternion.identity, transform);
            first++;            
        }
    }
    
  /*  private void DestLater(GameObject obj1)
       {

       }*/
 }
