using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 20f; //Bullet Speed
    public float BulletLongevity = 0.3f; //Bullet longevity

    public Rigidbody2D rbBullet; //Rigidbody of Bullet
    public GameObject DeathEffect; //Gameobject DeathEffect

    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rbBullet.velocity = transform.right * BulletSpeed;
    }

    private void ExplodeAndDie()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        if (hitInfo.gameObject.tag==("Ground") || hitInfo.gameObject.tag == ("Enemy") || hitInfo.gameObject.tag == ("Wall"))
        {
            anim.SetBool("Disappear", true);
            //Instantiate(DeathEffect, transform.position, transform.rotation); //animation for bullet
            Invoke("ExplodeAndDie", .05f);
        }
    }   

    private void OnBecameInvisible()
    {
        enabled = false;
        anim.SetBool("Disappear", true);
        Destroy(gameObject, BulletLongevity); //Bullet destroys itself after a period of time
    }
}
