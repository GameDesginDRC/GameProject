using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvTracker : MonoBehaviour
{
    public static int invcount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Determining which weapon is on
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W");
            if (invcount == 0)
            {
                invcount = 1;
            } else
            {
                invcount = 0;
            }
        }

        // Weapon 1 is active
        if (Inventory._full[0] && Inventory._full[1] && invcount == 0)
        {
            Debug.Log(invcount);
            //Make whatever is in 0th index active
            if(Inventory.pos_objs[0].GetComponent<GunOn>() != null)
            {
                RegularGun.CanShoot = true;
            }
            /*else if (Inventory.pos_objs[0].GetComponent<LanceScript>() != null)
            {
                Lance.hasLance = true;
            }
            else if (Inventory.pos_objs[0].GetComponent<BombScript>() != null)
            {
                Bomb.CanShoot = true;
            }
            else if (Inventory.pos_objs[0].GetComponent<RocketLauncherScript>() != null)
            {
                RocketLauncher.hasRL = true;
            }
            else if (Inventory.pos_objs[0].GetComponent<LaserScript>() != null)
            {
                LaserGun.CanShoot = true;
            }*/

            //Make whatever is in 1st index inactive
            if (Inventory.pos_objs[1].GetComponent<GunOn>() != null)
            {
                RegularGun.CanShoot = false;
            }
            /*else if (Inventory.pos_objs[1].GetComponent<LanceScript>() != null)
            {
                Lance.hasLance = false;
            }
            else if (Inventory.pos_objs[1].GetComponent<BombScript>() != null)
            {
                Bomb.CanShoot = false;
            }
            else if (Inventory.pos_objs[1].GetComponent<RocketLauncherScript>() != null)
            {
                RocketLauncher.hasRL = false;
            }
            else if (Inventory.pos_objs[1].GetComponent<LaserScript>() != null)
            {
                LaserGun.CanShoot = false;
            }*/

        }

        // Weapon 2 is active
        if (Inventory._full[0] && Inventory._full[1] && invcount == 1)
        {
            //Make whatever is in 1st index active
            if (Inventory.pos_objs[1].GetComponent<GunOn>() != null)
            {
                RegularGun.CanShoot = true;
            }
            /*else if (Inventory.pos_objs[1].GetComponent<LanceScript>() != null)
            {
                Lance.hasLance = true;
            }
            else if (Inventory.pos_objs[1].GetComponent<BombScript>() != null)
            {
                Bomb.CanShoot = true;
            }
            else if (Inventory.pos_objs[1].GetComponent<RocketLauncherScript>() != null)
            {
                RocketLauncher.hasRL = true;
            }
            else if (Inventory.pos_objs[1].GetComponent<LaserScript>() != null)
            {
                LaserGun.CanShoot = true;
            }*/

            //Make whatever is in 0th index inactive
            if (Inventory.pos_objs[0].GetComponent<GunOn>() != null)
            {
                RegularGun.CanShoot = false;
            }
            /*else if (Inventory.pos_objs[0].GetComponent<LanceScript>() != null)
            {
                Lance.hasLance = false;
            }
            else if (Inventory.pos_objs[0].GetComponent<BombScript>() != null)
            {
                Bomb.CanShoot = false;
            }
            else if (Inventory.pos_objs[0].GetComponent<RocketLauncherScript>() != null)
            {
                RocketLauncher.hasRL = false;
            }
            else if (Inventory.pos_objs[0].GetComponent<LaserScript>() != null)
            {
                LaserGun.CanShoot = false;
            }*/
        }
    }
}
