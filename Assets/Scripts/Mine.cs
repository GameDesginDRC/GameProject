using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject Explosion; //Gameobject DeathEffect

    // for audio
    AudioSource aSource;
    [SerializeField]
    AudioClip beepSound;
    [SerializeField]
    AudioClip explodeSound;

    // Start is called before the first frame update
    void Start()
    {
        // audio
        aSource = (AudioSource)FindObjectOfType(typeof(AudioSource));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ExplosionTimer()
    {
        aSource.PlayOneShot(explodeSound);
        GameObject anExplosion = Instantiate(Explosion, transform.position, transform.rotation);
        anExplosion.tag = "Enemy";
        Destroy(gameObject); //Destroy Bullet
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            aSource.PlayOneShot(beepSound);
            animator.SetBool("PlayerContact", true);
            Invoke("ExplosionTimer", 1f);
        }
        else if (collision.gameObject.GetComponent<Explosion>()) {
            Invoke("ExplosionTimer", 0f);
        }
    }
}
