using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConsumeCountText : MonoBehaviour
{
    private static Text scoreText;
    public static int Consume1;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Stage 1")
        {
            Consume1 = 0;
        }
        scoreText = GetComponent<Text>();
        UpdateTextConsume1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void NewConsume(int points)
    {
        Consume1 = points;
        UpdateTextConsume1();
    }
    public static void ChangeConsume(int points)
    {
        Consume1 += points;
        UpdateTextConsume1();
    }
    private static void UpdateTextConsume1()
    {
        scoreText.text = String.Format("{0}/3", Consume1);
    }
}
