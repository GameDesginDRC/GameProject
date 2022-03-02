using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageName : MonoBehaviour
{
    //private static float score;
    private static Text sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = gameObject.GetComponent<Text>();
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private static void UpdateText()
    {
        sceneName.text = SceneManager.GetActiveScene().name;
    }
}
