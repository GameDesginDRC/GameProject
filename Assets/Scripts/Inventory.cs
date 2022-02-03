using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    [SerializeField] public bool[] _full1;
    [SerializeField] public GameObject[] spots1;
    [SerializeField] public GameObject[] posobjs1;
    public static bool[] _full;
    public static GameObject[] spots;
    public static GameObject[] pos_objs;
    // Start is called before the first frame update
    private void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName != "Stage 1")
        {
            //for (int i = 0; i < _full.Length; i++)
           // {
           //     DontDestroyOnLoad(spots[i]);
           // }
            for (int i = 0; i < _full.Length; i++)
            {
                DontDestroyOnLoad(pos_objs[i]);
            }
        }
    }
    void Start()
    {
       
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        spots = spots1;
        if (sceneName == "Stage 1")
        {
            pos_objs = posobjs1;
            _full = _full1;
            spots = spots1;
        }
        else
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
