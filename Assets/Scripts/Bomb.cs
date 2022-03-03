using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject Explosives; //Bullet Gameobject
    public Player Code; //Code
    public Transform ShootPoint;
    public static bool CanShoot = false;

    private double Interval = 0.5;
    private double TimeLeft = 0;

    // for audio
    AudioSource aSource;
    [SerializeField]
    AudioClip deploySound;

    void Start()
    {
        aSource = (AudioSource)FindObjectOfType(typeof(AudioSource));
    }

    void Update()
    {
        if (Time.time > TimeLeft) {
            Shoot(); //shoots
        }
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire2") && CanShoot == true) //When player can shoot
        {
            aSource.PlayOneShot(deploySound);
            Instantiate(Explosives, ShootPoint.position, ShootPoint.rotation); //Spawns bullet
            TimeLeft = Time.time;
            TimeLeft += Interval;
        }
    }
}
