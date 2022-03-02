using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosives : MonoBehaviour
{
    public float BombSpeed = 6f; //Bullet Speed
    public float BombLongevity = 1f; //Bullet longevity

    public Rigidbody2D rbBomb; //Rigidbody of Bullet
    public GameObject Explosion; //Gameobject DeathEffect

    void Start()
    {
        rbBomb.velocity = transform.right * BombSpeed;
        StartCoroutine(ExplosionTimer());
    }

    

    IEnumerator ExplosionTimer()
    {

        yield return new WaitForSeconds(1);
        Instantiate(Explosion, transform.position, transform.rotation);  //Size of Explosion
        Destroy(gameObject); //Destroy Bullet
    }

    private void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject, BombLongevity); //Bullet destroys itself after a period of time
    }
}

