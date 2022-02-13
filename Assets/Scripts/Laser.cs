using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float BulletLongevity = 0.5f; //Bullet longevity

    public Rigidbody2D rbBullet; //Rigidbody of Bullet
    public GameObject DeathEffect; //Gameobject DeathEffect
    
    private void LaserDuration()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.gameObject.tag == ("Enemy")) //When Enemy is there
        {
            //Enemy takes damage
        }
        Invoke("LaserDuration", .5f);
    }   

}