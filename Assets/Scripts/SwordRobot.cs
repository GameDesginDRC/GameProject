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

    // Start is called before the first frame update
    void Start()
    {
    }

    void Wait() {
        theAttack.tag = "Untagged";
        animator.SetBool("Attacking", false);
    }

    void Unpause() {
        isPaused = false;
    }

    void Attack() {
        theAttack.tag = "Enemy";
        animator.SetBool("Attacking", true);
        Invoke("Wait", .3f);
    }

    IEnumerator Blink()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds((float)0.2);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds((float)0.2);
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
        if (invincible) { StartCoroutine(Blink()); }

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!onCooldown)
            {
                isPaused = true;
                // 3/10th a second before attack
                Invoke("Attack", .3f);
                // Attack
                //Debug.Log("Attack!");

                nextAttack = Time.time + 1f;
            }
        }

        if (collision.CompareTag("Wall"))
        {
            Debug.Log("Flip");
            InvokeFlip();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            // decrease HP and pause
            if (!invincible)
            {
                health -= 2;
                isPaused = true;
                invincible = true;
                // knockback
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

}
