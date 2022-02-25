using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUB_TV : MonoBehaviour
{
    public GameObject FloatingTextPrefab;
    public GameObject FloatingTextPrefab1;
    public GameObject FloatingTextPrefab2;
    public GameObject FloatingTextPrefab3;
    private Vector3 newvec;
    [SerializeField] string _nextlevelname;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("isFirstTime") != 1)
        {
            //Prologue that you want to use
            PlayerPrefs.SetInt("isFirstTime", 1);
            TV_Counter.countertv = 1;
        }
        newvec = new Vector3(-3.2f, 1f, 0);
        if (TV_Counter.countertv == 1)
        {
            var obj = Instantiate(FloatingTextPrefab, transform.position + newvec, Quaternion.identity, transform);
        }
        else if (TV_Counter.countertv == 2)
        {
            var obj = Instantiate(FloatingTextPrefab1, transform.position + newvec, Quaternion.identity, transform);
        }
        else if (TV_Counter.countertv == 3)
        {
            var obj = Instantiate(FloatingTextPrefab2, transform.position + newvec, Quaternion.identity, transform);
        }
        else if (TV_Counter.countertv >= 4)
        {
            var obj = Instantiate(FloatingTextPrefab3, transform.position + newvec, Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
