using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanJump : MonoBehaviour
{
    [SerializeField]
    public static bool canJump =false;

  

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("MovPlatform"))
        {
            canJump = true;
            print("true");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canJump = false;
        print("false");
    }
}
