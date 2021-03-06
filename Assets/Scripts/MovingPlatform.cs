using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // control what direction it moves
    [SerializeField]
    private bool movingVer;
    [SerializeField]
    private bool movingHors;
    [SerializeField]
    private float moveOtherDir = 1;
    // control how much it moves
    [SerializeField]
    private float moveTimeAmt;
    [SerializeField]
    private float moveTimer;
    // control how fast it moves
    [SerializeField]
    private float moveSpeed;

    bool isPaused = false;
    [SerializeField]
    private float pauseTimeAmt;
    // control how fast it moves
    [SerializeField]
    private float pauseTimer;

    // Start is called before the first frame update
    void Start()
    {
        moveTimer = moveTimeAmt;
    }

    void Unpause()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused) moveTimer -= Time.deltaTime;

        if (moveTimer <= 0) {
            isPaused = true;
            moveOtherDir *= -1;
            moveTimer = moveTimeAmt;
            Invoke("Unpause", 1f);
        }

        if (movingHors && !isPaused)
        {
            Vector3 HorzVector = new Vector3(moveOtherDir * moveSpeed, 0.0f, 0.0f);
            transform.Translate(HorzVector * Time.deltaTime);
        }
        else if (movingVer && !isPaused) {
            Vector3 VertVector = new Vector3(0.0f, moveOtherDir * moveSpeed, 0.0f);
            transform.Translate(VertVector * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
    }
}
