using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockadeController : MonoBehaviour
{
    public DestroyWall[] wallsArray1;
    public DestroyWall[] wallsArray2;
    public DestroyWall[] wallsArray3;


    [SerializeField]
    private int numOfEnemies;
    public static BlockadeController Singleton;

    private int phase = 0;

    void Start()
    {
        // count all the enemies in the level
        numOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //Debug.Log(numOfAbilities);
        Singleton = this;
    }


    public static void DecreaseFinEnemyNum() {
        Singleton.numOfEnemies -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfEnemies == 3 && phase == 0)
        {
            foreach(DestroyWall wall in wallsArray1)
            {
                wall.DestroyableWall(); //Destroys platform linked to pickup
            }
            phase +=1;
        }
    }
}
