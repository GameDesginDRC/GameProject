using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRobot : MonoBehaviour
{
    // health
<<<<<<< Updated upstream
    public float health = 10;

    // for movement
    public float speed = .5f;

    public float flipEveryXSecs = 1f;
    public float nextFlip = 0f;

    public bool isPaused = false;
    public bool movingRight = true;
=======
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

    // for attacking
    [SerializeField]
    bool onCooldown = false;
    [SerializeField]
    float nextAttack = 0;
    [SerializeField]
    GameObject theAttack;

>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
    }

<<<<<<< Updated upstream
=======
    void Wait() {
        theAttack.tag = "Untagged";
    }

    void Attack() {
        theAttack.tag = "Enemy";
    }


>>>>>>> Stashed changes
    void InvokeFlip() {
        if (movingRight)
        {
            // flip left
            transform.rotation = Quaternion.Euler(0, 0, 0);
            movingRight = false;
        }
        else {
            // flip right
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            movingRight = true;
        }

        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
=======
        // attack cooldown check
        if (Time.time > nextAttack) {
            onCooldown = false;
        }

>>>>>>> Stashed changes
        // move right and left
        if (!isPaused)
        {
            Vector3 HorzVector = new Vector3(5, 0.0f, 0.0f);
            transform.Translate(HorzVector * Time.deltaTime);
        }

<<<<<<< Updated upstream
=======
        /*
>>>>>>> Stashed changes
        // pause for 2 seconds
        if (Time.time > nextFlip)
        {
            isPaused = true;
            Invoke("InvokeFlip", 2);
            nextFlip = Time.time + 2 + flipEveryXSecs;
        }
<<<<<<< Updated upstream
    }

    
=======
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!onCooldown)
            {
                isPaused = true;
                // half a second before attack
                Invoke("Attack", .5f);
                // Attack
                Debug.Log("Attack!");

                nextAttack = Time.time + 1f;
            }
        }

        if (collision.CompareTag("Wall"))
        {
            Debug.Log("Flip");
            isPaused = true;
            InvokeFlip();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPaused = false;
        }
    }

>>>>>>> Stashed changes
}
