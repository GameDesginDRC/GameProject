using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField]
    public Button but1;
    [SerializeField]
    public Button but2;
    [SerializeField]
    public Button but3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        Debug.Log(EventSystem.current.currentSelectedGameObject);
        if (Input.GetKeyDown(KeyCode.Z) && EventSystem.current.currentSelectedGameObject.GetComponent<But1>() != null)
        //if (Input.GetKeyDown(KeyCode.G))
        {
            pauseMenuUI.SetActive(false);
            GameIsPaused = false;
            Time.timeScale = 1f;
            but1.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Z) && EventSystem.current.currentSelectedGameObject.GetComponent<But2>() != null)
        {
            pauseMenuUI.SetActive(false);
            GameIsPaused = false;
            Time.timeScale = 1f;
            but2.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Z) && EventSystem.current.currentSelectedGameObject.GetComponent<But3>() != null)
        {
            pauseMenuUI.SetActive(false);
            GameIsPaused = false;
            Time.timeScale = 1f;
            but3.onClick.Invoke();
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameObject.Find("Player").GetComponent<Player>().enabled = true;
    }
    void Pause()
    {
        // setting it to be active 
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameObject.Find("Player").GetComponent<Player>().enabled = false;
    }
    public void loadmenu()
    {
        SceneManager.LoadScene("TITLESCREEN");
    }
    public void restart()
    {
        SceneManager.LoadScene("Transition1");
    }
    /*   public void Hoveringon()
       {
           if (Input.GetKeyDown(KeyCode.Z))
           {
               pauseMenuUI.SetActive(false);
               GameIsPaused = false;
               Time.timeScale = 1f;
               but1.onClick.Invoke();
           }
       }
       public void Hoveringon1()
       {
           if (Input.GetKeyDown(KeyCode.G))
           {
               pauseMenuUI.SetActive(false);
               GameIsPaused = false;
               Time.timeScale = 1f;
               but2.onClick.Invoke();
           }
       }
       public void Hoveringon2()
       {
           if (Input.GetKeyDown(KeyCode.Z))
           {
               pauseMenuUI.SetActive(false);
               GameIsPaused = false;
               Time.timeScale = 1f;
               but3.onClick.Invoke();
           }
       }*/
}
