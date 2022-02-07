using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private int numOfEnemies;

    public static LevelManager Singleton;

    void Start()
    {
        // count all the enemies in the level
        numOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Singleton = this;
    }

    public static void DecreaseEnemyNum() {
        Singleton.numOfEnemies -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        // if all enemies are dead
        if (numOfEnemies == 0) {
            // go to the next stage
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
