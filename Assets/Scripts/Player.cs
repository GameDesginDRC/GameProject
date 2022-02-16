using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRB;
    private SpriteRenderer myRenderer;
    public enum StatusEffect { None, TookDamage };
    private StatusEffect statusEffect;
    private float statusEffectTimeout;
    public static bool circleFill_ = false;

    public float Speed = 10f;
    [SerializeField]
    private bool facingRight;

    public float JumpForce = .5f;
    public float DamageInvincibilityPeriod = 5f;
    public float DoubleClickTimerD = .3f;
    public float DoubleClickTimerA = .3f;
    private bool canJump = false;
    private int ClickCountD = 0;
    private int ClickCountA = 0;

    public bool Invincible = false;
    public int InvincibilityTime = 2;
    public float TimeSinceInvStarted;

    public HPBar healthbar = null;
    public GenBar GNBar = null;
    public static int hp;

    // for attacks
    [SerializeField]
    private bool coolingDown;

    [SerializeField]
    private GameObject playerBullet;
    [SerializeField]
    Transform castPoint;
    [SerializeField]
    private bool hasGun = false;

    [SerializeField]
    private GameObject playerSword;
    [SerializeField]
    private bool hasSword = false;

    [SerializeField]
    private GameObject rocket;
    [SerializeField]
    private bool hasRketLncher = false;

    // handling jumps
    private bool jumping = false;
    private bool releaseJump = false;
    private bool startJumpTimer = false;
    private bool falling = false;

    [SerializeField]
    private float jumpDuration = .1f;
    [SerializeField]
    private float jumpTimer = .25f;

    // moving down after a jump
    private bool movingDown = false;

    // use Debug.DrawLine for the laser for now
    [SerializeField]
    private bool hasLaser = false;

    private bool switched = false;

    // Start is called before the first frame update
    void Start()
    {

        //   Scene currentScene = SceneManager.GetActiveScene();
        //   string sceneName = currentScene.name;
        //   if (sceneName != "Stage 1")
        //   {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName != "HUB" && sceneName != "Stage 1")
        {
            Damage(0);
            //   }
        }
        if (sceneName == "Stage 1")
        {
            hp = 100;
            //   }
        }
        myRB = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // player sprite blinks when hit
    IEnumerator Blink()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds((float)0.2);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds((float)0.2);
    }

    void HandleInvincible() {
        if (Invincible)
        {
            StartCoroutine(Blink());
            if (TimeSinceInvStarted + InvincibilityTime < Time.time)
            {
                Invincible = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        HandleInvincible();
        HandleInput();
        ProcessStatusEffects();
    }

    private void HandleInput()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); //Player can move
        transform.position += movement * Time.deltaTime * Speed;

        // for jumps
        if (Input.GetKeyDown("space") && canJump) {
            jumping = true;
        };
        if (Input.GetKeyUp("space")) { releaseJump = true; }

        if (startJumpTimer) {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0) { 
                releaseJump = true;
                startJumpTimer = false;
            }
        }


        // arrow key control scheme
        if (Input.GetKeyDown(KeyCode.DownArrow)) { movingDown = true; }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (ClickCountD == 1 && DoubleClickTimerD > 0)
            {
                transform.position += new Vector3(2f, 0f, 0f);
                ClickCountD = 0;
            }
            else
            {
                ClickCountA = 0;
                ClickCountD += 1;
                DoubleClickTimerD = .5f;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (ClickCountA == 1 && DoubleClickTimerA > 0)
            {
                transform.position += new Vector3(-2f, 0f, 0f);
                ClickCountA = 0;
            }
            else
            {
                ClickCountD = 0;
                ClickCountA += 1;
                DoubleClickTimerA = .5f;
            }
        }

        if (DoubleClickTimerD > 0)
        {
            DoubleClickTimerD -= 1 * Time.deltaTime;
        }
        else
        {
            ClickCountD = 0;
        }
        if (DoubleClickTimerA > 0)
        {
            DoubleClickTimerA -= 1 * Time.deltaTime;
        }
        else
        {
            ClickCountA = 0;
        }

        // flipping the player sprite
        if ((Input.GetKeyDown(KeyCode.RightArrow) && switched == true))
        {
            transform.Rotate(0f, 180f, 0f); //Player sprite flips
            switched = false;
        }
        else if ((Input.GetKeyDown(KeyCode.LeftArrow) && switched == false))
        {
            transform.Rotate(0f, 180f, 0f); //Player sprite flips
            switched = true;
        }

    }

    // for handling jumps
    private void StartJump() {
        myRB.gravityScale = 0;
        myRB.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        startJumpTimer = true;
    }

    private void StopJump()
    {
        myRB.gravityScale = 2f;
        jumping = false;
        releaseJump = false;
        jumpTimer = jumpDuration;
        falling = true;
    }

    private void MoveDown()
    {
        myRB.AddForce(new Vector2(0f, -2f), ForceMode2D.Impulse);
        movingDown = false;
    }

    private void FixedUpdate()
    {
        if (jumping) { StartJump(); }
        if (releaseJump) { StopJump(); }
        if (movingDown) { MoveDown(); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (falling)
        {
            canJump = true;
            falling = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }

    // for the invincibility blink effect
    private void DamageBlink() {
        if (statusEffect == StatusEffect.TookDamage) {
            myRenderer.enabled = !myRenderer.enabled;
            StartCoroutine(DamageBlinkTimer());
        }
    }
    private IEnumerator DamageBlinkTimer() {
        yield return new WaitForSeconds(0.25f);
        DamageBlink();
    }

    private void ApplyStatusEffect(StatusEffect e, float duration) {
        statusEffect = e;
        statusEffectTimeout = duration + Time.time;
        myRenderer.enabled = true;
        if (e == StatusEffect.TookDamage) { DamageBlink(); }
    }

    private void ProcessStatusEffects() {
        if (statusEffectTimeout < Time.time) {
            ApplyStatusEffect(StatusEffect.None, Mathf.Infinity);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!Invincible)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Damage(10);
                Invincible = true;
                TimeSinceInvStarted = Time.time;
            }
            if (collision.gameObject.tag == "Lightning")
            {
                Damage(15);
                Invincible = true;
                TimeSinceInvStarted = Time.time;
            }
            if (collision.gameObject.tag == "Ring" && circleFill_)
            {
                Damage(15);
                Invincible = true;
                TimeSinceInvStarted = Time.time;
            }
        }

        if (collision.GetComponent("Gun") != null & Input.GetKey(KeyCode.B))
        {
            hasGun = true;
            Destroy(collision.gameObject);
            //Able to buy gun
        }
    }

    void Damage(int dmg)
    {
        if (GenBar.shield)
        {
            GNBar.DecreaseHealth(dmg);
        }
        else
        {
            hp -= dmg;
            healthbar.ChangeHealth(hp);
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        canJump = true;
        // Taking damage from enemy will make player blink
        //if (col.gameObject.GetComponent<Enemy>())
        //{
        //    if (!(statusEffect == StatusEffect.TookDamage)
        //    {
        //        healthCounter.Lose(1);
        //        ApplyStatusEffect(StatusEffect.TookDamage, DamageInvincibilityPeriod);
        //        return; 
        //    }
        //}
    }
}
