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
    private double Interval = 5;
    private double TimeLeft = 0;
    public static bool CanShoot = false;
    [SerializeField]

    private Transform ShotPoint;
    private GameObject temp;

    // for audio
    AudioSource aSource;
    [SerializeField]
    AudioClip shootSound;

    void Start()
    {
        // audio
        aSource = (AudioSource)FindObjectOfType(typeof(AudioSource));
    }
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
        {
            aSource.PlayOneShot(shootSound);
            GameObject aRocket = Instantiate(rocket, ShotPoint.position, ShotPoint.rotation); //Spawns rocket
            aRocket.GetComponent<Rigidbody2D>().velocity = 20 * transform.right;
            TimeLeft = Time.time;
            TimeLeft += Interval;
        }
    }
}
