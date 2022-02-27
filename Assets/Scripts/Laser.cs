using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float BulletSpeed = 40f; //Bullet Speed
    public float BulletLongevity = 0.5f; //Bullet longevity

    public Rigidbody2D rbBullet; //Rigidbody of Bullet
    public GameObject DeathEffect; //Gameobject DeathEffect
    
    void Start()
    {
        rbBullet.velocity = transform.right * BulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag==("Ground") || hitInfo.gameObject.tag == ("Wall")) //When bullet hits Enemy or Ground
        {
            Destroy(gameObject);
        }
    }   

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    } 

}