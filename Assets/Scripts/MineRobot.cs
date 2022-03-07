using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineRobot : MonoBehaviour
{
    // health
    [SerializeField]
    private float health = 10;
    // invincibility when attacked
    [SerializeField]
    private float invincibleTime = .3f;
    [SerializeField]
    private bool invincible = false;
    bool dying = false;
    bool movingRight = true;

    // for line of sight
    [SerializeField]
    Transform castPoint;
    [SerializeField]
    float aggroRange;

    // movement (horizontal only)
    [SerializeField]
    private float moveOtherDir = 1;

    // control how much it moves
    [SerializeField]
    private float moveTimeAmt;
    [SerializeField]
    private float moveTimer;
    [SerializeField]
    private bool timerOn = true;

    // control how fast it moves
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private bool isPaused = false;

    // for dropping mines
    [SerializeField]
    GameObject mine;
    [SerializeField]
    float nextDropTime;
    [SerializeField]
    float dropEvery;

    // for animations
    [SerializeField]
    private Animator animator;

    SpriteRenderer sprite;
    Color spriteColor;

    // for audio
    AudioSource aSource;
    [SerializeField]
    AudioClip dropSound;
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

        moveTimer = moveTimeAmt;
        nextDropTime = dropEvery;
    }

    void Unpause() {
        isPaused = false;
        timerOn = true;
    }
    void UnpauseAndFlip()
    {
        isPaused = false;
        timerOn = true;
        Flip();
    }

    // drop a mine
    void Drop()
    {
        aSource.PlayOneShot(dropSound);
        Instantiate(mine, transform.position, transform.rotation);
        Invoke("Unpause", 1f);
    }

    void RemoveFromGame()
    {
        LevelManager.DecreaseEnemyNum();
        ScoreKeeper.gold += 6;
        ScoreKeeper.AddToGold(0);
        Destroy(gameObject);
    }

    void Die()
    {
        aSource.PlayOneShot(deathSound);
        animator.SetBool("Dead", true);
        Invoke("RemoveFromGame", .8f);
    }

    void invinCooldown()
    {
        isPaused = false;
        invincible = false;
        timerOn = true;
        sprite.color = spriteColor;
    }
    void Recolor()
    {
        Color transparentColor = spriteColor;
        transparentColor.a = .50f;
        sprite.color = transparentColor;
    }

    void Flip()
    {
        if (movingRight)
        {
            // flip left
            transform.rotation = Quaternion.Euler(0, 360f, 0);
        }
        else
        {
            // flip right
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }

        movingRight = !movingRight;

    }

    // Update is called once per frame
    void Update()
    {
        // for movement
        if (timerOn) moveTimer -= Time.deltaTime;

        if (moveTimer <= 0)
        {
            // pause for a short while
            isPaused = true;
            timerOn = false;
            moveTimer = moveTimeAmt;
            Invoke("UnpauseAndFlip", 1f);
        }

        if (!isPaused && !dying)
        {
            Vector3 HorzVector = new Vector3(moveOtherDir * moveSpeed, 0.0f, 0.0f);
            transform.Translate(HorzVector * Time.deltaTime);
        }

        if(nextDropTime > 0) nextDropTime -= Time.deltaTime;

        // check to see if player is in range
        if (PlayerInSight(aggroRange))
        {
            Debug.Log("Player spotted");
            // drop a mine
            if (nextDropTime <= 0)
            {
                Debug.Log("Mine dropped");
                isPaused = true;
                timerOn = false;
                Invoke("Drop", .5f);
                nextDropTime = dropEvery;
            }
        }

        if (health <= 0 && !dying)
        {
            dying = true;
            gameObject.tag = "Untagged";
            Die();
        }
    }
    bool PlayerInSight(float distance)
    {
        bool val = false;
        float castDist = distance;

        Vector2 EndofSight = castPoint.position + -Vector3.up * castDist;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, EndofSight, 1 << LayerMask.NameToLayer("Default"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                val = true;
            }
            else { val = false; }
        }
        Debug.DrawLine(castPoint.position, hit.point, Color.red);

        return val;
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
                timerOn = false;
                invincible = true;
                sprite.color = Color.red;
                Invoke("Recolor", .05f);
                Invoke("invinCooldown", invincibleTime);
            }
        }
    }
}
