using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConductorCircle : MonoBehaviour
{
    private SpriteRenderer spr;
    private Color tmp;
    private bool ready_;
    private float rotatespdz = 12f;
    // Start is called before the first frame update
    void Start()
    {
        Player.circleFill_ = false;
        transform.localPosition = new Vector3(-.06f, -.39f, 0);
        ready_ = true;
        spr = gameObject.GetComponent<SpriteRenderer>();
        tmp = spr.color;
        tmp.a = 0;
        spr.color = tmp;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotatespdz);
        if (ready_ && tmp.a <= .97f)
        {
            tmp.a += .004f;
            spr.color = tmp;
        } else
        {
            Player.circleFill_ = true;
            ready_ = false;
            StartCoroutine(Grow());
        }
    }
    IEnumerator Grow()
    {
        yield return new WaitForSeconds(3);
        Player.circleFill_ = false;
        ready_ = true;
        tmp.a = 0;
        spr.color = tmp;
    }
}
