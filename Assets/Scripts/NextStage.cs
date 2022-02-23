using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    [SerializeField] string next;
    // Start is called before the first frame update
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
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(next);
    }
}
