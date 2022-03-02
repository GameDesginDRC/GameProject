using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ActiveWeapon : MonoBehaviour
{
    public static int globalind = 0;
    private Image image;

    [SerializeField]
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Stage 1" || sceneName == "TUTORIAL") {
            globalind = 0;
        }

        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        if (globalind == index)
        {
            image.enabled = true;
        } else
        {
            image.enabled = false;
        }
    }
}
