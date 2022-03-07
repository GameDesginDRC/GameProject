using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    private float untilnext;
    // Start is called before the first frame update
    void Start()
    {
        untilnext = 0;
    }

    // Update is called once per frame
    void Update()
    {
        untilnext += Time.deltaTime;
        if(transform.position.y < 3260) transform.position += new Vector3(0, .2f, 0);
        if (untilnext >= 105)
        {
            SceneManager.LoadScene("TITLESCREEN");
        }
    }
}
