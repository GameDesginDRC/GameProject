using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject rocket;
    [SerializeField]
    private bool coolingDown = false;

    [SerializeField]
    private double ShootTimer = 1; //Wait period before shooting
    [SerializeField]
    private static bool CanShoot = false;
    [SerializeField]
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
        {
            ShootTimer = 0; //Resets timer
            GameObject aRocket = Instantiate(rocket, ShotPoint.position, ShotPoint.rotation); //Spawns rocket
            aRocket.GetComponent<Rigidbody2D>().velocity = 5 * transform.right;
        }
    }
}
