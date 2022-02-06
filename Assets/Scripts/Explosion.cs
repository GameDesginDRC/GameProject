using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    
    public float ExplosionLongevity = 0.5f; //Bullet longevity

    public Rigidbody2D rbBullet; //Rigidbody of Bullet
    public GameObject DeathEffect; //Gameobject DeathEffect


    void Update()
    {
        Destroy(gameObject, ExplosionLongevity);
    }


    private void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject, ExplosionLongevity); //Bullet destroys itself after a period of time
    }
}

