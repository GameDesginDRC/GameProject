using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRobot : MonoBehaviour
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

    [SerializeField]
    bool isPaused = false;
    [SerializeField]
    bool movingRight = true;

    // for line of sight
    [SerializeField]
    Transform castPoint;
    [SerializeField]
    float aggroRange;

    // for attacking
    [SerializeField]
    bool onCooldown = false;
    [SerializeField]
    float nextAttack = 0;
    [SerializeField]
    GameObject theAttack;

    // invincibility when attacked
    [SerializeField]
    float invincibleTime = .3f;
    [SerializeField]
    bool invincible = false;

    // animation
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Animator animator2;

    private Rigidbody2D rb;
    private Collider2D col2d;
    SpriteRenderer sprite;
    Color spriteColor;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        spriteColor = sprite.color;
        animator2 = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        col2d = gameObject.GetComponent<Collider2D>();
    }

    void Wait()
    {
        animator.SetBool("Attacking", false);
        theAttack.tag = "Untagged";
    }

    void Unpause() {
        isPaused = false;
    }

    void Attack() {
        theAttack.tag = "Enemy";
        animator.SetBool("Attacking", true);
        animator2.SetBool("Attacking", false);
        Invoke("Wait", .3f);
    }

    void InvokeFlip() {
        if (movingRight)
        {
            // flip left
            transform.rotation = Quaternion.Euler(0, 0, 0);
            movingRight = false;
        }
        else {
            // flip right
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            movingRight = true;
        }
    }

    void Die()
    {
        LevelManager.DecreaseEnemyNum();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        // attack cooldown check
        if (Time.time > nextAttack) {
            onCooldown = false;
        }

        if (!isPaused)
        {
            Vector3 HorzVector = new Vector3(5, 0.0f, 0.0f);
            transform.Translate(HorzVector * Time.deltaTime);
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
        sprite.color = spriteColor;
    }


    // for knockback
    private void KnockbackEnd()
    {
        col2d.isTrigger = true;
        rb.isKinematic = true;
    }
    private void Knockback()
    {
        col2d.isTrigger = false;
        rb.isKinematic = false;
        rb.AddForce(-transform.right * 1.5f, ForceMode2D.Impulse);
        Invoke("KnockbackEnd", .1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!onCooldown)
            {
                isPaused = true;
                // 3/10th a second before attack
                animator2.SetBool("Attacking", true);
                Invoke("Attack", .3f);

                nextAttack = Time.time + 1f;
            }
        }

        if (collision.CompareTag("Wall") || collision.CompareTag("InvisWall"))
        {
            Debug.Log("Flip");
            InvokeFlip();
        }
    }

    void Recolor() {
        Color transparentColor = spriteColor;
        transparentColor.a = .50f;
        sprite.color = transparentColor;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            // decrease HP and pause
            if (!invincible)
            {
                float attackVal = collision.GetComponent<PAttack>().AttackValue;
                health -= attackVal;
                isPaused = true;
                invincible = true;

                sprite.color = Color.red;
                Invoke("Recolor", .05f);
                Invoke("invinCooldown", invincibleTime);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Invoke("Unpause", .5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Flip");
            InvokeFlip();
        }
    }
}
