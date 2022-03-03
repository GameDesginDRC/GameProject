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
    bool dying = false;

    // for animations
    [SerializeField]
    private Animator animator;

    // for audio
    AudioSource aSource;
    [SerializeField]
    AudioClip shootSound;
    [SerializeField]
    AudioClip hitSound;
    [SerializeField]
    AudioClip deathSound;

    private Rigidbody2D rb;
    private Collider2D col2d;
    SpriteRenderer sprite;
    Color spriteColor;

    // Start is called before the first frame update
    void Start()
    {
        // audio
        aSource = (AudioSource)FindObjectOfType(typeof(AudioSource));

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
        if (!dying)
        {
            aSource.PlayOneShot(shootSound);
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
    }
    void RemoveFromGame()
    {
        LevelManager.DecreaseEnemyNum();
        ScoreKeeper.gold += 10;
        ScoreKeeper.AddToGold(0);
        Destroy(gameObject);
    }

    void Die()
    {
        aSource.PlayOneShot(deathSound);
        animator.SetBool("Dead", true);
        Invoke("RemoveFromGame", .8f);
    }

    // Update is called once per frame
    void Update()
    {
        nextShootTime = nextShootTime - Time.deltaTime;

        if (Time.time > nextFlip)
        {
            if (flipTimerOn && !dying)
            {
                InvokeFlip();
                nextFlip = Time.time + 2 + flipEveryXSecs;
            }
        }
        

        // check to see if player is in range
        if (PlayerInSight(aggroRange) && !dying)
        {
            // shoot at the player
            if (nextShootTime < 0)
            {
                flipTimerOn = false;
                animator.SetBool("Attacking", true);
                Invoke("Shoot", 1f);
                nextShootTime = shootevery;
            }

            Debug.Log("Player spotted");
        }

        if (health <= 0 && !dying)
        {
            dying = true;
            gameObject.tag = "Untagged";
            Die();
        }
    }

    void invinCooldown()
    {
        isPaused = false;
        invincible = false;
        sprite.color = spriteColor;
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

    void Recolor()
    {
        Color transparentColor = spriteColor;
        transparentColor.a = .50f;
        sprite.color = transparentColor;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            // decrease HP and pause
            if (!invincible && !dying)
            {
                aSource.PlayOneShot(hitSound);

                float attackVal = collision.GetComponent<PAttack>().AttackValue;
                Debug.Log(attackVal);
                health -= attackVal;
                isPaused = true;
                invincible = true;
                sprite.color = Color.red;
                Invoke("Recolor", .05f);
                Invoke("invinCooldown", invincibleTime);
            }
        }
    }
}
