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
    void Start()
    {
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
        if(Input.GetKeyDown(KeyCode.T) && sceneName != "Shop 1")
        {
            UseShieldGen();
        }
    }
    void UseShieldGen()
    {
        //Debug.Log(usednum);
        Inventory.pos_objs[usednum] = empty1;
        Inventory._full[usednum] = false;
        GenBar.shield = true;
        GenBar.start1 = true;
        Destroy(gameObject);
    }
}
