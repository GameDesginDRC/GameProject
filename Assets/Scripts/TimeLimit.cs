using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLimit : MonoBehaviour
{
    public int timer123;
    [SerializeField]
    private static Text timecount;
    [SerializeField]
    string next;
    private float tracker;

    // private gets the component of the attached gameobject

    // Start is called before the first frame update
    void Start()
    {
        tracker = 0;
       timecount = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        tracker += Time.deltaTime;
        if (tracker >= 1)
        {
            timer123 -= 1;
            tracker = 0;
        }
        UpdateTexts();
        if (timer123 <= 0)
        {
            SceneManager.LoadScene(next);
        }
    }
    // static methods need static variables
    private void UpdateTexts()
    {
        timecount.text = String.Format("Time: {0}", timer123);
    }
}
