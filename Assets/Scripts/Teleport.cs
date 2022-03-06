using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : MonoBehaviour
{
    [SerializeField]
    public static bool canTeleport = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Wall"))
        {
            canTeleport = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTeleport = true;
    }
}
