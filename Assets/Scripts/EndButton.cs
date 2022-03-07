using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (hitInfo.gameObject.tag == ("Player") & Input.GetKey(KeyCode.Z))
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
