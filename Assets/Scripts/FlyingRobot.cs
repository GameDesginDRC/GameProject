using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingRobot : MonoBehaviour
{
    // health
    [SerializeField]
    private float health = 10;
    private bool dying = false;
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

    // for animations
    [SerializeField]
    private Animator animator;

    // for floating
    private float floatEvery = .5f;
    private float floatTimer;
    private bool floatingDown = true;

    private Transform playerTransform;

    SpriteRenderer sprite;
    Color spriteColor;

    // for audio
    AudioSource aSource;
    [SerializeField]
    AudioClip shootSound;
    [SerializeField]
    AudioClip hitSound;
    [SerializeField]
    AudioClip deathSound;


    // Start is called before the first frame update
    void Start()
    {
        // audio
        aSource = (AudioSource)FindObjectOfType(typeof(AudioSource));

        sprite = GetComponent<SpriteRenderer>();
        spriteColor = sprite.color;
        animator = gameObject.GetComponent<Animator>();

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
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else
        {
            // flip right
            transform.rotation = Quaternion.Euler(0, 360f, 0);
        }

        facingRight = !facingRight;

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
        if (health <= 0) Die();

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
        if (playerInRange && !dying)
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
    void invinCooldown()
    {
        invincible = false;
        sprite.color = spriteColor;
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
                invincible = true;
                sprite.color = Color.red;
                Invoke("Recolor", .05f);
                Invoke("invinCooldown", invincibleTime);
            }
        }
    }
}
