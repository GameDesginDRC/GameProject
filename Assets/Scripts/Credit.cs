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
        transform.position += new Vector3(0, .8f, 0);
        if (untilnext >= 15)
        {
            SceneManager.LoadScene("TITLESCREEN");
        }
    }
}
