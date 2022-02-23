using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{ 
    [SerializeField] public bool[] _full1;
    [SerializeField] public GameObject[] spots1;
    [SerializeField] public GameObject[] posobjs1;
    [SerializeField] public GameObject filler;
    [SerializeField] public GameObject[] items1;
    [SerializeField] public GameObject startingWeapon;
    public static bool[] _full;
    public static GameObject[] spots;
    public static GameObject[] pos_objs;
    public static GameObject[] items;
    // Start is called before the first frame update
    // ISSUE: put items in public array and assign values later
    private void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName != "Stage 1" && sceneName != "TUTORIAL" && sceneName != "HUB")
        {
            //for (int i = 0; i < _full.Length; i++)
            // {
            //     DontDestroyOnLoad(spots[i]);
            // }

            for (int i = 0; i < _full.Length; i++)
            {
                DontDestroyOnLoad(pos_objs[i]);
                //line below affects item display for pos_objs
                //DontDestroyOnLoad(spots[i]);
                DontDestroyOnLoad(items[i]);

            }

                // UNCOMMENT LATER
 /*
                    DontDestroyOnLoad(item1);
                    DontDestroyOnLoad(item2);
                    DontDestroyOnLoad(item3);
                    DontDestroyOnLoad(item4);
                    DontDestroyOnLoad(item5);
                
            */
        }
        
    }
    void Start()
    {
       // Debug.Log(item3);
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        spots = spots1;
        if (sceneName == "Stage 1")
           {
                pos_objs = posobjs1;
                _full = _full1;
                spots = spots1;
                items = items1;
                Instantiate(startingWeapon, Inventory.spots[0].transform, false);
                items[0] = startingWeapon;
                pos_objs[0] = startingWeapon;
                _full[0] = true;
        }
        else if (sceneName != "HUB" || sceneName != "Abilities")
        {
            for (int i = 0; i < pos_objs.Length; i++)
            {
                Instantiate(pos_objs[i], spots[i].transform, false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
