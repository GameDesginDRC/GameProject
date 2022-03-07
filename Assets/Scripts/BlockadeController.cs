using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockadeController : MonoBehaviour
{
    public DestroyWall[] wallsArray1;
    public DestroyWall[] wallsArray2;

    public Transform pos1;
    public Transform pos2;
    public Transform pos3;

    public GameObject E1;
    public GameObject E2;
    public GameObject E3;
    public GameObject E4;
    public GameObject E5;

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
        if (numOfEnemies == 6 && phase == 0)
        {
            foreach(DestroyWall wall in wallsArray1)
            {
                wall.DestroyableWall(); //Destroys platform linked to pickup
            }
            phase +=1;
        }

        if (numOfEnemies == 5 && phase == 1)
        {
            
            Instantiate(E1, new Vector3(pos1.position.x+0.05f, pos1.position.y +0.4f, 0f), Quaternion.identity);
            Instantiate(E2, new Vector3(pos3.position.x+0.05f, pos3.position.y +0.4f, 0f), Quaternion.identity);
            // E1.gameObject.transform.position = new Vector3(pos1.position.x+0.05f, pos1.position.y +0.4f, 0f);
            // E2.gameObject.transform.position = new Vector3(pos3.position.x+0.05f, pos1.position.y +0.4f, 0f);
            phase +=1;
        }

        if (numOfEnemies == 3 && phase == 2)
        {
            Instantiate(E3, new Vector3(pos1.position.x+0.05f, pos1.position.y +0.4f, 0f), Quaternion.identity);
            Instantiate(E4, new Vector3(pos3.position.x+0.05f, pos2.position.y +0.4f, 0f), Quaternion.identity);
            Instantiate(E5, new Vector3(pos3.position.x+0.05f, pos3.position.y +0.4f, 0f), Quaternion.identity);
            phase +=1;
        }
        else if (numOfEnemies == 0 && phase == 3)
        {
            foreach(DestroyWall wall in wallsArray2)
            {
                wall.DestroyableWall(); //Destroys platform linked to pickup
            }
        }
    }
}
