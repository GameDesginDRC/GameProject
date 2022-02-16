using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private int numOfEnemies;
    public int numOfAbilities;


    public static LevelManager Singleton;
    
    void Start()
    {
        // count all the enemies in the level
        numOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
        
        //Debug.Log(numOfAbilities);
        Singleton = this;
    }



    public static void DecreaseEnemyNum() {
        Singleton.numOfEnemies -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        numOfAbilities = GameObject.FindGameObjectsWithTag("Abilities").Length;
        /*Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Stage 1")
        {
            numOfAbilities = 12;
        }*/
            // if all enemies are dead
        Scene scene = SceneManager.GetActiveScene();
        if (numOfEnemies == 0 && scene.name != "Abilities" && scene.name != "TUTORIAL") {
            // go to the next stage
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Debug.Log(SceneManager.(SceneManager.GetActiveScene().buildIndex + 1).name);
        }
        if (numOfAbilities == 2) {
            // was 2
            // go to the next stage
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
