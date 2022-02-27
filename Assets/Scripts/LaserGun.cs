using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public GameObject Laser; 
    private double Interval = 1.5;
    private double TimeLeft = 0;
    public static bool CanShoot = false;


    private Transform ShotPoint;
    private GameObject temp;

    // for audio
    AudioSource aSource;
    [SerializeField]
    AudioClip shootSound;

    // Start is called before the first frame update
    void Start()
    {
        // audio
        aSource = (AudioSource)FindObjectOfType(typeof(AudioSource));
    }

    void Update()
    {
        temp = GameObject.Find("ShootPoint");
        ShotPoint = temp.GetComponent<Transform>();

        TimeLeft = TimeLeft - Time.deltaTime;

        if (TimeLeft < 0)
        {
            Shoot(); //shoots
        }

    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire2") && CanShoot == true)
        {
            aSource.PlayOneShot(shootSound);
            Instantiate(Laser, ShotPoint.position, ShotPoint.rotation); //Spawns bullet
            TimeLeft = Interval;
        }
    }

}