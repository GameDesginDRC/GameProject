using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRB;
    private SpriteRenderer myRenderer;
    public enum StatusEffect { None, TookDamage };
    private StatusEffect statusEffect;
    private float statusEffectTimeout;


    public float Speed = 10f;
    public float JumpForce = 10f;
    public float DamageInvincibilityPeriod = 5f;
    public float DoubleClickTimerD = .5f;
    public float DoubleClickTimerA = .5f;
    private bool canJump = false;
    private bool hasGun = false;
    private int ClickCountD = 0;
    private int ClickCountA = 0;

    public HPBar healthbar;
    public GenBar GNBar;
    public static int hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        myRB = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        ProcessStatusEffects();
    }

    private void HandleInput()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); //Player can move
        transform.position += movement * Time.deltaTime * Speed;
        if (InputJump())
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse); ;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (ClickCountD == 1 && DoubleClickTimerD>0)
            {
                transform.position += new Vector3(2f, 0f, 0f);
                ClickCountD = 0;
            }   
            else
            {
                ClickCountD += 1;
                DoubleClickTimerD = .5f;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Damage(2);
            if (ClickCountA == 1 && DoubleClickTimerA > 0)
            {
                transform.position += new Vector3(-2f, 0f, 0f);
                ClickCountA = 0;
            }
            else
            {
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
    }

    private bool InputJump() {
        var inp = Input.GetKeyDown("space");
        return inp && canJump;
    }

 


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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
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
