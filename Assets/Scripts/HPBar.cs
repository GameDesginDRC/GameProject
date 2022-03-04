using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPBar : MonoBehaviour
{
    public Slider hpvalue;
    public static bool abill;
    public static int maxVal;
    // Start is called before the first frame update
    // private Player player_code;
    void Start()
    {
        // player_code = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //  Debug.Log(hpvalue.value);
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "TUTORIAL" || sceneName == "Stage 1")
        {
            maxVal = 100;
        }
        int waitE = 0;
        if (abill && waitE == 0)
        {
            maxVal += 50;
            hpvalue.value = Player.hp;
            abill = false;
            waitE = 1;
        }
        hpvalue.maxValue = maxVal;
        hpvalue.value = Player.hp;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Shop 1");
        }
    }

    public void ChangeHealth(int hp)
    {
        hpvalue.value = hp;
    }
}
