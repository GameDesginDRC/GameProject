using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConsumeText3 : MonoBehaviour
{
    private static Text scoreText;
    public static int Consume3;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Stage 1")
        {
            Consume3 = 0;
        }
        scoreText = GetComponent<Text>();
        UpdateTextConsume3();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void ChangeConsume3(int points)
    {
        Consume3 += points;
        UpdateTextConsume3();
    }
    private static void UpdateTextConsume3()
    {
        scoreText.text = String.Format("{0}/3", Consume3);
    }
}
