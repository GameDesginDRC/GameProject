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
    [SerializeField] string gameOver;

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
    // for dashes
    public bool dashInvincible = false;
    public float dashInvicTime = .5f;
    public float TimeSinceDashInv;

    public HPBar healthbar = null;
    public GenBar GNBar = null;

    [SerializeField]
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

    // sprite handling
    SpriteRenderer sprite;
    Color spriteColor;

    // for audio
    

    // Start is called before the first frame update
    void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
        spriteColor = sprite.color;

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
        }
        if (sceneName == "TUTORIAL")
        {
            hp = 100;
        }
        myRB = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
    }


    void HandleInvincible() {
        if (Invincible)
        {
            if (TimeSinceInvStarted + InvincibilityTime < Time.time)
            {
                sprite.color = spriteColor;
                Invincible = false;
            }
        }

        if (dashInvincible)
        {
            TimeSinceInvStarted -= Time.deltaTime;
            if (TimeSinceInvStarted < 0) dashInvincible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleInvincible();
        HandleInput();
        //ProcessStatusEffects();

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (hp <= 0 && sceneName != "Shop 1" && sceneName != "Shop 2" && sceneName != "Shop 3" && sceneName != "Shop 4" && sceneName != "Shop 5" && sceneName != "Shop 6" && sceneName != "HUB")
        {
            SceneManager.LoadScene(gameOver);
        }

        if (HP_Pot.hpIncr == 1)
        {
            HP_Pot.hpIncr = 0;
            Damage(0);
        }
    }

    private void HandleInput()
    {
        // for jumps
        if ((Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.UpArrow)) && canJump) {
            jumping = true;
        };
        if (Input.GetKeyUp("space") || Input.GetKeyUp(KeyCode.UpArrow)) { releaseJump = true; }

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
                // add i-frames
                dashInvincible = true;
                TimeSinceDashInv = dashInvicTime;

                transform.position += new Vector3(2f, 0f, 0f);
                ClickCountD = 0;
            }
            else
            {
                ClickCountA = 0;
                ClickCountD += 1;
                DoubleClickTimerD = .2f;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (ClickCountA == 1 && DoubleClickTimerA > 0)
            {
                // add i-frames
                dashInvincible = true;
                TimeSinceDashInv = dashInvicTime;

                transform.position += new Vector3(-2f, 0f, 0f);
                ClickCountA = 0;
            }
            else
            {
                ClickCountD = 0;
                ClickCountA += 1;
                DoubleClickTimerA = .2f;
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
        myRB.AddForce(new Vector2(0f, -10f), ForceMode2D.Impulse);
        movingDown = false;
    }

    private void FixedUpdate()
    {
        if (jumping) { StartJump(); }
        if (releaseJump) { StopJump(); }
        if (movingDown) { MoveDown(); }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); //Player can move
        transform.position += movement * Time.deltaTime * Speed;

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

    /*
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
    */
    void Recolor()
    {
        Color transparentColor = spriteColor;
        transparentColor.a = .50f;
        sprite.color = transparentColor;
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
                Invoke("Recolor", .05f);
            }
            if (collision.gameObject.tag == "Lightning")
            {
                Damage(15);
                Invincible = true;
                TimeSinceInvStarted = Time.time;
                Invoke("Recolor", .05f);
            }
            if (collision.gameObject.tag == "Ring" && circleFill_)
            {
                Damage(15);
                Invincible = true;
                TimeSinceInvStarted = Time.time;
                Invoke("Recolor", .05f);
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
    }

    
}
