using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public DestroyWall[] wallsArray;

    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == ("Player") & Input.GetKey(KeyCode.Z))
        {
            Destroy(gameObject); 
            foreach(DestroyWall wall in wallsArray)
            {
                wall.DestroyableWall(); //Destroys platform linked to pickup
            }
        }
    }
}
