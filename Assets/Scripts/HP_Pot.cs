using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP_Pot : MonoBehaviour
{
    public GameObject empty1;
    public static bool used;
    public int usednum = 0;
    private Scene currentScene;
    string sceneName;
    public static int HPpot_count = 0;
    public static int hpIncr = 0;
    private float waitTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = .2f;
        hpIncr = 0;
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Informant.bought_pot = true;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.U) && sceneName != "Shop 1" && waitTime <= 0)
        {
            waitTime = .2f;
            UseHPPot();
        } else
        {
            waitTime -= Time.deltaTime;
        }
    }

    private void DecrConsume(int ind)
    {
        if (ind == 2)
        {
            ConsumeCountText.ChangeConsume(-1);
        }
        else if (ind == 3)
        {
            ConsumeText2.ChangeConsume2(-1);
        }
        else if (ind == 4)
        {
            ConsumeText3.ChangeConsume3(-1);
        }
    }

    void UseHPPot()
    {
        //Debug.Log(usednum);
        // look at this code, should be when == 1???
        if (HPpot_count == 1)
        {
            DecrConsume(usednum);
            HPpot_count--;
            Inventory.pos_objs[usednum] = empty1;
            Inventory._full[usednum] = false;
            Player.hp += 35;
            if (Player.hp > 100)
            {
                Player.hp = 100;
            }
            hpIncr = 1;
            Destroy(gameObject);
        }
        else
        {
            DecrConsume(usednum);
            HPpot_count--;
            Player.hp += 15;
            if (Player.hp > 100)
            {
                Player.hp = 100;
            }
            hpIncr = 1;
        }
    }
}
