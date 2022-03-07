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
    bool dying = false;

    private Rigidbody2D rb;
    private Collider2D col2d;

    SpriteRenderer sprite;
    Color spriteColor;
    AudioSource aSource;
    [SerializeField]
    AudioClip deathSound;
    [SerializeField]
    AudioClip hitSound;
    // Start is called before the first frame update
    void Start()
    {
        aSource = (AudioSource)FindObjectOfType(typeof(AudioSource));
        sprite = GetComponent<SpriteRenderer>();
        spriteColor = sprite.color;

        animA = gameObject.GetComponent<Animator>();
        leftshot = -1;
        rightshot = 1;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincible) { StartCoroutine(Blink()); }

        if (Time.time > nextAttack && !dying)
        { 

            nextAttack = Time.time + 10;
            StartCoroutine(LaserChain());
            animA.SetTrigger("attack");

        }
        if (health <= 0 && !dying)
        {
            dying = true;
            gameObject.tag = "Untagged";
            Death();
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
        ScoreKeeper.gold += 20;
        ScoreKeeper.AddToGold(0);
        Destroy(gameObject);
    }
    void Death()
    {
        aSource.PlayOneShot(deathSound);
        animA.SetBool("death", true);
        Invoke("Die", .8f);
    }
    void Unpause()
    {
        isPaused = false;
    }
    void invinCooldown()
    {
        isPaused = false;
        invincible = false;
        sprite.color = spriteColor;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            // decrease HP and pause
            if (!invincible && !dying)
            {
                //aSource.PlayOneShot(hitSound);
                aSource.PlayOneShot(hitSound);
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
    private IEnumerator LaserChain()
    {
        // really doesnt matter what the while loop ends off of
        while (rightshot <= 20)
        {
            yield return new WaitForSeconds(.5f);
            displ1 = new Vector3(rightshot, .34f, 0);
            displ2 = new Vector3(leftshot, .34f, 0);
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
    void Recolor()
    {
        Color transparentColor = spriteColor;
        transparentColor.a = .50f;
        sprite.color = transparentColor;
    }
}
