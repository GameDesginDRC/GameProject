using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject Explosion; //Gameobject DeathEffect

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ExplosionTimer()
    {
        GameObject anExplosion = Instantiate(Explosion, transform.position, transform.rotation);
        anExplosion.tag = "Enemy";
        Destroy(gameObject); //Destroy Bullet
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("PlayerContact", true);
            Invoke("ExplosionTimer", 1f);
        }
        else if (collision.gameObject.GetComponent<Explosion>()) {
            Invoke("ExplosionTimer", 0f);
        }
    }
}
