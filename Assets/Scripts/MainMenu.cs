using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int option = 1;
    [SerializeField]
    private TextMeshPro StartGameText;
    [SerializeField]
    private TextMeshPro TutorialText;
    [SerializeField]
    private TextMeshPro QuitText;
    [SerializeField]
    private AudioSource menuAudio;

    [SerializeField]
    private AudioClip MenuNavi;
    [SerializeField]
    private AudioClip MenuSelect;
    [SerializeField]
    public Image m_Image;
    private bool fading = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Image.canvasRenderer.SetAlpha(0);
    }

    void LoadLevel1()
    {
        SceneManager.LoadScene("IntroCutscene");
    }
    void LoadTutorial()
    {
        SceneManager.LoadScene("TUTORIAL");
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            m_Image.CrossFadeAlpha(1, .5f, false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            menuAudio.PlayOneShot(MenuNavi);
            option += 1;
            if (option == 4) { option = 1; }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            menuAudio.PlayOneShot(MenuNavi);
            option -= 1;
            if (option == 0) { option = 3; }
        }

        if (Input.GetKeyDown("z"))
        {
            if (option == 1)
            {
                // go to first level
                menuAudio.PlayOneShot(MenuSelect);
                fading = true;
                Invoke("LoadLevel1", 1f);
            }
            if (option == 2)
            {
                // go to tutorial
                menuAudio.PlayOneShot(MenuSelect);
                fading = true;
                Invoke("LoadTutorial", 1f);
            }

            if (option == 3)
            {
                // quit game
                menuAudio.PlayOneShot(MenuSelect);
                Debug.Log("quit");
                fading = true;
                Application.Quit();
            }
        }

        if (option == 1) {
            StartGameText.color = Color.cyan;
            TutorialText.color = Color.white;
            QuitText.color = Color.white;
        }
        if (option == 2)
        {
            StartGameText.color = Color.white;
            TutorialText.color = Color.cyan;
            QuitText.color = Color.white;
        }
        if (option == 3)
        {
            StartGameText.color = Color.white;
            TutorialText.color = Color.white;
            QuitText.color = Color.cyan;
        }

    }
}
