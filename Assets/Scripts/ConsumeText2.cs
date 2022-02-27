using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConsumeText2 : MonoBehaviour
{
    private static Text scoreText;
    public static int Consume2;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Stage 1")
        {
            Consume2 = 0;
        }
        scoreText = GetComponent<Text>();
        UpdateTextConsume2();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void NewConsume2(int points)
    {
        Consume2 = points;
        UpdateTextConsume2();
    }
    public static void ChangeConsume2(int points)
    {
        Consume2 += points;
        UpdateTextConsume2();
    }
    private static void UpdateTextConsume2()
    {
        scoreText.text = String.Format("{0}/3", Consume2);
    }
}
