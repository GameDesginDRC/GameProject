using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    private static float score;
    private static Text scoreText;

    internal void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateText();
    }

    public static void AddToScore(float points)
    {
        score += points;
        UpdateText();
    }

    public static void SetScore(float points)
    {
        score = points;
        UpdateText();
    }

    private static void UpdateText()
    {
        scoreText.text = String.Format("Gold: {0}", score);
    }
}

