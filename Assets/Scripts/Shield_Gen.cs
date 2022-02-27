using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shield_Gen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject empty1;
    public static bool used;
    public int usednum = 0;
    private Scene currentScene;
    string sceneName;
    public static int shield_count = 0;
    private float waitTime;
    void Start()
    {
        waitTime = .2f;
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        
        Informant.bought_shield = true;
    }

    // Update is called once per frame
    void Update()
    {
      //  if (used)
      //  {
      //      Inventory.pos_objs[usednum] = null;
      //  }
        if(Input.GetKeyDown(KeyCode.T) && sceneName != "Shop 1" && waitTime <= 0)
        {
            UseShieldGen();
        } else
        {
            waitTime -= Time.deltaTime;
        }
    }

    private void DecrConsume(int ind)
    {
        Debug.Log(ind);
        if (ind == 2)
        {
            ConsumeCountText.ChangeConsume(-1);
        }
        else if (ind == 3)
        {
            ConsumeText2.ChangeConsume2(-1);
            Debug.Log("ALALL");
        }
        else if (ind == 4)
        {
            ConsumeText3.ChangeConsume3(-1);
        }
    }

    void UseShieldGen()
    {
        //Debug.Log(usednum);
        if (shield_count == 1)
        {
            Inventory.pos_objs[usednum] = empty1;
            Inventory._full[usednum] = false;
            DecrConsume(usednum);
            GenBar.shield = true;
            GenBar.start1 = true;
            Destroy(gameObject);
        } else
        {
            DecrConsume(usednum);
            shield_count--;
            GenBar.shield = true;
            GenBar.start1 = true;
        }
    }
}
