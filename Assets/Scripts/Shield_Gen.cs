using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shield_Gen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject empty1;
    public static bool used;
    public int usednum;
    private Scene currentScene;
    string sceneName;
    public static int shield_count = 0;
    private float waitTime;
    void Start()
    {
        waitTime = .2f;
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        usednum = 0;
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
    void UseShieldGen()
    {
        //Debug.Log(usednum);
        if (shield_count == 1)
        {
            Inventory.pos_objs[usednum] = empty1;
            Inventory._full[usednum] = false;
            GenBar.shield = true;
            GenBar.start1 = true;
            Destroy(gameObject);
        } else
        {
            shield_count--;
            GenBar.shield = true;
            GenBar.start1 = true;
        }
    }
}
