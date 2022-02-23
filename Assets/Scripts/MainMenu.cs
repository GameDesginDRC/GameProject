using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int option = 1;
    [SerializeField]
    private TextMeshPro StartGameText;
    [SerializeField]
    private TextMeshPro TutorialText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            option += 1;
            if (option == 3) { option = 1; }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            option -= 1;
            if (option == 0) { option = 2; }
        }

        if (Input.GetKeyDown("z"))
        {
            if (option == 1)
            {
                // go to first level
                SceneManager.LoadScene("Transition1");
            }
            if (option == 2)
            {
                // go to tutorial
                SceneManager.LoadScene("TUTORIAL");
            }
        }

        if (option == 1) {
            StartGameText.color = Color.cyan;
            TutorialText.color = Color.white;
        }
        if (option == 2)
        {
            StartGameText.color = Color.white;
            TutorialText.color = Color.cyan;
        }

    }
}
