using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInText : MonoBehaviour
{
    Text the_text;
    bool fadedin = false;
    bool fadedout = false;

    private float untilnext;

    private void Start()
    {
        untilnext = 0;
        the_text = gameObject.GetComponent<Text>();
    }

    // can ignore the update, it's just to make the coroutines get called for example
    void Update()
    {
        untilnext += Time.deltaTime;

        if (untilnext > 1.5 && !fadedout)
        {
            fadedin = true;
            FadeTextToFullAlpha(1f, the_text);
        }

        if (untilnext > 9.0)
        {
            fadedout = false;
            FadeTextToZeroAlpha(1f, the_text);
        }
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
