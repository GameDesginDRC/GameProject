using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assasin_Controller : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    private Player player_code;
    public Rigidbody2D rb;

    public float speed = 6f;
    [SerializeField]
    float health = 30;


    public Transform WallCheck; //Checks Front
    public Vector2 WallChecksize; //FrontCheck Size

    public Transform TargetCheck; //Checks availability of Target
    public Vector2 TargetChecksize; //TargetCheck Size

    public Transform GroundCheck; //Checks if Target is in Range of Enemy
    public Vector2 GroundChecksize; //RangeCheck Size

    public Transform AttackCheck; //Checks if Target is in Range of Enemy
    public Vector2 AttackChecksize; //RangeCheck Size

    public Transform AttackBox; //Checks if Target is in Range of Enemy
    public Vector2 AttackBoxsize; //RangeCheck Size

    public Transform TeleportAttackBox; //Checks if Target is in Range of Enemy
    public Vector2 TeleportAttackBoxsize; //RangeCheck Size

    private bool _CanMove = false; //Enemy can move
    private bool _IsFlipped = false; //Enemy is flipped
    private bool _PlayerSpotted = false; //Player has been spotted
    // private bool _PlayerFollow = false; //Stops following Player

    private float idlespeed = .19f;
    Vector3 idleA;
    Vector3 idleB;

    [SerializeField]
    float invincibleTime = 1f;
    [SerializeField]
    bool invincible = false;
    bool dying = false;

    // for audio
    AudioSource aSource;
    [SerializeField]
    AudioClip slashSound;
    [SerializeField]
    AudioClip hitSound;
    [SerializeField]
    AudioClip deathSound;


    void Start()
    {
        idleA = new Vector3(transform.position.x-0.5f, transform.position.y, 0);
        idleB = new Vector3(transform.position.x+2, transform.position.y, 0);
        player_code = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        aSource = (AudioSource)FindObjectOfType(typeof(AudioSource));

        EnemyMovement(); //Controls Enemy Movement
        DetectPlayer(); //Dectects if Player is in range
        TakeDamage();
    }

    public void Attack()
    {
        if (AttackBoxBool() || TeleportAttackBoxBool())
        {
            aSource.PlayOneShot(hitSound);
            player_code.Damage(10);
            player_code.Invincible = true;
            player_code.TimeSinceInvStarted = Time.time;
            player_code.Invoke("Recolor", .05f);
        }
    }

    void Teleport()
    {
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        rb.MovePosition(target);
        animator.SetTrigger("Teleport");
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x < player.position.x && _IsFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            _IsFlipped = false;
        }
        else if (transform.position.x > player.position.x && !_IsFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            _IsFlipped = true;
        }
    }
    
    private void DetectPlayer()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            Vector3 flipped = transform.localScale;
            flipped.z *= -1f;
            float time = Mathf.PingPong(Time.time * idlespeed, 1);
            transform.position = Vector3.Lerp(idleA, idleB, time);
        }

        if (TargetCheckBool())
        { 
            _PlayerSpotted = true; //Player has been spotted
        }
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") 
        || animator.GetCurrentAnimatorStateInfo(0).IsName("Teleport")
        || animator.GetCurrentAnimatorStateInfo(0).IsName("Intro"))
        {
            _CanMove = false;
        }
        else if (TargetCheckBool() && !AttackCheckBool()) //If Player is in Enemy range
        {
            _CanMove = true;
            animator.SetBool("Engage", true);
            LookAtPlayer();
        }
        else if (AttackCheckBool())
        {
            animator.SetTrigger("Attack");
        }
        else if (!TargetCheckBool() && _PlayerSpotted)
        {
            Teleport();
        }
        else if (!WallCheckBool() && GroundCheckBool() && !_PlayerSpotted)
        //When Enemy is not next to a wall, is grounded, and Player has not been spotted
        {
            _CanMove = false; //Enemy moves
            animator.SetBool("Engage", false);
        }
 
    }

    private void EnemyMovement()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime); 
        if (!GroundCheckBool())
        //When Enemy is not grounded
        {
            target = new Vector2(rb.position.x, player.position.y);
            rb.MovePosition(target);
        }
        else if (_CanMove && TargetCheckBool() && !AttackCheckBool() && GroundCheckBool()) //If Enemy can move
        {
            rb.MovePosition(newPos);
        }
        
    }


    public void TakeDamage() //Enemy takes damage
    {
        if (health <= 0 && !dying)
        {
            dying = true;
            gameObject.tag = "Untagged";
            Die();
        }
    }

    void Die() //Enemy erasure
    {
        aSource.PlayOneShot(deathSound);
        animator.SetTrigger("Death");
        Invoke("RemoveFromGame", 0.6f);
    }

    void RemoveFromGame()
    {
        LevelManager.DecreaseEnemyNum();
        ScoreKeeper.gold += 10;
        ScoreKeeper.AddToGold(0);
        Destroy(gameObject);
    } 

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack")&& !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") )
        {
            // decrease HP and pause
            if (!invincible && !dying)
            {
                aSource.PlayOneShot(hitSound);
                float attackVal = collision.GetComponent<PAttack>().AttackValue;
                health -= attackVal;
                invincible = true;
                if (health > 0){
                    animator.SetTrigger("Hit");
                }
                
                Invoke("invinCooldown", invincibleTime);
            }
        }
    }

    void invinCooldown()
    {
        invincible = false;
    }



    private void OnDrawGizmosSelected() //Draws boxes to show trigger
    {
        Gizmos.DrawWireCube(GroundCheck.position, GroundChecksize);
        Gizmos.DrawWireCube(WallCheck.position, WallChecksize);
        Gizmos.DrawWireCube(TargetCheck.position, TargetChecksize);
        Gizmos.DrawWireCube(AttackCheck.position, AttackChecksize);
        Gizmos.DrawWireCube(AttackBox.position, AttackBoxsize);
        Gizmos.DrawWireCube(TeleportAttackBox.position, TeleportAttackBoxsize);
    }

    private bool GroundCheckBool() //Ground Check
    {
        return Physics2D.OverlapBox(GroundCheck.position, GroundChecksize, 0, LayerMask.GetMask("Wall"));
    }

    private bool WallCheckBool() //Wall Check
    {
        return Physics2D.OverlapBox(WallCheck.position, WallChecksize, 0, LayerMask.GetMask("Wall"));
    }

    private bool TargetCheckBool() //When Player is facing Enemy
    {
        return Physics2D.OverlapBox(TargetCheck.position, TargetChecksize, 0, LayerMask.GetMask("Player"));
    }

    private bool AttackCheckBool() //When Player is in range of Enemy
    {
        return Physics2D.OverlapBox(AttackCheck.position, AttackChecksize, 0, LayerMask.GetMask("Player"));
    }

    private bool AttackBoxBool() //When Player is in range of Enemy
    {
        return Physics2D.OverlapBox(AttackBox.position, AttackBoxsize, 0, LayerMask.GetMask("Player"));
    }

    private bool TeleportAttackBoxBool() //When Player is in range of Enemy
    {
        return Physics2D.OverlapBox(TeleportAttackBox.position, TeleportAttackBoxsize, 0, LayerMask.GetMask("Player"));
    }
}

