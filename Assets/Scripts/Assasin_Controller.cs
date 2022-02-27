using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assasin_Controller : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update

    void Update()
    {
        animator.SetBool("Engage", true);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }
}

