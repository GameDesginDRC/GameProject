using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == ("Player") & Input.GetKey(KeyCode.Z))
        {
            //End Game
        }
    }
}
