using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularGun : MonoBehaviour
{
    public GameObject Bullet; //Bullet Gameobject
    public Player Code; //Code
    public Transform Firepoint; //Firepoint

    public double ShootTimer = 0.5; //Wait period before shooting
    public bool CanShoot = true;
    private double _Tracker; //Tracks time


    void Start()
    {
        _Tracker = ShootTimer; //Tracks time
    }

    void Update()
    {
        ShootTimer += Time.deltaTime; //Updates time

        if (ShootTimer > _Tracker) //When player can shoot
        {
            Shoot(); //shoots
        }

    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && CanShoot == true) //When player can shoot
        {
            ShootTimer = 0; //Resets timer
            Instantiate(Bullet, Firepoint.position, Firepoint.rotation); //Spawns bullet
        }
    }
}
