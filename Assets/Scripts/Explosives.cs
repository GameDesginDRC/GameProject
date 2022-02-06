using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosives : MonoBehaviour
{
    public float BombSpeed = 5f; //Bullet Speed
    public int BulletDamage = 20; //Bullet Damage
    public float BombLongevity = 1f; //Bullet longevity

    public Rigidbody2D rbBullet; //Rigidbody of Bullet
    public GameObject Explosion; //Gameobject DeathEffect

    void Start()
    {
        rbBullet.velocity = transform.right * BombSpeed;
    }

    void Update()
    {
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

