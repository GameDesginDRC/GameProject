using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRobot : MonoBehaviour
{
    // health
    [SerializeField]
    float health = 10;

    // for movement
    [SerializeField]
    float speed = .5f;
    [SerializeField]
    float flipEveryXSecs = 1f;
    [SerializeField]
    float nextFlip = 0f;
    bool flipTimerOn = true;
    [SerializeField]
    bool isPaused = false;
    [SerializeField]
    bool movingRight = true;

    // for line of sight
    [SerializeField]
    Transform castPoint;
    [SerializeField]
    float aggroRange;

    // for bullet shooting
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float shootSpeed;
    [SerializeField]
    float nextShootTime = 0;
    [SerializeField]
    float shootevery = 1;

    // invincibility when attacked
    [SerializeField]
    float invincibleTime = .3f;
    [SerializeField]
    bool invincible = false;

    // for animations
    [SerializeField]
    private Animator animator;

    private Rigidbody2D rb;
    private Collider2D col2d;
    SpriteRenderer sprite;
    Color spriteColor;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        spriteColor = sprite.color;
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        col2d = gameObject.GetComponent<Collider2D>();
    }

    void InvokeFlip()
    {
        if (movingRight)
        {
            // flip left
            transform.rotation = Quaternion.Euler(0, 0, 0);
            movingRight = false;
        }
        else
        {
            // flip right
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            movingRight = true;
        }

        isPaused = false;
    }

    void turnFlipTimerOn() { flipTimerOn = true; }

    void Shoot()
    {
        Vector3 shootLoc = castPoint.position;

        if (movingRight)
        {
            GameObject newBullet = Instantiate(bullet, shootLoc + (-transform.right), bullet.transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().velocity = shootSpeed * -transform.right;
        }
        else
        {
            GameObject newBullet = Instantiate(bullet, shootLoc + (-transform.right), bullet.transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().velocity = shootSpeed * -transform.right;
        }

        animator.SetBool("Attacking", false);
        Invoke("turnFlipTimerOn", 0.5f);

    }
    void Die() {
        LevelManager.DecreaseEnemyNum();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextFlip)
        {
            if (flipTimerOn)
            {
                InvokeFlip();
                nextFlip = Time.time + 2 + flipEveryXSecs;
            }
        }
        

        // check to see if player is in range
        if (PlayerInSight(aggroRange))
        {
            // shoot at the player
            if (Time.time > nextShootTime)
            {
                flipTimerOn = false;
                animator.SetBool("Attacking", true);
                Invoke("Shoot", 1f);
                nextShootTime = Time.time + shootevery;
            }

            Debug.Log("Player spotted");
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void invinCooldown()
    {
        isPaused = false;
        invincible = false;
    }

    // Checks to see if player is in enemy's sight
    bool PlayerInSight(float distance) {
        bool val = false;
        float castDist = distance;

        if (!movingRight) {
            castDist = -castDist;
        }

        Vector2 EndofSight = castPoint.position + Vector3.right * castDist;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, EndofSight, 1 << LayerMask.NameToLayer("Default"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Player") { 
                val = true; 
            }
            else { val = false; }
        }
        Debug.DrawLine(castPoint.position, EndofSight, Color.red);
        
        return val;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Debug.Log("Flip");
            InvokeFlip();
        }
    }
    /* private void OnTriggerStay2D(Collider2D collision)
     {
         if (collision.CompareTag("PlayerAttack"))
         {
             // decrease HP and pause
             if (!invincible)
             {
                 health -= 2;
                 isPaused = true;
                 invincible = true;

                 Invoke("invinCooldown", invincibleTime);
             }
         }
     }*/

    void Recolor() { sprite.color = spriteColor; }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            // decrease HP and pause
            if (!invincible)
            {
                health -= 5;
                isPaused = true;
                invincible = true;
                sprite.color = Color.red;
                Invoke("Recolor", .05f);
                Invoke("invinCooldown", invincibleTime);
            }
        }
        else if (collision.CompareTag("Laser"))
        {
            // decrease HP and pause
            if (!invincible)
            {
                health -= 3;
                isPaused = true;
                invincible = true;
                sprite.color = Color.red;
                Invoke("Recolor", .05f);
                Invoke("invinCooldown", invincibleTime);
            }
        }
        else if (collision.CompareTag("RL"))
        {
            // decrease HP and pause
            if (!invincible)
            {
                health -= 4;
                isPaused = true;
                invincible = true;
                sprite.color = Color.red;
                Invoke("Recolor", .05f);
                Invoke("invinCooldown", invincibleTime);
            }
        }
        else if (collision.CompareTag("Bullet"))
        {
            // decrease HP and pause
            if (!invincible)
            {
                health -= 3;
                isPaused = true;
                invincible = true;
                sprite.color = Color.red;
                Invoke("Recolor", .05f);
                Invoke("invinCooldown", invincibleTime);
            }
        }
    }
}
