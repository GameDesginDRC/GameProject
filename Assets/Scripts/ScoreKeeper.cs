using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    public static int gold;
    //private static float score;
    private static Text scoreText;

    internal void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Stage 1")
        {
            gold = 100;
        }
        scoreText = GetComponent<Text>();
        UpdateText();
    }
    internal void Update()
    {
        //gold++;
        //UpdateText();
    }
    public static void AddToGold(int points)
    {
        gold += points;
        UpdateText();
    }
    public static void SubToGold(int points)
    {
        gold -= points;
        UpdateText();
    }

    /*  public static void AddToScore(float points)
      {
          score += points;
          UpdateText();
      }

      public static void SetScore(float points)
      {
          score = points;
          UpdateText();
      }*/

    private static void UpdateText()
    {
        scoreText.text = String.Format("Gold: {0}", gold);
    }
}

