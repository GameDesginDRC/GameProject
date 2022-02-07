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
        Invoke("ExplodeAndDie", .1f);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
