using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularGun : MonoBehaviour
{
    public GameObject Bullet; //Bullet Gameobject
  //  public Player Code; //Code
 //   public Transform Firepoint; //Firepoint

    private double Interval = 1;
    private double TimeLeft = 0;
    public static bool CanShoot = false;


    private Transform ShotPoint;
    private GameObject temp;


    void Update()
    {
        temp = GameObject.Find("ShootPoint");
        ShotPoint = temp.GetComponent<Transform>();

        if (Time.time > TimeLeft) {
            Shoot(); //shoots
        }

    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire2") && CanShoot == true)
        //if (Input.GetButtonDown("Fire1") && CanShoot == true) //When player can shoot
        {
            Instantiate(Bullet, ShotPoint.position, ShotPoint.rotation); //Spawns bullet
            TimeLeft = Time.time;
            TimeLeft += Interval;
        }
    }
}
