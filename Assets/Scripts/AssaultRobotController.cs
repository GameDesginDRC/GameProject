using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRobotController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public Transform player;

    private float speed;
    private float shootSpeed = 10f;
    [SerializeField]
    float health = 30;

    public Transform WallCheck; //Checks Front
    public Vector2 WallChecksize; //FrontCheck Size

    public Transform BackWallCheck; //Checks Back
    public Vector2 BackWallChecksize; //BackCheck Size

    public Transform TargetCheck; //Checks availability of Target
    public Vector2 TargetChecksize; //TargetCheck Size

    public Transform GroundCheck; //Checks if Target is in Range of Enemy
    public Vector2 GroundChecksize; //RangeCheck Size

    public Transform AttackCheckH; //Checks if Target is in Range of Enemy
    public Vector2 AttackCheckHsize; //RangeCheck Size

    public Transform AttackCheckL; //Checks if Target is in Range of Enemy
    public Vector2 AttackCheckLsize; //RangeCheck Size

    private bool _CanMove = false; //Enemy can move
    private bool _IsFlipped = false; //Enemy is flipped
    // private bool _PlayerFollow = false; //Stops following Player

    private float idlespeed = .19f;

    private float invincibleTime = 1f;
    [SerializeField]
    bool invincible = false;
    bool dying = false;
    private bool flee = false;
    SpriteRenderer sprite;

    // for audio
    AudioSource aSource;
    [SerializeField]
    AudioClip shootSound;
    [SerializeField]
    AudioClip hitSound;
    [SerializeField]
    AudioClip deathSound;

    public Transform CastPointH;
    public Transform CastPointL;
    public GameObject bullet;



    void Start()
    {
        speed= 5f;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        aSource = (AudioSource)FindObjectOfType(typeof(AudioSource));
        DetectPlayer(); //Dectects if Player is in range
        EnemyMovement(); //Controls Enemy Movement
        TakeDamage();
    }


    public void AttackHigh()
    {
        aSource.PlayOneShot(shootSound);
        if (_IsFlipped)
            {
                GameObject newBullet = Instantiate(bullet, CastPointH.position, bullet.transform.rotation);
                newBullet.GetComponent<Rigidbody2D>().velocity = shootSpeed * transform.right;
            }
        else
            {
                GameObject newBullet = Instantiate(bullet, CastPointH.position, bullet.transform.rotation);
                newBullet.GetComponent<Rigidbody2D>().velocity = shootSpeed * transform.right;
            }
    }
    
    public void AttackLow()
    {
        aSource.PlayOneShot(shootSound);
        if (_IsFlipped)
        {
            GameObject newBullet = Instantiate(bullet, CastPointL.position, bullet.transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().velocity = shootSpeed * transform.right;
        }
        else
        {
            GameObject newBullet = Instantiate(bullet, CastPointL.position, bullet.transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().velocity = shootSpeed * transform.right;
        }
    }

    public void LookAtPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();

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
        if (!flee && !TargetCheckBool())
        {
            _CanMove = false;
            animator.SetBool("Walk", true);
            animator.SetBool("Attack", false); 
        }
        else if (!AttackCheckHBool() && !AttackCheckLBool() && !flee && TargetCheckBool() && !WallCheckBool()) //If Player is in Enemy range
        {
            _CanMove = true;
            animator.SetBool("Walk", true);
            animator.SetBool("Attack", false); 
            LookAtPlayer();
        }
        else if (AttackCheckLBool() && !flee && !WallCheckBool())
        {
            _CanMove = false;
            animator.SetBool("Walk", false);
            animator.SetBool("High", false);
            animator.SetBool("Attack", true);  
        }
        else if (AttackCheckHBool() && !flee)
        {
            _CanMove = false;
            animator.SetBool("Walk", false);
            animator.SetBool("High", true);
            animator.SetBool("Attack", true);  
        }
        else if (GroundCheckBool() && TargetCheckBool()&& !flee)
        //When Enemy is not next to a wall, is grounded, and Player has not been spotted
        {
            _CanMove = false; //Enemy moves
            animator.SetBool("Walk", true);
            animator.SetBool("Attack", false); 
        }
 
    }

    private void EnemyMovement()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime); 
        if (WallCheckBool() && !TargetCheckBool())
        {
            _CanMove = false;
            LookAtPlayer();
        }
        else if (!GroundCheckBool() && CanJump.canJump)
        //When Enemy is not grounded
        {
            target = new Vector2(rb.position.x, player.position.y);
            rb.MovePosition(target);
        }
        else if (!flee && _CanMove && TargetCheckBool() && !AttackCheckHBool() && !AttackCheckLBool() && GroundCheckBool()) //If Enemy can move
        {
            rb.MovePosition(newPos);
        }
        else if (flee && !WallCheckBool() && _CanMove)
        {
            newPos = Vector2.MoveTowards(rb.position, target, -1* 7f * Time.fixedDeltaTime); 
            rb.MovePosition(newPos);
        }
        
    }


    public void TakeDamage() //Enemy takes damage
    {
        if (health <= 0 && !dying)
        {
            dying = true;
            gameObject.tag = "Untagged";
            _CanMove=false;
            Die();
        }
    }

    void Die() //Enemy erasure
    {
        aSource.PlayOneShot(deathSound);
        animator.SetTrigger("Death");
        Invoke("RemoveFromGame", 0.4f);
    }

    void RemoveFromGame()
    {
        Destroy(gameObject);
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
                health -= attackVal;
                invincible = true;
                if (health > 0){
                    animator.SetTrigger("Hit");
                }
                
                if(!BackWallCheckBool())
                {
                    animator.SetBool("Walk", true);
                    animator.SetBool("Attack", false); 
                    _CanMove = true;
                    flee= true;
                    transform.Rotate(0f, 180f, 0f);
                    Invoke("invinCooldown", invincibleTime);
                }
                else{
                    Invoke("invinCooldown2", invincibleTime);
                }
                

            }
        }
    }

    void invinCooldown()
    {
        transform.Rotate(0f, 180f, 0f);
        invincible = false;
        flee=false;
    }

    void invinCooldown2()
    {
        invincible = false;
    }


    private void OnDrawGizmosSelected() //Draws boxes to show trigger
    {
        Gizmos.DrawWireCube(GroundCheck.position, GroundChecksize);
        Gizmos.DrawWireCube(WallCheck.position, WallChecksize);
        Gizmos.DrawWireCube(BackWallCheck.position, BackWallChecksize);
        Gizmos.DrawWireCube(TargetCheck.position, TargetChecksize);
        Gizmos.DrawWireCube(AttackCheckH.position, AttackCheckHsize);
        Gizmos.DrawWireCube(AttackCheckL.position, AttackCheckLsize);
    }

    private bool GroundCheckBool() //Ground Check
    {
        return Physics2D.OverlapBox(GroundCheck.position, GroundChecksize, 0, LayerMask.GetMask("Wall"));
    }

    private bool BackWallCheckBool() //Wall Check
    {
        return Physics2D.OverlapBox(BackWallCheck.position, BackWallChecksize, 0, LayerMask.GetMask("Wall"));
    }

    private bool WallCheckBool() //Wall Check
    {
        return Physics2D.OverlapBox(WallCheck.position, WallChecksize, 0, LayerMask.GetMask("Wall"));
    }

    private bool TargetCheckBool() //When Player is facing Enemy
    {
        return Physics2D.OverlapBox(TargetCheck.position, TargetChecksize, 0, LayerMask.GetMask("Player"));
    }

    private bool AttackCheckHBool() //When Player is in range of Enemy
    {
        return Physics2D.OverlapBox(AttackCheckH.position, AttackCheckHsize, 0, LayerMask.GetMask("Player"));
    }

    private bool AttackCheckLBool() //When Player is in range of Enemy
    {
        return Physics2D.OverlapBox(AttackCheckL.position, AttackCheckLsize, 0, LayerMask.GetMask("Player"));
    }

}
