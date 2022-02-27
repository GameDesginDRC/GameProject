using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public GameObject Bullet; //Bullet Gameobject
    public Player Code; //Code
    public Transform Firepoint; //Firepoint

    private double Interval = 5;
    private double TimeLeft = 0;
    public static bool CanShoot = false;


    void Update()
    {
        if (Time.time > TimeLeft) {
            Shoot(); //shoots
        }

    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire2") && CanShoot == true)
        {
            Instantiate(Bullet, Firepoint.position, Firepoint.rotation); //Spawns rocket
            TimeLeft = Time.time;
            TimeLeft += Interval;
        }
    }

}