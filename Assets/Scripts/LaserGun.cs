using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public GameObject Bullet; //Bullet Gameobject
    public Player Code; //Code
    public Transform Firepoint; //Firepoint

    private double ShootTimer = 0.5; //Wait period before shooting
    public static bool CanShoot = false;
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

    IEnumerator timeout()
    {
        CanShoot = false;
        yield return new WaitForSeconds(1);
        Instantiate(Bullet, Firepoint.position, Firepoint.rotation);
        CanShoot = true;


    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Z)&& CanShoot) //When player can shoot
        {
            ShootTimer = 0; //Resets timer
            StartCoroutine(timeout());
        }
    }
}