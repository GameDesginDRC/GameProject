using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHit : MonoBehaviour
{
    public Transform pos;
    public static bool traped =true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(traped)
        {
            collision.gameObject.GetComponent<Player>().Damage(10);
            collision.gameObject.transform.position = new Vector3(pos.position.x+0.05f, pos.position.y +0.5f, 0f);
            traped = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        traped = true;
    }
}
