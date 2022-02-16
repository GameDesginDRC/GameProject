using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    [SerializeField]
    float health = 20;
    [SerializeField]
    bool isPaused = false;

    public GameObject lightning_;
    public GameObject warning_;

    private Vector3 displ1;
    private Vector3 displ2;
    private Vector3 displ3;

    [SerializeField]
    bool onCooldown = false;
    [SerializeField]
    float nextAttack = 3;
    [SerializeField]
    float minAttack = 14.6f;
    [SerializeField]
    float maxAttack = -14.6f;

    [SerializeField]
    float invincibleTime = .3f;
    [SerializeField]
    bool invincible = false;

    private Rigidbody2D rb;
    private Collider2D col2d;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        col2d = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincible) { StartCoroutine(Blink()); }

        if (Time.time > nextAttack)
        {
            float rand1 = Random.Range(minAttack, maxAttack);
            float rand2 = Random.Range(minAttack, maxAttack);
            float rand3 = Random.Range(minAttack, maxAttack);

            displ1 = new Vector3(rand1, 15, 0);
            Vector3 warndisp1 = new Vector3(displ1.x, 0, 0);
            displ2 = new Vector3(rand2, 15, 0);
            Vector3 warndisp2 = new Vector3(displ2.x, 0, 0);
            displ3 = new Vector3(rand3, 15, 0);
            Vector3 warndisp3 = new Vector3(displ3.x, 0, 0);


            var warn1 = Instantiate(warning_, transform.position + warndisp1, Quaternion.identity, transform);
            var warn2 = Instantiate(warning_, transform.position + warndisp2, Quaternion.identity, transform);
            var warn3 = Instantiate(warning_, transform.position + warndisp3, Quaternion.identity, transform);

            Destroy(warn1, 3);
            Destroy(warn2, 3);
            Destroy(warn3, 3);

            nextAttack = Time.time + 9;

            StartCoroutine(WarningCooldown());

            
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
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!onCooldown)
            {
                isPaused = true;
                // 3/10th a second before attack
                Invoke("Attack", .3f);

                nextAttack = Time.time + 1f;
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
                health -= 2;
                isPaused = true;
                invincible = true;

                Invoke("invinCooldown", invincibleTime);
            }
        }
    }
    private IEnumerator WarningCooldown()
    {
        yield return new WaitForSeconds(3);
        Instantiate(lightning_, transform.position + displ1, Quaternion.identity, transform);
        Instantiate(lightning_, transform.position + displ2, Quaternion.identity, transform);
        Instantiate(lightning_, transform.position + displ3, Quaternion.identity, transform);
    }
}
