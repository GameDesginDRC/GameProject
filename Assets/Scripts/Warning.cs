using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Blink()
    {
        float newTime = Time.time;
        while (Time.time < newTime + 3)
         {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds((float)0.2);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds((float)0.2);
         }
    }
}
