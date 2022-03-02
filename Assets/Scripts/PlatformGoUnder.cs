using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGoUnder : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.DownArrow)) {
        //   waitTime = .001f;
        //}
        if(Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKey(KeyCode.Space))
        {
        //   if (waitTime <= 0)
         //   {
                effector.rotationalOffset = 180f;
                StartCoroutine(Blink());
        //        waitTime = .001f;
         //   } else
          //  {
          //     waitTime -= Time.deltaTime;
          //  }
        }

   //     if(Input.GetKey(KeyCode.Space))
   //     {
    //        effector.rotationalOffset = 0;
    //    }
    }
    IEnumerator Blink()
    {
        yield return new WaitForSeconds(.2f);
        effector.rotationalOffset = 0;
    }
}
