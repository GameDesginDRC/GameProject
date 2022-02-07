using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPBar : MonoBehaviour
{
    public Slider hpvalue;
    // Start is called before the first frame update
    void Start()
    {
      //  Debug.Log(hpvalue.value);
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Stage 1")
        {
            hpvalue.value = 100;
        }
        Debug.Log(hpvalue.value);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Shop 1");
        }
    }

    public void ChangeHealth(int hp)
    {
        hpvalue.value = hp;

    }
}
