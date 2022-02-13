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

    private Rigidbody2D rb;
    private Collider2D col2d;

    // Start is called before the first frame update
    void Start()
    {
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

    }
    IEnumerator Blink()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds((float)0.2);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds((float)0.2);
    }
    void Die() {
        LevelManager.DecreaseEnemyNum();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (invincible) { StartCoroutine(Blink()); }

        if (Time.time > nextFlip)
        {
            Invoke("InvokeFlip", 2);
            nextFlip = Time.time + 2 + flipEveryXSecs;
        }
        

        // check to see if player is in range
        if (PlayerInSight(aggroRange))
        {
            // shoot at the player
            if (Time.time > nextShootTime)
            {
                Debug.Log("Shoot!");
                Invoke("Shoot", .5f);
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
}
