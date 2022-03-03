using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegularGun : MonoBehaviour
{
    public GameObject Bullet; //Bullet Gameobject
  //  public Player Code; //Code
 //   public Transform Firepoint; //Firepoint

    private double Interval = 1;
    private double TimeLeft = 0;
    public static bool CanShoot = false;


    public Transform ShootPoint;
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
        if (Time.time > TimeLeft) {
            Shoot(); //shoots
        }

    }

    void Shoot()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (Input.GetButtonDown("Fire2") && CanShoot == true && sceneName != "Shop 1") 
        //if (Input.GetButtonDown("Fire1") && CanShoot == true) //When player can shoot
        {
            aSource.PlayOneShot(shootSound);
            Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation); //Spawns bullet
            TimeLeft = Time.time;
            TimeLeft += Interval;
        }
    }
}
