using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosives : MonoBehaviour
{
    public float BombSpeed = 5f; //Bullet Speed
    public float BombLongevity = 4f; //Bullet longevity
    public Rigidbody2D rbBomb; //Rigidbody of Bullet
    public GameObject Explosion; //Gameobject DeathEffect

    void Start()
    {
        rbBomb.velocity = transform.right * BombSpeed;
        StartCoroutine(ExplosionTimer());
    }

    
    IEnumerator ExplosionTimer()
    {
        yield return new WaitForSeconds(BombLongevity);
        Instantiate(Explosion, transform.position, transform.rotation);  //Size of Explosion
        Destroy(gameObject); 
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag==("Enemy"))
            {
                Instantiate(Explosion, transform.position, transform.rotation);  //Size of Explosion
                Destroy(gameObject); 
            }
    }


    private void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject, BombLongevity); //Bullet destroys itself after a period of time
    }
}

