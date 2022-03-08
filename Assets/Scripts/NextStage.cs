using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    [SerializeField]
    string next;
    // Start is called before the first frame update
    [SerializeField]
    float WaitForXSeconds = 5;
    void Start()
    {
        StartCoroutine(NextLvl());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator NextLvl()
    {
        yield return new WaitForSeconds(WaitForXSeconds);
        SceneManager.LoadScene(next);
    }
}
