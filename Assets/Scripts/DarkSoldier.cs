using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSoldier : MonoBehaviour
{
    [SerializeField]
    float health = 25;
    [SerializeField]
    bool isPaused = false;

    private Animator animA;

    public GameObject darklaser_;

    private Vector3 displ1;
    private Vector3 displ2;
    private int leftshot = -1;
    private int rightshot = 1;

    [SerializeField]
    bool onCooldown = false;
    [SerializeField]
    float nextAttack = 3;

    [SerializeField]
    float invincibleTime = .3f;
    [SerializeField]
    bool invincible = false;

    private Rigidbody2D rb;
    private Collider2D col2d;
    // Start is called before the first frame update
    void Start()
    {
        animA = gameObject.GetComponent<Animator>();
        leftshot = -1;
        rightshot = 1;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincible) { StartCoroutine(Blink()); }

        if (Time.time > nextAttack)
        { 

            nextAttack = Time.time + 10;
            StartCoroutine(LaserChain());
            animA.SetTrigger("attack");

        }
        if (health <= 0)
        {
            Die();
        }
    }
    IEnumerator Blink()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds((float)0.2);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds((float)0.2);
    }
    void Die()
    {
        LevelManager.DecreaseEnemyNum();
        Destroy(gameObject);
    }
    void Unpause()
    {
        isPaused = false;
    }
    void invinCooldown()
    {
        isPaused = false;
        invincible = false;
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

                Invoke("invinCooldown", invincibleTime);
            }
        }
    }
    private IEnumerator LaserChain()
    {
        // really doesnt matter what the while loop ends off of
        while (rightshot <= 20)
        {
            yield return new WaitForSeconds(.5f);
            displ1 = new Vector3(rightshot, .22f, 0);
            displ2 = new Vector3(leftshot, .22f, 0);
            Instantiate(darklaser_, transform.position + displ1, Quaternion.identity, transform);
            Instantiate(darklaser_, transform.position + displ2, Quaternion.identity, transform);
            rightshot++;
            leftshot--;
            if (rightshot >= 14)
            {
                rightshot = 1;
                leftshot = -1;
                break;
            }
        }
    }
}
