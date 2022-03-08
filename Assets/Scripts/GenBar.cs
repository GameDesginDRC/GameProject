using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenBar : MonoBehaviour
{
    public Slider hpvalue;
    public static bool shield;
    public static bool start1;
    public static int maxSh;
    public static bool Sabill;
    private Player player_code;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "TUTORIAL" || sceneName == "Stage 1") {
            maxSh = 50;
        }
        if (Sabill)
        {
            maxSh += 50;
            Sabill = false;
        }
        hpvalue.maxValue = maxSh;
        shield = false;
        start1 = false;
        Player.shieldon = false;
    }



    void FixedUpdate()
    {
        if (start1)
        {
            Player.shieldon = true;
            start1 = false;
            hpvalue.value =  maxSh;
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
