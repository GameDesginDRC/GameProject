using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAbilities : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Z))
            { 
                Destroy(gameObject);
            }

               
        }
    }
}
