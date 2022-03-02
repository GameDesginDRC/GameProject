using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRobot : MonoBehaviour
{
    // health
    [SerializeField]
    private float health = 10;
    // invincibility when attacked
    [SerializeField]
    private float invincibleTime = .3f;
    [SerializeField]
    private bool invincible = false;

    private bool facingRight = true;

    // for attacking
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float shootSpeed;
    [SerializeField]
    private float shootEvery;
    [SerializeField]
    private float shootTimer;
    [SerializeField]
    private float shootRange;
    [SerializeField]
    private Transform bulletShootPoint;
    [SerializeField]
    private bool playerInRange = false;

    // for floating
    private float floatEvery = .5f;
    private float floatTimer;
    private bool floatingDown = true;

    private Transform playerTransform;



    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<Player>().transform;
        shootTimer = shootEvery;
        floatTimer = floatEvery;
    }
    void Shoot() {
        // shoots at the player
        Vector2 bulletShootSpot = transform.right;
        Vector3 whereToShoot = (playerTransform.position - transform.position).normalized;

        GameObject newBullet = Instantiate(bullet, bulletShootPoint.position, bullet.transform.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = shootSpeed * whereToShoot;
    }

    void Flip()
    {
        if (facingRight)
        {
            // flip left
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = false;
        }
        else
        {
            // flip right
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            facingRight = true;
        }
    }

    void Die()
    {
        LevelManager.DecreaseEnemyNum();
        ScoreKeeper.gold += 15;
        ScoreKeeper.AddToGold(0);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) Die();

        if (invincible) { StartCoroutine(Blink()); }

        // always face the player
        if (facingRight) {
            if (transform.position.x < playerTransform.position.x) Flip();
        }
        else
        {
            if (transform.position.x > playerTransform.position.x) Flip();
        }

        float distanceFromPlayer = Vector3.Distance(playerTransform.position, transform.position);
        if (distanceFromPlayer <= shootRange) { playerInRange = true; }

        // float down and up
        floatTimer -= Time.deltaTime;
        if (floatTimer <= 0) { 
            floatingDown = !floatingDown;
            floatTimer = floatEvery;
        }

        if (floatingDown) { transform.Translate(new Vector3(0f, -.005f, 0.0f)); }
        else { transform.Translate(new Vector3(0f, .005f, 0.0f)); }


        // shoot every 3 seconds
        if (playerInRange)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = shootEvery;
            }
        }
    }

    // dealing with damage
    void invinCooldown() { invincible = false; }
    IEnumerator Blink()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds((float)0.2);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds((float)0.2);
    }
    /* private void OnTriggerStay2D(Collider2D collision)
     {
         if (collision.CompareTag("PlayerAttack"))
         {
             // decrease HP and pause
             if (!invincible)
             {
                 health -= 1;
                 invincible = true;
                 Invoke("invinCooldown", invincibleTime);
             }
         }
     }*/
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            // decrease HP and pause
            if (!invincible)
            {
                health -= 5;
               // isPaused = true;
                invincible = true;
                Invoke("invinCooldown", invincibleTime);
            }
        }
        else if (collision.CompareTag("Laser"))
        {
            // decrease HP and pause
            if (!invincible)
            {
                health -= 3;
              //  isPaused = true;
                invincible = true;
                Invoke("invinCooldown", invincibleTime);
            }
        }
        else if (collision.CompareTag("RL"))
        {
            // decrease HP and pause
            if (!invincible)
            {
                health -= 4;
             //   isPaused = true;
                invincible = true;
                Invoke("invinCooldown", invincibleTime);
            }
        }
        else if (collision.CompareTag("Bullet"))
        {
            // decrease HP and pause
            if (!invincible)
            {
                health -= 3;
              //  isPaused = true;
                invincible = true;
                Invoke("invinCooldown", invincibleTime);
            }
        }
    }
}
