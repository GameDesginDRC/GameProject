using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrenadeOn : MonoBehaviour
{
    public GameObject empty1;
    public static bool used;
    public int usednum = 0;
    private Scene currentScene;
    string sceneName;
    public static int GrenadeCount = 0;
    public static int hpIncr = 0;
    private float waitTime = 0;
    public GameObject gren;
    private Transform ShootPoint;
    private GameObject temp;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = .2f;
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Informant.bought_grenade = true;
        temp = GameObject.Find("ShootPoint");
        ShootPoint = temp.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && sceneName != "Shop 1" && waitTime <= 0)
        {
            waitTime = .5f;
            UseGrenade();
        }
        else
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

    void UseGrenade()
    {
        //Debug.Log(usednum);
        // look at this code, should be when == 1???
        if (GrenadeCount == 1)
        {
            
            DecrConsume(usednum);
            GrenadeCount--;
            Inventory.pos_objs[usednum] = empty1;
            Inventory._full[usednum] = false;
            Instantiate(gren, ShootPoint.position, ShootPoint.rotation); //Spawns bullet
            Destroy(gameObject);
        }
        else
        {
            GrenadeCount--;
            DecrConsume(usednum);
            Instantiate(gren, ShootPoint.position, ShootPoint.rotation); //Spawns bullet
            hpIncr = 1;
        }
    }
}
