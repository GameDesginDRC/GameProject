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

    // Start is called before the first frame update
    void Start()
    {
        moveTimer = moveTimeAmt;
        nextDropTime = dropEvery;
    }

    void Unpause() {
        isPaused = false;
        timerOn = true;
    }

    // drop a mine
    void Drop()
    {
        Instantiate(mine, transform.position, transform.rotation);
        Invoke("Unpause", 1f);
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
            moveOtherDir *= -1;
            moveTimer = moveTimeAmt;
            Invoke("Unpause", 1f);
        }

        if (!isPaused)
        {
            Vector3 HorzVector = new Vector3(moveOtherDir * moveSpeed, 0.0f, 0.0f);
            transform.Translate(HorzVector * Time.deltaTime);
        }

        if(nextDropTime > 0) nextDropTime -= Time.deltaTime;

        // check to see if player is in range
        if (PlayerInSight(aggroRange))
        {

            // drop a mine
            if (nextDropTime < 0)
            {
                isPaused = true;
                timerOn = false;
                Invoke("Drop", .5f);
                nextDropTime = dropEvery;
            }
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
        Debug.DrawLine(castPoint.position, EndofSight, Color.red);

        return val;
    }
}
