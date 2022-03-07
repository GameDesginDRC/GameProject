using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ExplodeAndDie() {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" || col.tag == "Wall") Invoke("ExplodeAndDie", .1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("ExplodeAndDie", .01f);
    }

}
