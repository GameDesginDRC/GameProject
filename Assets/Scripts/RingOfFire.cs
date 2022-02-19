using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfFire : MonoBehaviour
{
    [SerializeField]
    Transform rotationCenter;
    [SerializeField]
    float rotationradius = 10f, angularspeed = 4f, rotatespdz = 12f;

    private Vector2 rotatespd;

    float posX, posY, angle = 0f;

    private float incr;

    // Start is called before the first frame update
    void Start()
    {
        incr = 0;
    }

    // Update is called once per frame
    void Update()
    {
        incr = incr + .3f;
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationradius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationradius;
        transform.position = new Vector2(posX, posY);
        transform.Rotate(0, 0, rotatespdz);
        angle = angle + Time.deltaTime * angularspeed;
        if (angle >= 360)
        {
            angle = 0f;
        }
    }
}
