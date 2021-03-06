using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInText : MonoBehaviour
{
    Text the_text;
    [SerializeField]
    bool fadedin = false;
    [SerializeField]
    bool fadedout = false;
    bool pressedZ = false;
    [SerializeField]
    private float untilnext;

    private void Start()
    {
        untilnext = 0;
        the_text = gameObject.GetComponent<Text>();
    }

    // can ignore the update, it's just to make the coroutines get called for example
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !pressedZ)
        {
            pressedZ = true;
            StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<Text>()));
            Invoke("LoadTransition1", 2f);
        }
    }


    void LoadTransition1()
    {
        SceneManager.LoadScene("Transition1");
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
