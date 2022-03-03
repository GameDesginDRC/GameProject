using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenBar : MonoBehaviour
{
    public Slider hpvalue;
    public static bool shield;
    public static bool start1;
    private Player player_code;

    // Start is called before the first frame update
    void Start()
    {
        shield = false;
        start1 = false;
    }



    void FixedUpdate()
    {
        if (start1)
        {
            Player.shieldon = true;
            start1 = false;
            hpvalue.value =  Player.max_shield;
        }
        if (shield)
        {
            
            hpvalue.value -= .2f;
            if (hpvalue.value == 0)
            {
                shield = false;
                Player.shieldon = false;
            }

        }
    }

    public void DecreaseHealth(int dmg)
    {
        hpvalue.value -= dmg;
    }
}
