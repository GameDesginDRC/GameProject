using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenBar : MonoBehaviour
{
    public Slider hpvalue;
    public static bool shield;
    public static bool start1;
    // Start is called before the first frame update
    void Start()
    {
        shield = false;
        start1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (start1)
        {
            start1 = false;
            hpvalue.value = 100;
        }
        if (shield)
        {
            hpvalue.value -= .25f;
            if (hpvalue.value == 0)
            {
                shield = false;
            }

        }
    }

    public void DecreaseHealth(int dmg)
    {
        hpvalue.value -= dmg;
    }
}
