using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularGun : MonoBehaviour
{
    public GameObject Bullet; //Bullet Gameobject
  //  public Player Code; //Code
 //   public Transform Firepoint; //Firepoint

    public double ShootTimer = 0.5; //Wait period before shooting
    public bool CanShoot = true;
    private double _Tracker; //Tracks time

    private Transform ShotPoint;
    private GameObject temp;

    void Start()
    {
        _Tracker = ShootTimer; //Tracks time
        temp = GameObject.Find("ShootPoint");
        ShotPoint = temp.GetComponent<Transform>();
        
    }

    void Update()
    {
        temp = GameObject.Find("ShootPoint");
        ShotPoint = temp.GetComponent<Transform>();

        ShootTimer += Time.deltaTime; //Updates time

        if (ShootTimer > _Tracker) //When player can shoot
        {
            Shoot(); //shoots
        }

    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire2") && CanShoot == true)
        //if (Input.GetButtonDown("Fire1") && CanShoot == true) //When player can shoot
        {
            ShootTimer = 0; //Resets timer
            //Instantiate(Bullet, Firepoint.position, Firepoint.rotation); //Spawns bullet
            Instantiate(Bullet, ShotPoint.position, ShotPoint.rotation); //Spawns bullet
        }
    }
}
