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

    // Start is called before the first frame update
    void Start()
    {
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
<<<<<<< Updated upstream
            GameObject newBullet = Instantiate(bullet, shootLoc + (-transform.right), bullet.transform.rotation);
=======
            GameObject newBullet = Instantiate(bullet, shootLoc + (-transform.right * .5f), bullet.transform.rotation);
>>>>>>> Stashed changes
            newBullet.GetComponent<Rigidbody2D>().velocity = shootSpeed * -transform.right;
        }
        else
        {
<<<<<<< Updated upstream
            GameObject newBullet = Instantiate(bullet, shootLoc + (-transform.right), bullet.transform.rotation);
=======
            GameObject newBullet = Instantiate(bullet, shootLoc + (-transform.right * .5f), bullet.transform.rotation);
>>>>>>> Stashed changes
            newBullet.GetComponent<Rigidbody2D>().velocity = shootSpeed * -transform.right;
        }

    }

    // Update is called once per frame
    void Update()
    {

        /*
        // move right and left
        if (!isPaused)
        {
            Vector3 HorzVector = new Vector3(5, 0.0f, 0.0f);
            transform.Translate(HorzVector * Time.deltaTime);
        }

        // pause for 2 seconds
        if (Time.time > nextFlip)
        {
            isPaused = true;
            Invoke("InvokeFlip", 2);
            nextFlip = Time.time + 2 + flipEveryXSecs;
        }
        */

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
                Shoot();
                nextShootTime = Time.time + shootevery;
            }

            Debug.Log("Player spotted");
        }

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
}
