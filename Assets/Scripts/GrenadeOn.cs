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
    // Start is called before the first frame update
    void Start()
    {
        waitTime = .2f;
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Informant.bought_grenade = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && sceneName != "Shop 1" && waitTime <= 0)
        {
            waitTime = .5f;
            UseGrenade();
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
    void UseGrenade()
    {
        //Debug.Log(usednum);
        // look at this code, should be when == 1???
        if (GrenadeCount == 1)
        {
            Debug.Log("POL");
            Inventory.pos_objs[usednum] = empty1;
            Inventory._full[usednum] = false;
            GameObject temp = GameObject.Find("Player");
            Transform temptrans = temp.GetComponent<Transform>();
            Instantiate(gren, temptrans.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            GrenadeCount--;
            GameObject temp = GameObject.Find("Player");
            Transform temptrans = temp.GetComponent<Transform>();
            Instantiate(gren, temptrans.position, Quaternion.identity);
            hpIncr = 1;
        }
    }
}
