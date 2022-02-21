using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assasin_Controller : MonoBehaviour
{
    private Animator AssasinAnimator;
    // Start is called before the first frame update
    void Start()
    {
        AssasinAnimator = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
            AssasinAnimator.SetBool("Walk", true);
            AssasinAnimator.SetBool("Hit", false);
            AssasinAnimator.SetBool("Engage", false);
            AssasinAnimator.SetBool("Teleport", false);
            AssasinAnimator.SetBool("Attack", false);
            AssasinAnimator.SetBool("Death", false);
        }
        if (Input.GetKeyDown(KeyCode.W)){
            AssasinAnimator.SetBool("Walk", false);
            AssasinAnimator.SetBool("Hit", true);
            AssasinAnimator.SetBool("Engage", false);
            AssasinAnimator.SetBool("Teleport", false);
            AssasinAnimator.SetBool("Attack", false);
            AssasinAnimator.SetBool("Death", false);
        }
        if (Input.GetKeyDown(KeyCode.E)){
            AssasinAnimator.SetBool("Walk", false);
            AssasinAnimator.SetBool("Hit", false);
            AssasinAnimator.SetBool("Engage", true);
            AssasinAnimator.SetBool("Teleport", false);
            AssasinAnimator.SetBool("Attack", false);
            AssasinAnimator.SetBool("Death", false);
        }
        if (Input.GetKeyDown(KeyCode.R)){
            AssasinAnimator.SetBool("Walk", false);
            AssasinAnimator.SetBool("Hit", false);
            AssasinAnimator.SetBool("Engage", false);
            AssasinAnimator.SetBool("Teleport", true);
            AssasinAnimator.SetBool("Attack", false);
            AssasinAnimator.SetBool("Death", false);
        }
        if (Input.GetKeyDown(KeyCode.T)){
            AssasinAnimator.SetBool("Walk", false);
            AssasinAnimator.SetBool("Hit", false);
            AssasinAnimator.SetBool("Engage", false);
            AssasinAnimator.SetBool("Teleport", false);
            AssasinAnimator.SetBool("Attack", true);
            AssasinAnimator.SetBool("Death", false);
        }
        if (Input.GetKeyDown(KeyCode.T)){
            AssasinAnimator.SetBool("Walk", false);
            AssasinAnimator.SetBool("Hit", false);
            AssasinAnimator.SetBool("Engage", false);
            AssasinAnimator.SetBool("Teleport", false);
            AssasinAnimator.SetBool("Attack", false);
            AssasinAnimator.SetBool("Death", true);
        }
    }
}
